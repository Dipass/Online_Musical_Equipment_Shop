using Newtonsoft.Json;
using Online_Musical_Equipment_Shop_BLL.DTOs.RequestsDTOs;
using Online_Musical_Equipment_Shop_BLL.DTOs.ResponseDTOs;
using Online_Musical_Equipment_Shop_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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

namespace Online_Musical_Equipment_Shop_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient client = new HttpClient();
        
        public ObservableCollection<GetInstrumentsDTO> Instruments { get; set; } = new ObservableCollection<GetInstrumentsDTO>();

        public MainWindow()
        {
            client.BaseAddress = new Uri("https://localhost:7284/api/instruments/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();

            DataContext = this;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton is MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void Button_Click_Save(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

        private async void Button_Click_Load_all_Instruments(object sender, RoutedEventArgs e) => await this.GetAllInstrumentsAsync();
                
        private void Button_Click_Open_Menu_Insert(object sender, RoutedEventArgs e) => menuinsert.Visibility = Visibility.Visible;
        private async void Button_Click_Add_New_Instrument(object sender, RoutedEventArgs e) => await this.InsertNewInstrumentAsync();
        private void Button_Click_Close_Menu_Insert(object sender, RoutedEventArgs e) => menuinsert.Visibility = Visibility.Hidden;
        private async void Button_Click_Remove(object sender, RoutedEventArgs e) => await DeleteInstrumentAsync();
        private async void Button_Click_Edit(object sender, RoutedEventArgs e) => await UpdateInstrumentAsync();



        private async Task GetAllInstrumentsAsync()
        {
            var response = await client.GetStringAsync("Return_all_Instruments");
            var instruments = JsonConvert.DeserializeObject<IEnumerable<GetInstrumentsDTO>>(response);

            Instruments.Clear();
            foreach (var instrument in instruments)
            {
                Instruments.Add(instrument);
            }
        }
        private async Task InsertNewInstrumentAsync()
        {

            InsertInstrumentsDTO instrument = new InsertInstrumentsDTO
            {
                InstrumentTitle = textTitle.Text,
                Description = textDescription.Text,
                ManufacturerId = instrumentsDataGrid.ItemsSource.Cast<GetInstrumentsDTO>().FirstOrDefault().ManufacturerId,
                CategoriesId = instrumentsDataGrid.ItemsSource.Cast<GetInstrumentsDTO>().FirstOrDefault().CategoriesId
            };

            await client.PostAsJsonAsync("Insert_Instrument_to_Database", instrument);
        }
        private async Task UpdateInstrumentAsync() 
        {
            UpdateInstrumentsDTO instrument = new UpdateInstrumentsDTO
            {
                Id= (instrumentsDataGrid.SelectedItem as GetInstrumentsDTO).Id,
                InstrumentTitle = textTitle.Text,
                Description = textDescription.Text,
                ManufacturerId = (instrumentsDataGrid.SelectedItem as GetInstrumentsDTO).ManufacturerId,
                CategoriesId = (instrumentsDataGrid.SelectedItem as GetInstrumentsDTO).CategoriesId
            };

            await client.PutAsJsonAsync("Update_Instrument_by_Id", instrument);
        }
        private async Task DeleteInstrumentAsync() {
            Guid id = (instrumentsDataGrid.SelectedItem as GetInstrumentsDTO).Id;
            await client.DeleteAsync($"Delete_Instrument/{id}");
        }

        private void instrumentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
