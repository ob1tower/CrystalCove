namespace Hotelv2.Models
{
    public class Staff : Person
    {
        public override int Id { get; set; } // Личный номер
        public string UserName { get; set; } = string.Empty; // Логин
        public string Password { get; set; } = string.Empty; // Пароль

        public string FullName => $"{LastName} {FirstName} {Patronymic}";

        // Внешний ключ для связи с таблицей ролей
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
