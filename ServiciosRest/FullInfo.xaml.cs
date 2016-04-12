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
using Microsoft.Phone.Tasks;
using Windows.Devices.Geolocation;
using System.Device.Location;
using Windows.Phone.Speech.Synthesis;
using Windows.System;

namespace ServiciosRest
{
    public partial class FullInfo : PhoneApplicationPage
    {
        private int audioCount = 0;
        private SpeechSynthesizer synth = new SpeechSynthesizer();

        public FullInfo()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Museo museo = NavigateServiceExtends.GetNavigationData(NavigationService) as Museo;
            if (museo != null)
            {
                //MessageBox.Show(museo.direccion);
            }

            //Ésta línea trae toda la información del museo que se ha seleccionado en otro xaml.
            // Y la muestra en el xaml actual.
            this.DataContext = museo;

            var lat = museo.latitud;
            var lon = museo.longitud;
            var fb = museo.facebook;
            var tw = museo.twitter;
            var ins = museo.instagram;
            var web = museo.web;
            var tel = museo.telefono;

            System.Diagnostics.Debug.WriteLine("TELEFONO: " + tel);

            if (tw.Equals(""))
            {
                //MessageBox.Show("El museo no tiene twitter");
                //canvasTwitter.Opacity = 0;
                canvasTwitter.Visibility = Visibility.Collapsed;
                //btnTwitter.Opacity = 0;
                btnTwitter.Visibility = Visibility.Collapsed;
            }
            else if (fb.Equals(""))
            {
                canvasFacebook.Visibility = Visibility.Collapsed;
                btnFacebook.Visibility = Visibility.Collapsed;
            }
            else if (web.Equals(""))
            {
                canvasWeb.Visibility = Visibility.Collapsed;
                btnWeb.Visibility = Visibility.Collapsed;
            }

            //MessageBox.Show("Se hace llamada al num "+museo.telefono);

            //horarios.ItemsSource = museo.horarios;
            //contenido.ItemsSource = museo.descripcionCorta;
        }

        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Canvas_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }

        private void TextBlock_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void btnLllamada_Click(object sender, RoutedEventArgs e)
        {
            Museo museo = NavigateServiceExtends.GetNavigationData(NavigationService) as Museo;
            this.DataContext = museo;
            var tel = museo.telefono;
            var nombre = museo.nombre;

            PhoneCallTask phoneCallTask = new PhoneCallTask();
            phoneCallTask.PhoneNumber = tel;
            phoneCallTask.DisplayName = nombre;
            phoneCallTask.Show();
        }

        private async void btnRuta_Click(object sender, RoutedEventArgs e)
        {
            Museo museo = NavigateServiceExtends.GetNavigationData(NavigationService) as Museo;
            this.DataContext = museo;
            var nombreMuseo = museo.nombre;
            var lat = museo.latitud;
            var lon = museo.longitud;
            double latitudMuseo;
            double longitudMuseo;
            latitudMuseo = Convert.ToDouble(lat);
            longitudMuseo = Convert.ToDouble(lon);

            var locator = new Geolocator();
            //MessageBox.Show("¿Está seguro de querer abrir Mapas?", "Cómo llegar.",MessageBoxButton.OKCancel);

            MessageBoxResult m = MessageBox.Show("Trazar una ruta a " + nombreMuseo, "¿Quieres saber cómo llegar?", MessageBoxButton.OKCancel);
            if (m == MessageBoxResult.Cancel)
            {

            }
            else
            {
                //MessageBox.Show("Data Deleted", "Done", MessageBoxButton.OK);
                String Latitud;
                String Longitud;

                if (!locator.LocationStatus.Equals(PositionStatus.Disabled))
                {
                    var position = await locator.GetGeopositionAsync();
                    Latitud = position.Coordinate.Point.Position.Latitude.ToString();
                    Longitud = position.Coordinate.Point.Position.Longitude.ToString();
                }

                else
                {
                    return;
                }

                double Latitud2 = Convert.ToDouble(Latitud);
                double Longitud2 = Convert.ToDouble(Longitud);

                BingMapsDirectionsTask bing = new BingMapsDirectionsTask()
                {
                    //Giving label and coordinates to starting and ending points. 

                    Start = new LabeledMapLocation("Tu posición actual", new GeoCoordinate(Latitud2, Longitud2)),
                    End = new LabeledMapLocation(nombreMuseo, new GeoCoordinate(latitudMuseo, longitudMuseo))
                };
                // Launching Bing Maps Direction Tasks
                bing.Show();
            }
        }

        private async void btnAudio_Click(object sender, RoutedEventArgs e)
        {
            Museo museo = NavigateServiceExtends.GetNavigationData(NavigationService) as Museo;
            this.DataContext = museo;
            var descripcion = museo.descripcionCorta;

            while (audioCount == 0)
            {
                audioCount = 1;
                await synth.SpeakTextAsync(descripcion);
                //if (audioCount == 1) { synth.CancelAll();break; }
            }
            audioCount = 0;
            //synth.CancelAll();
        }

        /*protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            synth.CancelAll();
            NavigationService.Navigate(new Uri("/PivotPage2.xaml", UriKind.Relative));
        }*/

        private async void btnWeb_Click(object sender, RoutedEventArgs e)
        {
            Museo museo = NavigateServiceExtends.GetNavigationData(NavigationService) as Museo;
            this.DataContext = museo;
            var web = museo.web;

            await Launcher.LaunchUriAsync(new Uri(web));
        }

        private async void btnFacebook_Click(object sender, RoutedEventArgs e)
        {
            Museo museo = NavigateServiceExtends.GetNavigationData(NavigationService) as Museo;
            this.DataContext = museo;
            var fbId = museo.facebookid;
            char[] chars = {'f','b',':','/','p','a','g','e'};
            var fb = fbId.TrimStart(chars);

            //TrimStart
            //Remueve caracteres del comienzo de un objeto de cadena existente
            /*string MyString = "Hello World!";
            char[] MyChar = { 'e', 'H', 'l', 'o', ' ' };
            string NewString = MyString.TrimStart(MyChar);
            Console.WriteLine(NewString);*/
            
            await Launcher.LaunchUriAsync(new Uri("fb:pages?id="+fb));
            //await Launcher.LaunchUriAsync(new Uri(fb));
        }

        private async void btnTwitter_Click(object sender, RoutedEventArgs e)
        {
            Museo museo = NavigateServiceExtends.GetNavigationData(NavigationService) as Museo;
            this.DataContext = museo;
            var twitter = museo.twitter;

            if (twitter != null)
            {
                //Console.WriteLine(twiter.Remove(0, 20));
                System.Diagnostics.Debug.WriteLine(twitter.Remove(0, 20));
                var twtt = twitter.Remove(0, 20);

                //await Launcher.LaunchUriAsync(new Uri("https://mobile.twitter.com/"+twtt));
                //MuseoTecdeMty
                await Launcher.LaunchUriAsync(new Uri("https://mobile.twitter.com/" + twtt));
            }
            else {
                //canvasTwitter.Opacity = 0;
                canvasTwitter.Visibility = Visibility.Collapsed;
                //btnTwitter.Opacity = 0;
                btnTwitter.Visibility = Visibility.Collapsed;
            }
        }
    }
}