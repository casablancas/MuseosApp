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
using System.Windows.Media;

namespace ServiciosRest
{
    public partial class PivotPage2 : PhoneApplicationPage
    {

        List<Museo> _museos;
        List<Museo> _temp;

        public PivotPage2()
        {
            InitializeComponent();
            /*
            PivotItem p = new PivotItem();
            Image i = new Image();

            i.Source = new BitmapImage(new Uri("/Assets/escanea.png", UriKind.Relative));
            p.Margin = new Thickness(0, -10, 0, -2);

            p.Content = i;
            PivotCategorias.Items.Add(p);
            */
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            museosArte();
            museosHistoria();
            museosInteractivos();
            appBar();
        }

        /*private void NavigateButtonClick(object sender, EventArgs e)
        {
            ApplicationBar = new ApplicationBar();

            ApplicationBar.Mode = ApplicationBarMode.Minimized;
            ApplicationBar.Opacity = 0.8;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;

            ApplicationBarIconButton button1 = new ApplicationBarIconButton();
            button1.IconUri = new Uri("/Assets/Logotipos/feature.camera.png", UriKind.Relative);
            button1.Text = "QR";
            ApplicationBar.Buttons.Add(button1);

            NavigationService.Navigate(new Uri("/QR.xaml", UriKind.Relative));
        }*/

        public void appBar()
        {
            ApplicationBar = new ApplicationBar();

            ApplicationBar.Mode = ApplicationBarMode.Minimized;
            ApplicationBar.Opacity = 0.8;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;
            ApplicationBar.BackgroundColor = Color.FromArgb(255, 8, 165, 196);
            //ApplicationBar.BackgroundColor = Colors.Blue;
            //ApplicationBar.BackgroundColor = SolidColorBrush(Colors.Blue);

            ApplicationBarIconButton buttonQR = new ApplicationBarIconButton();
            buttonQR.IconUri = new Uri("/Assets/Logotipos/Museos Archivos 01-14.png", UriKind.Relative);
            buttonQR.Text = "QR";
            buttonQR.Click += ButtonQR_Click;

            ApplicationBar.Buttons.Add(buttonQR);

            /*ApplicationBarMenuItem menuItem1 = new ApplicationBarMenuItem();
            menuItem1.Text = "menu item 1";
            ApplicationBar.MenuItems.Add(menuItem1);*/
        }

        private void ButtonQR_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            NavigationService.Navigate(new Uri("/QR.xaml", UriKind.Relative));
        }

        private async void museosArte()
        {
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(new Uri("http://museosapp.azurewebsites.net/museos"));
            _museos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Museo>>(json);
            _temp = new List<Museo>();
            var root = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Museo>>(json);
            int index = 0;

            foreach (var item in root)
            {
                if (item.categoria.Equals("arte"))
                {
                    _temp.Add(_museos.ElementAt(index));
                    System.Diagnostics.Debug.WriteLine(_museos.ElementAt(index).nombre);
                    System.Diagnostics.Debug.WriteLine(_museos.ElementAt(index).categoria);
                    System.Diagnostics.Debug.WriteLine("categoria: " + item.categoria);
                    System.Diagnostics.Debug.WriteLine("indice: " + index);
                }
                index++;
            }
            ElementosArte.ItemsSource = _temp;
            loadMuseosArte.Visibility = Visibility.Collapsed;
            //txtCargando.Visibility = Visibility.Collapsed;
        }

        private async void museosHistoria()
        {
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(new Uri("http://museosapp.azurewebsites.net/museos"));
            _museos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Museo>>(json);
            _temp = new List<Museo>();
            var root = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Museo>>(json);
            int index = 0;

            foreach (var item in root)
            {
                if (item.categoria.Equals("historia"))
                {
                    _temp.Add(_museos.ElementAt(index));
                    //System.Diagnostics.Debug.WriteLine(_museos.ElementAt(index).nombre);
                    //System.Diagnostics.Debug.WriteLine(_museos.ElementAt(index).categoria);
                    //System.Diagnostics.Debug.WriteLine("categoria: " + item.categoria);
                    //System.Diagnostics.Debug.WriteLine("indice: " + index);
                }
                index++;
            }

            ElementosHistoria.ItemsSource = _temp;
            loadMuseosHistoria.Visibility = Visibility.Collapsed;
        }

        private async void museosInteractivos()
        {
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(new Uri("http://museosapp.azurewebsites.net/museos"));
            _museos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Museo>>(json);
            _temp = new List<Museo>();
            var root = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Museo>>(json);
            int index = 0;

            var hora = DateTime.Now.ToString("hh:mm");

            foreach (var item in root)
            {
                if (item.categoria.Equals("interactivo"))
                {
                    System.Diagnostics.Debug.WriteLine("\nNombre: " + item.nombre);
                    System.Diagnostics.Debug.WriteLine("HORA: " + hora);
                    foreach (var horario in item.horarios)
                    {
                        //System.Diagnostics.Debug.WriteLine("Dias: " + horario.dia);
                        System.Diagnostics.Debug.WriteLine("Hora de apertura: " + horario.horaApertura);
                        double temp;
                        //temp = Convert.ToDouble(horario.horaApertura);
                        //System.Diagnostics.Debug.WriteLine("Conversion horario: " + temp);
                        //System.Diagnostics.Debug.WriteLine("Hora de cierre: " + horario.horaCierre);
                        //if (hora<horario.horaApertura)
                    }
                    _temp.Add(_museos.ElementAt(index));
                    //System.Diagnostics.Debug.WriteLine(_museos.ElementAt(index).nombre);
                    //System.Diagnostics.Debug.WriteLine(_museos.ElementAt(index).categoria);
                    //System.Diagnostics.Debug.WriteLine("categoria: " + item.categoria);
                    //System.Diagnostics.Debug.WriteLine("indice: " + index);
                }
                index++;
            }

            ElementosInteractivo.ItemsSource = _temp;
            loadMuseosInteractivo.Visibility = Visibility.Collapsed;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("¿Deseas salir?", "Cerrar la aplicación", MessageBoxButton.OKCancel);
            if (mbr == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
            if (mbr == MessageBoxResult.OK)
            {
                Application.Current.Terminate();
            }
        }

        private void Elementos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ElementosArte.SelectedItem != null)
            {
                Museo museo = (ElementosArte.SelectedItem as Museo);
                NavigateServiceExtends.Navigate(NavigationService, new Uri("/FullInfo.xaml", UriKind.RelativeOrAbsolute), museo);

            } else if (ElementosHistoria.SelectedItem != null)
            {
                Museo museo = (ElementosHistoria.SelectedItem as Museo);
                NavigateServiceExtends.Navigate(NavigationService, new Uri("/FullInfo.xaml", UriKind.RelativeOrAbsolute), museo);
            } else if (ElementosInteractivo.SelectedItem != null)
            {
                Museo museo = (ElementosInteractivo.SelectedItem as Museo);
                NavigateServiceExtends.Navigate(NavigationService, new Uri("/FullInfo.xaml", UriKind.RelativeOrAbsolute), museo);
            }
            /*else if (ElementosHistoria.SelectedItem != null)
            {
                Museo museoHistoria = (ElementosHistoria.SelectedItem as Museo);
                NavigateServiceExtends.Navigate(NavigationService, new Uri("/FullInfo.xaml", UriKind.RelativeOrAbsolute), museoHistoria);
            }*/

        }
    }
}