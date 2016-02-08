using ServiciosRest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace XAML
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        List<Museo> _museos;

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(new Uri("http://museosapp.azurewebsites.net/museos"));
            _museos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Museo>>(json);
            Elementos.ItemsSource = _museos;
            loadMuseos.Visibility = Visibility.Collapsed;
        }

        private void Elementos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Elementos.SelectedItem != null)
            {
                Museo museo = (Elementos.SelectedItem as Museo);
                Frame.Navigate(typeof(FullInfo), museo);
            }
        }
    }
}
