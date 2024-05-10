using Hotelv2.Data;
using Hotelv2.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotelv2.Services
{
    public class BookingService
    {
        private static readonly HotelDbContext _context = new HotelDbContext();

        // Получение всех бронирований с информацией о сотрудниках и клиентах и комнатах
        public static List<Booking> GetAllBookingWithStaffClient()
        {
            return _context.Bookings // Запрос к базе данных для получения
                .Include(b => b.Staff)
                .Include(b => b.Client)
                .Include(b => b.Room)
                .ToList();
        }

        // Добавление бронирование
        public static bool CreateBooking(DateTime bookingDate, DateTime checkIn, DateTime checkOut, string clientFullName, string staffFullName, int numberRoom)
        {
            // Поиск комнаты по номеру комнаты
            var room = _context.Rooms.FirstOrDefault(r => r.NumberRoom == numberRoom);

            // Проверка наличия комнаты и ее доступности для бронирования
            if (room != null && room.StatusBooking == false)
            {
                // Поиск сотрудника по его ФИО
                var staff = _context.Staffs.FirstOrDefault(s =>
                        (s.LastName + " " + s.FirstName + " " + s.Patronymic).Trim() == staffFullName.Trim());

                // Поиск клиента по его ФИО
                var client = _context.Clients.FirstOrDefault(c =>
                    (c.LastName + " " + c.FirstName + " " + c.Patronymic).Trim() == clientFullName.Trim());

                // Проверка наличия сотрудника и клиента
                if (staff != null && client != null)
                {
                    // Создание нового бронирования
                    Booking booking = new Booking
                    {
                        BookingDate = bookingDate.ToUniversalTime(),
                        CheckIn = checkIn.ToUniversalTime(),
                        CheckOut = checkOut.ToUniversalTime(),
                        Client = client,
                        Staff = staff,
                        Room = room
                    };

                    room.StatusBooking = true; // Пометка комнаты как забронированной
                    _context.Bookings.Add(booking); // Добавление бронирования в БД
                    _context.SaveChanges(); // Сохраняем изменения в БД

                    // Обновляем статус комнаты
                    RoomService.UpdateRoomStatus(room.Id, true);
                    return true;
                }
            }
            return false;
        }

        // Обновление бронирования
        public static bool UpdateBooking(DateTime bookingDate, DateTime checkIn, DateTime checkOut, string clientFullName, string staffFullName, int numberRoom, Booking booking)
        {
            // Поиск комнаты по номеру комнаты
            var newRoom = _context.Rooms.FirstOrDefault(r => r.NumberRoom == numberRoom);

            // Поиск старой комнаты, которая была ранее забронирована
            var oldRoom = _context.Rooms.FirstOrDefault(r => r.Id == booking.RoomId);

            // Проверка наличия новой комнаты и старой комнаты
            if (newRoom != null && oldRoom != null)
            {
                // Проверяем, была ли изменена комната
                if (newRoom.Id != oldRoom.Id)
                {
                    // Проверяем, свободна ли новая комната
                    if (newRoom.StatusBooking)
                    {
                        return false;
                    }

                    // Освобождаем старую комнату
                    oldRoom.StatusBooking = false;
                    RoomService.UpdateRoomStatus(oldRoom.Id, false);

                    // Занимаем новую комнату
                    newRoom.StatusBooking = true;
                    RoomService.UpdateRoomStatus(newRoom.Id, true);
                }

                // Поиск сотрудника по его ФИО
                var staff = _context.Staffs.FirstOrDefault(s =>
                        (s.LastName + " " + s.FirstName + " " + s.Patronymic).Trim() == staffFullName.Trim());

                // Поиск клиента по его ФИО
                var client = _context.Clients.FirstOrDefault(c =>
                    (c.LastName + " " + c.FirstName + " " + c.Patronymic).Trim() == clientFullName.Trim());

                // Проверка наличия сотрудника и клиента
                if (staff != null && client != null)
                {
                    // Находим запись бронирования по ее ID
                    var upBooking = _context.Bookings.Find(booking.Id);
                    if (upBooking != null)
                    {
                        // Обновляем данные бронирования
                        upBooking.BookingDate = bookingDate.ToUniversalTime();
                        upBooking.CheckIn = checkIn.ToUniversalTime();
                        upBooking.CheckOut = checkOut.ToUniversalTime();
                        upBooking.Staff = staff;
                        upBooking.Client = client;
                        upBooking.Room = newRoom; // Обновляем комнату в бронировании
                    }

                    _context.SaveChanges(); // Сохраняем изменения в БД
                    return true;
                }
            }
            return false;
        }

        // Удаление бронирования
        public static bool DeleteBooking(Booking booking)
        {
            // Поиск бронирования по личному номеру
            Booking? delBooking = _context.Bookings.SingleOrDefault(x => x.Id == booking.Id);
            if (delBooking != null)
            {
                // Поиск всех бронирований клиента
                var clientBookings = _context.Bookings.Where(b => b.ClientId == delBooking.ClientId).ToList(); 

                foreach (var clientBooking in clientBookings)
                {
                    // Поиск комнаты текущего бронирования
                    var room = _context.Rooms.Find(delBooking.RoomId);
                    if (room != null)
                    {
                        room.StatusBooking = false; // Пометка комнаты как свободной
                        _context.SaveChanges(); // Сохранение изменений статуса комнаты
                        RoomService.UpdateRoomStatus(room.Id, false); // Обновление статуса комнаты
                    }
                }

                // Проверка наличия других бронирований у клиента
                var otherBookings = _context.Bookings.Any(b => b.ClientId == delBooking.ClientId && b.Id != delBooking.Id);
                if (!otherBookings)
                {
                    // Если у клиента нет других бронирований, пометить его комнаты как свободные
                    var clientRooms = _context.Bookings.Where(b => b.ClientId == delBooking.ClientId).Select(b => b.RoomId);
                    foreach (var clientId in clientRooms)
                    {
                        var clientRoom = _context.Rooms.Find(clientId);
                        if (clientRoom != null)
                        {
                            clientRoom.StatusBooking = false;
                            RoomService.UpdateRoomStatus(clientRoom.Id, false); // Обновление статуса комнаты клиента
                        }
                    }
                    _context.SaveChanges(); // Сохранение изменений статуса комнат клиента
                }
                _context.Bookings.Remove(delBooking); // Удаление бронирования из БД
                _context.SaveChanges(); // Сохранение изменений в БД
                return true;
            }
            return false;
        }
    }
}
