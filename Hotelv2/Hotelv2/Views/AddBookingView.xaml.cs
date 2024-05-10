using Hotelv2.Data;
using Hotelv2.Models;
using Hotelv2.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
    public partial class AddBookingView : Window
    {
        public DataGrid BookingDataGrid { get; } // DataGrid для отображения бронирований
        private readonly Staff currentStaff; // Текущий сотрудник
        private Client currentClient; // Текущий клиент

        public AddBookingView(DataGrid bookingDataGrid, Staff staff, Client client)
        {
            InitializeComponent();
            BookingDataGrid = bookingDataGrid;
            currentStaff = staff;
            currentClient = client;
            LoadClientRoom();
        }

        // Обработчик события изменения выбора клиента в списке
        private void ClientId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получаем выбранное Имя клиента
            string selectedClientName = ClientId.SelectedItem as string;

            // Если Имя клиента не пустое
            if (!string.IsNullOrEmpty(selectedClientName))
            {
                // Выполняем запрос на стороне клиента для получения клиента по имени
                using (var dbContext = new HotelDbContext())
                {
                    currentClient = dbContext.Clients.AsEnumerable().FirstOrDefault(c => c.FullName == selectedClientName);
                }
            }
        }

        // Метод для загрузки списка клиентов и номеров комнат
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

            using (var dbContext = new HotelDbContext())
            {
                RoomId.FilterMode = AutoCompleteFilterMode.Contains;
                var roomNumbers = dbContext.Rooms.Select(r => r.NumberRoom.ToString()).ToList();
                RoomId.ItemsSource = roomNumbers;
            }
        }

        // Обработчик события нажатия кнопки для добавления бронирования
        private void OkBooking_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на заполненность всех полей
            if (BookingDate.SelectedDate != null && CheckIn.SelectedDate != null && CheckOut.SelectedDate != null &&
                !string.IsNullOrEmpty(currentClient.FullName) && !string.IsNullOrEmpty(currentStaff.FullName) &&
                !string.IsNullOrEmpty(RoomId.Text))
            {
                using (var dbContext = new HotelDbContext())
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

                    // Вызываем метод для создания бронирования
                    if (BookingService.CreateBooking(
                        bookingDateTime,
                        checkInDateTime,
                        checkOutDateTime,
                        currentClient.FullName,
                        currentStaff.FullName,
                        int.Parse(RoomId.Text)))
                    {
                        MessageBox.Show("Бронирование успешно добавлено!", "Успех",
                                        MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadClientRoom();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Комната уже забронирована или не найдена!", "Ошибка",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else MessageBox.Show("Пожалуйста, введите все данные.", "Ошибка",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
        }

        // Обработчик события нажатия кнопки "Отмена"
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
    }
}
