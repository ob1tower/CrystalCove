namespace Hotelv2.Models
{
    // Класс Client 
    public class Client : Person
    {
        public override int Id { get; set; } // Личный номер
        public string PassportNumber { get; set; } = string.Empty; // Паспортные данные
        public string PhoneNumber { get; set; } = string.Empty; // Номер телефон
        public string Email { get; set; } = string.Empty; // Электронная почта

        // Свойство FullName, которое возвращает полное имя клиента
        public string FullName => $"{LastName} {FirstName} {Patronymic}";
    }
}
