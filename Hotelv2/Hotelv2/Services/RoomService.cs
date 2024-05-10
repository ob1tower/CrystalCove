using Hotelv2.Data;
using Hotelv2.Models;
using System.Windows;

namespace Hotelv2.Services
{
    public static class RoomService
    {
        private static readonly HotelDbContext _context = new HotelDbContext();

        // Получение всех номеров
        public static List<Room> GetAllRoom()
        {
            return _context.Rooms.ToList();
        }

        // Добавление номеров
        public static void CreateRoom(int numberRoom, string category, int floor, int numberSeats, decimal price)
        {
            // Создаем новую комнату
            Room room = new Room { NumberRoom = numberRoom, 
                                   Category = category, 
                                   Floor = floor, 
                                   NumberSeats = numberSeats, 
                                   Price = price, 
                                   StatusBooking = false };
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        // Обновление номеров
        public static void UpdateRoom(int numberRoom, string category, int floor, int numberSeats, decimal price, Room room)
        {
            // Находим номер в базе данных по его ID
            Room upRoom = _context.Rooms.Find(room.Id);
            if (upRoom != null)
            {
                upRoom.NumberRoom = numberRoom;
                upRoom.Category = category;
                upRoom.Floor = floor;
                upRoom.NumberSeats = numberSeats;
                upRoom.Price = price;
                
                _context.SaveChanges();
            }
        }

        // Удаление номеров
        public static bool DeleteRoom(Room room)
        {
            Room delRoom = _context.Rooms.Single(x => x.Id == room.Id);
            if (delRoom != null)
            {
                _context.Rooms.Remove(delRoom);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Обновление статуса комнаты
        public static void UpdateRoomStatus(int roomId, bool status)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
            if (room != null)
            {
                room.StatusBooking = status;
                _context.SaveChanges();
            }
        }

    }
}
