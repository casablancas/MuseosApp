using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Web.Http;
using DevelopersAzteca;
using Windows.Phone.Speech.Synthesis;

namespace ServiciosRest
{
    public partial class InfoQR : PhoneApplicationPage
    {
        List<Piezas> _piezas;

        public InfoQR()
        {
            InitializeComponent();
            //muestraInfoQR();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //string id = "";
            string id = string.Empty;
            if (NavigationContext.QueryString.TryGetValue("id", out id))
            {
                System.Diagnostics.Debug.WriteLine("ID de la pieza: " + id);
            }

            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(new Uri("http://museosapp.azurewebsites.net/Piezas/"+id));
            _piezas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Piezas>>(json);

            //Piezas piezas = NavigateServiceExtends.GetNavigationData(NavigationService) as Piezas;



            //System.Diagnostics.Debug.WriteLine("PIEZAAAAAAA: " + piezas.descripcion);
            //piezas.descripcion;
            //Ésta línea trae toda la información del museo que se ha seleccionado en otro xaml.
            // Y la muestra en el xaml actual.


            //this.DataContext = piezas;

            ElementosQR.ItemsSource = _piezas;
            loadPieza.Visibility = Visibility.Collapsed;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            //_timer.Stop();
            NavigationService.Navigate(new Uri("/QR.xaml", UriKind.Relative));
        }

        public async void muestraInfoQR()
        {
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(new Uri("http://museosapp.azurewebsites.net/Piezas/2"));
            _piezas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Piezas>>(json);

            //Piezas piezas = NavigateServiceExtends.GetNavigationData(NavigationService) as Piezas;



            //System.Diagnostics.Debug.WriteLine("PIEZAAAAAAA: " + piezas.descripcion);
            //piezas.descripcion;
            //Ésta línea trae toda la información del museo que se ha seleccionado en otro xaml.
            // Y la muestra en el xaml actual.


            //this.DataContext = piezas;

            ElementosQR.ItemsSource = _piezas;
            loadPieza.Visibility = Visibility.Collapsed;
        }

        private async void btnAudio_Click(object sender, RoutedEventArgs e)
        {
            Piezas pieza = NavigateServiceExtends.GetNavigationData(NavigationService) as Piezas;
            //this.DataContext = museo;
            //var descripcion = pieza.descripcion;

            string id = string.Empty;
            if (NavigationContext.QueryString.TryGetValue("id", out id))
            {
                System.Diagnostics.Debug.WriteLine("ID de la pieza: " + id);
            }

            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(new Uri("http://museosapp.azurewebsites.net/Piezas/"+id));
            _piezas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Piezas>>(json);
            //_temp = new List<Museo>();
            var root = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Piezas>>(json);
            int index = 0;

            foreach (var item in root)
            {
                /*if (item.categoria.Equals("arte"))
                {
                    _temp.Add(_museos.ElementAt(index));
                    System.Diagnostics.Debug.WriteLine(_museos.ElementAt(index).nombre);
                    System.Diagnostics.Debug.WriteLine(_museos.ElementAt(index).categoria);
                    System.Diagnostics.Debug.WriteLine("categoria: " + item.categoria);
                    System.Diagnostics.Debug.WriteLine("indice: " + index);
                }*/
                var descripcion = item.descripcion;
                System.Diagnostics.Debug.WriteLine("DESCRIPCION PIEZA: " + descripcion);
                SpeechSynthesizer synth = new SpeechSynthesizer();
                await synth.SpeakTextAsync(descripcion);
                index++;
            } 
        }

        private void btnWeb_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFacebook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTwitter_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}