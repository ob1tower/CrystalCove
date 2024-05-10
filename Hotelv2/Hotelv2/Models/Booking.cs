namespace Hotelv2.Models
{
    public class Booking
    {
        public int Id { get; set; } // Личный номер
        public DateTime BookingDate { get; set; } // Дата бронирование
        public DateTime CheckIn { get; set; } // Дата заезда
        public DateTime CheckOut { get; set; } // Дата выезда

        // Связь с клиентом
        public string ClientFullName => $"{Client.LastName} {Client.FirstName[0]}. {Client.Patronymic[0]}.";
        public int ClientId { get; set; } // Внешний ключ для связи
        public Client Client { get; set; } = null!; // Навигационное свойство для доступа

        // Связь со сотрудником
        public string StaffFullName => $"{Staff.LastName} {Staff.FirstName[0]}. {Staff.Patronymic[0]}.";
        public int StaffId { get; set; } // Внешний ключ для связи
        public Staff Staff { get; set; } = null!; // Навигационное свойство для доступа

        // Связь с номерами
        public int RoomId { get; set; } // Внешний ключ для связи
        public Room Room { get; set; } = null!; // Навигационное свойство для доступа
    }
}
