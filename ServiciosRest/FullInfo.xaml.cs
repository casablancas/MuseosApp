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

namespace ServiciosRest
{
    public partial class FullInfo : PhoneApplicationPage
    {
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

            this.DataContext = museo;
            //horarios.ItemsSource = museo.horarios;
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
    }
}