using Hotelv2.Data;
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
    public partial class AddRoomView : Window
    {
        public DataGrid RoomDataGrid { get; }

        public AddRoomView(DataGrid roomDataGrid)
        {
            InitializeComponent();
            RoomDataGrid = roomDataGrid;
        }

        // Обработчик события для кнопки добавления комнаты
        private void OkRoom_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на заполненность всех полей
            if (NumberRoom.Text != string.Empty && Floor.Text != string.Empty &&
                Category.Text != string.Empty && NumberSeats.Text != string.Empty &&
                Price.Text != string.Empty)
            {
                // Проверяем, не существует ли уже комната с таким номером
                if (!RoomService.GetAllRoom().Any(room => room.NumberRoom == int.Parse(NumberRoom.Text)))
                {
                    // Создаем комнату, если все поля заполнены
                    RoomService.CreateRoom(int.Parse(NumberRoom.Text),
                                           Category.Text,
                                           int.Parse(Floor.Text),
                                           int.Parse(NumberSeats.Text),
                                           decimal.Parse(Price.Text));

                    RoomDataGrid.ItemsSource = RoomService.GetAllRoom();
                    MessageBox.Show("Комната успешно добавлена!", "Успех",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                    MessageBox.Show("Комната с таким номером уже существует!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }
            else
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
        }

        // Обработчик события для кнопки отмены
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
