using Hotelv2.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace Hotelv2
{
    public partial class HotelHomeView : Window
    {
        public HotelHomeView()
        {
            InitializeComponent();
            Loaded += HotelHomeView_Loaded;
        }

        // Обработчик события для закрытия окна при нажатии кнопки "Закрыть"
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Обработчик события для перемещения окна при нажатии и удерживании левой кнопки мыши
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        // Обработчик события для развертывания/восстановления окна при нажатии кнопки "Развернуть"
        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        // Обработчик события для сворачивания окна при нажатии кнопки "Свернуть"
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        // Обработчик события для перехода на страницу клиента
        private void rdClient_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Views/ClientPageView.xaml", UriKind.RelativeOrAbsolute));
        }

        // Обработчик события для перехода на страницу комнаты
        private void rdRoom_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Views/RoomPageView.xaml", UriKind.RelativeOrAbsolute));
        }

        // Обработчик события для перехода на страницу бронирования
        private void rdBooking_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Views/BookingPageView.xaml", UriKind.RelativeOrAbsolute));
        }

        // Обработчик события для перехода на страницу выход
        private void rdExit_Click(object sender, RoutedEventArgs e)
        {
            // Показать диалоговое окно подтверждения
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти из аккаунта?", "Выход из аккаунта", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Если пользователь подтвердил выход, открыть окно входа в систему
            if (result == MessageBoxResult.Yes)
            {
                LoginView loginWindow = new LoginView();
                loginWindow.Show();
                this.Close();
            }
        }

        public void ShowOverlay()
        {
            overlay.Visibility = Visibility.Visible;
        }
        
        public void HideOverlay()
        {
            overlay.Visibility = Visibility.Collapsed;
        }

        // Обработчик события для перехода на страницу клиента сразу
        private void HotelHomeView_Loaded(object sender, RoutedEventArgs e)
        {
            rdClient.IsChecked = true;

            PagesNavigation.Navigate(new System.Uri("Views/ClientPageView.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}