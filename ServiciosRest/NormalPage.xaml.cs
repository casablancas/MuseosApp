using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DevelopersAzteca;
using Windows.Web.Http;

namespace ServiciosRest
{
    public partial class NormalPage : PhoneApplicationPage
    {
        List<Museo> _museos;

        public NormalPage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(new Uri("http://museosapp.azurewebsites.net/museos"));
            _museos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Museo>>(json);
            Elementos.ItemsSource = _museos;
            loadMuseos.Visibility = Visibility.Collapsed;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Deseas salir", "", MessageBoxButton.OKCancel);
            if (mbr == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void Elementos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Elementos.SelectedItem != null)
            {
                Museo museo = (Elementos.SelectedItem as Museo);
                NavigateServiceExtends.Navigate(NavigationService, new Uri("/FullInfo.xaml", UriKind.RelativeOrAbsolute), museo);
            }
        }
    }
}