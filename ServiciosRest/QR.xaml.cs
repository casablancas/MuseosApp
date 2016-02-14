using System;
using System.Windows.Threading;
using System.Windows.Navigation;
using System.Collections.ObjectModel;

using Microsoft.Devices;
using com.google.zxing;
using com.google.zxing.common;
using com.google.zxing.qrcode;

namespace ScannerDemo
{
    public partial class MainPage
    {
        private readonly DispatcherTimer _timer;
        private readonly ObservableCollection<string> _matches;

        private PhotoCameraLuminanceSource _luminance;
        private QRCodeReader _reader;
        private PhotoCamera _photoCamera;
        
        public MainPage()
        {            
            InitializeComponent();

            _matches = new ObservableCollection<string>();
            _matchesList.ItemsSource = _matches;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(250);
            _timer.Tick += (o, arg) => ScanPreviewBuffer();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _photoCamera = new PhotoCamera();
            _photoCamera.Initialized += OnPhotoCameraInitialized;            
            _previewVideo.SetSource(_photoCamera);

            CameraButtons.ShutterKeyHalfPressed += (o, arg) => _photoCamera.Focus();

            base.OnNavigatedTo(e);
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();
            NavigationService.Navigate(new Uri("/PivotPage2.xaml", UriKind.Relative));
        }

        private void OnPhotoCameraInitialized(object sender, CameraOperationCompletedEventArgs e)
        {
            int width = Convert.ToInt32(_photoCamera.PreviewResolution.Width);
            int height = Convert.ToInt32(_photoCamera.PreviewResolution.Height);
            
            _luminance = new PhotoCameraLuminanceSource(width, height);
            _reader = new QRCodeReader();

            Dispatcher.BeginInvoke(() => {
                _previewTransform.Rotation = _photoCamera.Orientation;
                _timer.Start();
            });
        }
 
        private void ScanPreviewBuffer()
        {
            try
            {
                lblQR.Text = "No se detecta código QR";
                _photoCamera.GetPreviewBufferY(_luminance.PreviewBufferY);
                var binarizer = new HybridBinarizer(_luminance);
                var binBitmap = new BinaryBitmap(binarizer);
                var result = _reader.decode(binBitmap);

                var scan = result.Text;
                lblQR.Text = "Escanea un código de Museos App";

                var textId = scan.Remove(0, 42);
                System.Diagnostics.Debug.WriteLine("ID DEL TEXTO: " + textId);
                var textQR = scan.Remove(42, 1);
                System.Diagnostics.Debug.WriteLine("TEXTO DEL QR: " + textQR);

                if (textQR.Equals("http://museosapp.azurewebsites.net/Piezas/"))
                {
                    lblQR.Text = "Código QR correcto";
                    NavigationService.Navigate(new Uri("/InfoQR.xaml?id=" + textId, UriKind.Relative));
                    _timer.Stop();
                }

                Dispatcher.BeginInvoke(() => DisplayResult(result.Text));
            }
            catch
            {
            }            
        }

        public void DisplayResult(string text)
        {
            //if(text.Equals(""))
            //lblQR.Text = "No se detecta código QR";

            if (!_matches.Contains(text))
            {
                //Muestra en pantalla el string que se ha escaneado
                //_matches.Add(text);
            }
            //else
                //lblQR.Text = "No se detecta código QR";

            /*if (text.Equals("http://museosapp.azurewebsites.net/Piezas/3"))
            {
                lblQR.Text = "Código QR correcto";
                NavigationService.Navigate(new Uri("/InfoQR.xaml?id=" + text, UriKind.Relative));
                _timer.Stop();
            }
            else
                lblQR.Text = "Escanea código de Museos";*/
        }
    }
}