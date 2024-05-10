using Hotelv2.Data;
using Hotelv2.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Hotelv2.Services
{
    public static class ClientService
    {
        private static readonly HotelDbContext _context = new HotelDbContext();

        // Получение всех клиентов
        public static List<Client> GetAllClient()
        {
            return _context.Clients.ToList();
        }

        // Добавление клиента
        public static void CreateClient(string firstName, string lastName, string patronymic, string passportNumber, string phoneNumber, string email)
        {
            Client client = new Client
            {
                FirstName = firstName,
                LastName = lastName,
                Patronymic = patronymic,
                PassportNumber = passportNumber,
                PhoneNumber = phoneNumber,
                Email = email
            };
            _context.Clients.Add(client);
            _context.SaveChanges(); 
        }

        // Обновление клиента
        public static void UpdateClient(string firstName, string lastName, string patronymic, string passportNumber, string phoneNumber, string email, Client client)
        {
            // Находим клиента в базе данных по его ID
            Client upClient = _context.Clients.Find(client.Id);

            // Проверяем, что клиент найден
            if (upClient != null)
            {
                // Обновляем данные клиента
                upClient.FirstName = firstName;
                upClient.LastName = lastName;
                upClient.Patronymic = patronymic;
                upClient.PassportNumber = passportNumber;
                upClient.PhoneNumber = phoneNumber;
                upClient.Email = email;

                // Сохраняем изменения
                _context.SaveChanges();
            }
        }

        // Удаление клиента
        public static bool DeleteClient(Client client)
        {
            Client delClient = _context.Clients.SingleOrDefault(x => x.Id == client.Id);
            if (delClient != null)
            {
                try
                { 
                    // Находим все бронирования, связанные с клиентом
                    var bookings = _context.Bookings.Where(b => b.ClientId == delClient.Id).ToList();

                    // Если найдены бронирования, показываем сообщение об ошибке
                    if (bookings.Any())
                    {
                        MessageBox.Show("Невозможно удалить клиента, так как у него есть бронирование.", "Ошибка", 
                                                                      MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }

                    // Удаляем клиента из базы данных
                    _context.Clients.Remove(delClient);
                    _context.SaveChanges();

                    // Показываем сообщение об успешном удалении клиента
                    MessageBox.Show("Клиент успешно удален!", "Информация",
                         MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    // Обработка исключения
                    MessageBox.Show("Ошибка удаления клиента: " + ex.Message, "Ошибка", 
                                            MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return false;
        }
    }
}
