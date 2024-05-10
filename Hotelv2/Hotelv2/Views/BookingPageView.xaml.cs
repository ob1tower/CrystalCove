using Hotelv2.Data;
using Hotelv2.Models;
using Hotelv2.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Hotelv2.Views
{
    public partial class BookingPageView : Page
    {
        public BookingPageView()
        {
            InitializeComponent();
            RefreshBookingData();
        }

        // Метод для обновления данных о бронировании
        private void RefreshBookingData()
        {
            BookingDataGrid.ItemsSource = BookingService.GetAllBookingWithStaffClient();
        }

        // Метод для поиска родительского элемента определенного типа
        private static T FindPerent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject perentObject = VisualTreeHelper.GetParent(child);
            if (perentObject == null)
            {
                return null;
            }
            T perent = perentObject as T;
            return perent ?? FindPerent<T>(perentObject);
        }

        // Обработчик события для кнопки добавления бронирования
        private void AddBooking_Click(object sender, RoutedEventArgs e)
        {
            var hotelHomeView = FindPerent<HotelHomeView>(this);
            hotelHomeView?.ShowOverlay();

            if (UserService.CurrentStaff != null)
            {
                using (HotelDbContext hotelDbContext = new HotelDbContext())
                {
                    var currentClient = hotelDbContext.Clients.FirstOrDefault();

                    if (currentClient != null)
                    {
                        AddBookingView addBookingView = new AddBookingView(BookingDataGrid, UserService.CurrentStaff, currentClient);
                        addBookingView.ShowDialog();

                        hotelHomeView?.HideOverlay();

                        RefreshBookingData();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось определить текущего клиента.", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                        hotelHomeView?.HideOverlay();
                    }
                }
            }
            else
            {
                MessageBox.Show("Не удалось определить текущего сотрудника.", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
                hotelHomeView?.HideOverlay();
            }
        }

        // Обработчик события для кнопки изменения бронирования
        private void EditBooking_Click(object sender, RoutedEventArgs e)
        {
            var hotelHomeView = FindPerent<HotelHomeView>(this);
            hotelHomeView?.ShowOverlay();

            using (HotelDbContext hotelDbContext = new HotelDbContext())
            {
                var currentClient = hotelDbContext.Clients.FirstOrDefault();
                UpdateBookingView updateBookingView = new UpdateBookingView(BookingDataGrid, UserService.CurrentStaff, currentClient);
                updateBookingView.ShowDialog();

                hotelHomeView?.HideOverlay();

                RefreshBookingData();
            }
        }

        // Обработчик события для кнопки удаления бронирования
        private void DeleteBooking_Click(object sender, RoutedEventArgs e)
        {
            var selectedBooking = BookingDataGrid.SelectedItem as Booking;
            if (selectedBooking != null)
            {
                BookingService.DeleteBooking(selectedBooking);
                RefreshBookingData();
            }
        }
    }
}
