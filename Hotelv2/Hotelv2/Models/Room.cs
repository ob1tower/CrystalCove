namespace Hotelv2.Models
{
    public class Room
    {
        public int Id { get; set; } // Личный номер
        public int NumberRoom { get; set; } // Номер комнаты

        public string Category { get; set; } = string.Empty; // Категория

        public int Floor { get; set; } // Этаж

        public int NumberSeats { get; set; } // Количество мест

        public decimal Price { get; set; } // Цена

        public bool StatusBooking { get; set; } // Статус бронирования
    }
}
