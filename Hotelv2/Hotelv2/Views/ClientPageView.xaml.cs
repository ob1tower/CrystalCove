using Hotelv2.Data;
using Hotelv2.Models;
using Hotelv2.Services;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotelv2.Views
{
    public partial class ClientPageView : Page
    {
        public ClientPageView()
        {
            InitializeComponent();
            RefreshClientData();
        }

        // Метод для обновления данных клиента
        private void RefreshClientData()
        {
            ClientDataGrid.ItemsSource = ClientService.GetAllClient();
            UpdateClientCount();
        }

        // Обработчик события для кнопки добавления клиента
        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            var hotelHomeView = FindPerent<HotelHomeView>(this);
            hotelHomeView?.ShowOverlay(); 

            AddClientView addClientView = new AddClientView(ClientDataGrid);

            addClientView.ShowDialog();

            hotelHomeView?.HideOverlay();

            RefreshClientData();
        }

        // Метод для поиска родительского элемента определенного типа
        private static T FindPerent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject perentObject = VisualTreeHelper.GetParent(child);
            if(perentObject == null)
            {
                return null;
            }
            T perent = perentObject as T;
            return perent ?? FindPerent<T>(perentObject);
        }

        // Метод для обновления значения количества клиентов
        private void UpdateClientCount()
        {
            using (HotelDbContext hotelDbContext = new HotelDbContext())
            {
                // Получите количество клиентов из базы данных и обновите значение
                ClientCount.Text = hotelDbContext.Clients.Count().ToString();
            }
        }

        // Обработчик события изменения текста в поле фильтра
        private void Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Проверка на null перед установкой фильтра
            if (ClientDataGrid != null)
            {
                ClientDataGrid.Items.Filter = FilterMethod;
            }
        }

        // Метод для фильтрации записей в DataGrid
        private bool FilterMethod(object obj)
        {
            var client = (Client)obj;

            return client.FirstName.Contains(Filter.Text, StringComparison.OrdinalIgnoreCase) ||
                   client.LastName.Contains(Filter.Text, StringComparison.OrdinalIgnoreCase) ||
                   client.Patronymic.Contains(Filter.Text, StringComparison.OrdinalIgnoreCase);
        }

        // Обработчик события для кнопки обновления клиента
        private void UpdateClient_Click(object sender, RoutedEventArgs e)
        {
            var hotelHomeView = FindPerent<HotelHomeView>(this);
            hotelHomeView?.ShowOverlay();

            // Создаем экземпляр UpdateClientView и передаем выбранного клиента в конструктор
            UpdateClientView updateClientView = new UpdateClientView(ClientDataGrid);

            // Показываем окно
            updateClientView.ShowDialog();

            hotelHomeView?.HideOverlay();
        }

        // Обработчик события для кнопки удаления клиента
        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = ClientDataGrid.SelectedItem as Client;
            if (selectedClient != null)
            {
                ClientService.DeleteClient(selectedClient);
                RefreshClientData();
            }
        }
    }
}
