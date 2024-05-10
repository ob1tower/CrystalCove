using Hotelv2.Data;
using Hotelv2.Models;
using Hotelv2.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hotelv2.Views
{
    public partial class UpdateBookingView : Window
    {
        public DataGrid BookingDataGrid { get; }
        private readonly Staff currentStaff;
        private Client currentClient;

        public UpdateBookingView(DataGrid bookingDataGrid, Staff staff, Client client)
        {
            InitializeComponent();
            BookingDataGrid = bookingDataGrid;
            currentStaff = staff;
            currentClient = client;
            LoadClientRoom();
        }

        // Метод для обновления выбора клиента
        private void ClientId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получаем выбранное имя клиента
            string selectedClientName = ClientId.SelectedItem as string;

            // Если имя клиента не пустое
            if (!string.IsNullOrEmpty(selectedClientName))
            {
                // Выполняем запрос на стороне клиента для получения клиента по его имени
                using (var dbContext = new HotelDbContext())
                {
                    currentClient = dbContext.Clients.AsEnumerable().FirstOrDefault(c => c.FullName == selectedClientName);
                }
            }
        }

        // Метод для загрузки клиентов и номеров
        private void LoadClientRoom()
        {
            using (var dbContext = new HotelDbContext())
            {
                ClientId.FilterMode = AutoCompleteFilterMode.Contains;
                var clients = dbContext.Clients.Select(c => c.FullName).ToList();
                ClientId.ItemsSource = clients;

                // Обработчик события изменения выбора клиента
                ClientId.SelectionChanged += ClientId_SelectionChanged;
            }

            // Загрузка номеров комнат
            using (var dbContext = new HotelDbContext())
            {
                RoomId.FilterMode = AutoCompleteFilterMode.Contains;
                var roomNumbers = dbContext.Rooms.Select(r => r.NumberRoom.ToString()).ToList();
                RoomId.ItemsSource = roomNumbers;
            }
        }

        // Метод для сохранения изменений в бронировании
        private void SaveBooking_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранную дату и время из календарей
            DateTime bookingDate = BookingDate.SelectedDate ?? DateTime.MinValue;
            DateTime checkInDate = CheckIn.SelectedDate ?? DateTime.MinValue;
            DateTime checkOutDate = CheckOut.SelectedDate ?? DateTime.MinValue;

            // Парсим время в формате HH:mm:ss
            string bookingTime = "03:00:00";
            string checkInTime = "03:00:00"; // Устанавливаем желаемое время
            string checkOutTime = "03:00:00"; // Устанавливаем желаемое время

            // Соединяем дату и время
            DateTime bookingDateTime = DateTime.ParseExact(bookingDate.ToString("yyyy-MM-dd") + " " + bookingTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime checkInDateTime = DateTime.ParseExact(checkInDate.ToString("yyyy-MM-dd") + " " + checkInTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime checkOutDateTime = DateTime.ParseExact(checkOutDate.ToString("yyyy-MM-dd") + " " + checkOutTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            // Проверка на заполненность всех полей
            if (BookingDate.Text != string.Empty && CheckIn.Text != string.Empty &&
                CheckOut.Text != string.Empty && ClientId.Text != string.Empty &&
                RoomId.Text != string.Empty)
            {
                // Вызов метода обновления бронирование
                if (BookingService.UpdateBooking(bookingDateTime,
                                                 checkInDateTime,
                                                 checkOutDateTime,
                                                 currentClient.FullName,
                                                 currentStaff.FullName,
                                                 int.Parse(RoomId.Text),
                                                 BookingDataGrid.SelectedItem as Booking))
                {
                    MessageBox.Show("Бронирование успешно обновлено!", "Информация",
                                  MessageBoxButton.OK, MessageBoxImage.Information);

                    BookingDataGrid.ItemsSource = BookingService.GetAllBookingWithStaffClient();
                    Close();
                }
                else
                {
                    // Возникла ошибка при обновлении бронирования
                    MessageBox.Show("Нельзя выбрать забронированную комнату!", "Ошибка",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else MessageBox.Show("Пожалуйста, введите все данные.", "Ошибка",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
        }

        // Метод для закрытия окна
        private void CloseBooking_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

        // Метод для валидации ввода только цифр
        private void ValidationNumb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(new Regex("[0-9]").IsMatch(e.Text));
        }

        // Метод для валидации ввода только русских и латинских букв
        private void ValidationLet_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(new Regex("[А-ЯA-Zа-яa-z]").IsMatch(e.Text));
        }
    }
}
