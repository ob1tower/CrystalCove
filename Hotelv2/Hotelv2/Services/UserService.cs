using Hotelv2.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Hotelv2.Models;

namespace Hotelv2.Services
{
    public static class UserService
    {
        private static readonly HotelDbContext _context = new HotelDbContext();
        public static Staff? CurrentStaff { get; private set; }

        // Метод для поиска пользователя по логину и паролю, а затем открывает соответствующее окно
        public static void SearchUser(string userName, string password, Window LoginView)
        {
            // Получаем сотрудника по логину и паролю
            CurrentStaff = _context.Staffs.FirstOrDefault(u => u.UserName == userName 
                                                           && u.Password == password);

            // Если сотрудник найден, открываем соответствующее окно
            if (CurrentStaff != null)
            {
                OpenPageBasedOnRole(CurrentStaff.RoleId);
                LoginView.Close();
            }
            else MessageBox.Show("Неправильный логин или пароль. Пожалуйста, попробуйте снова.", "Ошибка входа",
                 MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        // Метод для открытия соответствующего окна в зависимости от роли пользователя
        private static void OpenPageBasedOnRole(int roleId)
        {
            switch (roleId)
            {
                case 1:
                    HotelHomeView hotelHomeView = new HotelHomeView();
                    hotelHomeView.Show();
                    break;
                default:
                    MessageBox.Show("У пользователя нет доступа к системе!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
            }
        }
    }
}
