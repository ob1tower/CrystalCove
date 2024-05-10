using Hotelv2.Data;
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
    public partial class UpdateClientView : Window
    {
        public DataGrid ClientDataGrid {  get; } 
        public UpdateClientView(DataGrid clientDataGrid)
        {
            InitializeComponent();
            ClientDataGrid = clientDataGrid;
        }

        // Обработчик нажатия на кнопку сохранения изменений клиента
        private void SaveClient_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на заполненность всех полей
            if (FirstName.Text != string.Empty && LastName.Text != string.Empty &&
               Patronymic.Text != string.Empty && PassportNumber.Text != string.Empty &&
               PhoneNumber.Text != string.Empty)
            {
                // Проверка длины номера паспорта
                if (PassportNumber.Text.Length == 10)
                {
                    // Проверка длины номера телефона
                    if (PhoneNumber.Text.Length == 11)
                    {
                        // Вызов метода обновления клиента
                        ClientService.UpdateClient(FirstName.Text, 
                                                   LastName.Text, 
                                                   Patronymic.Text, 
                                                   PassportNumber.Text, 
                                                   PhoneNumber.Text, 
                                                   Email.Text, 
                                                   ClientDataGrid.SelectedItem as Client);

                        MessageBox.Show("Клиент успешно обновлен!", "Информация",
                                        MessageBoxButton.OK, MessageBoxImage.Information);
                        ClientDataGrid.ItemsSource = ClientService.GetAllClient();
                        Close();
                    }
                    else
                        MessageBox.Show("Пожалуйста, введите корректный номер телефона!", "Ошибка",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("Пожалуйста, введите корректный номер паспорта!", "Ошибка",
                     MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Пожалуйста, введите все данные.", "Ошибка",
                 MessageBoxButton.OK, MessageBoxImage.Error);
        }

        // Обработчик нажатия на кнопку закрытия окна
        private void CloseClient_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Метод для валидации ввода только русских и латинских букв
        private void ValidationLet_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(new Regex("[А-ЯA-Zа-яa-z]").IsMatch(e.Text));
        }

        // Метод для валидации ввода только цифр
        private void ValidationNumb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(new Regex("[0-9]").IsMatch(e.Text));
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
