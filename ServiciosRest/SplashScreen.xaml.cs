using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ServiciosRest
{
    public partial class SplashScreen : PhoneApplicationPage
    {
        public SplashScreen()
        {
            InitializeComponent();
            waitForSplash();
        }

        private async void waitForSplash()
        {
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(2500));
            NavigationService.Navigate(new Uri("/PivotPage2.xaml", UriKind.Relative));
        }
    }
}