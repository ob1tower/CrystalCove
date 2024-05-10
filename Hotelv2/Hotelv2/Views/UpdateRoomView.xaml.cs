using Hotelv2.Models;
using Hotelv2.Services;
using System;
using System.Collections.Generic;
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
    public partial class UpdateRoomView : Window
    {
        public DataGrid RoomDataGrid { get; }
        public UpdateRoomView(DataGrid roomDataGrid)
        {
            InitializeComponent();
            RoomDataGrid = roomDataGrid;
        }

        // Обработчик нажатия на кнопку сохранения изменений комнаты
        private void SaveRoom_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на заполненность всех полей
            if (NumberRoom.Text != string.Empty && Floor.Text != string.Empty &&
                Category.Text != string.Empty && NumberSeats.Text != string.Empty &&
                Price.Text != string.Empty)
            {
                // Вызов метода обновления клиента
                RoomService.UpdateRoom(int.Parse(NumberRoom.Text),
                                       Category.Text,
                                       int.Parse(Floor.Text),
                                       int.Parse(NumberSeats.Text),
                                       decimal.Parse(Price.Text),
                                       RoomDataGrid.SelectedItem as Room);

                MessageBox.Show("Комната успешно обновлен!", "Информация",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                RoomDataGrid.ItemsSource = RoomService.GetAllRoom();
                Close();
            }
            else MessageBox.Show("Пожалуйста, введите все данные.", "Ошибка",
                 MessageBoxButton.OK, MessageBoxImage.Error);
        }

        // Обработчик нажатия на кнопку отмены
        private void CloseRoom_Click(object sender, RoutedEventArgs e)
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
    }
}
