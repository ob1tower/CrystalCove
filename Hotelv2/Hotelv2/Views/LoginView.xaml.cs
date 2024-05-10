using Hotelv2.Services;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Hotelv2.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        // Обработчик события нажатия кнопки входа
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (UserName.Text != string.Empty && Password.Password != string.Empty)
            {
                UserService.SearchUser(UserName.Text, Password.Password, this);
            }
            else MessageBox.Show("Пожалуйста, укажите логин и пароль.", "Ошибка", MessageBoxButton.OK,
                 MessageBoxImage.Warning);
        }

        // Обработчик события ввода текста для проверки допустимости вводимых символов на буквы и цифры
        private void ValidationLetNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(new Regex("[A-Za-z0-9]").IsMatch(e.Text));
        }

        // Обработчик события для перемещения окна при нажатии и удерживании левой кнопки мыши
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        // Обработчик события для закрытия окна при нажатии кнопки "Закрыть"
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Показываем пароль по флажку
        private void ShowPassword(object sender, RoutedEventArgs e)
        {
            Password.Visibility = System.Windows.Visibility.Collapsed;
            PasswordText.Visibility = System.Windows.Visibility.Visible;
            PasswordText.Text = Password.Password;
        }

        // Скрываем пароль по флажку
        private void NotShowPassword(object sender, RoutedEventArgs e)
        {
            PasswordText.Visibility = System.Windows.Visibility.Collapsed;
            Password.Visibility = System.Windows.Visibility.Visible;
            Password.Password = PasswordText.Text;
        }
    }
}
