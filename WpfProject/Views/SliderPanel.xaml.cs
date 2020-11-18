using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
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
using System.Windows.Threading;
using WpfProject.Models;

namespace WpfProject.View
{
    /// <summary>
    /// Slider.xaml etkileşim mantığı
    /// </summary>
    public partial class SliderPanel : Page
    {
        DispatcherTimer timer;
        private Service<Models.Slider> service = new Service<Models.Slider>();
        int ctr = 0;
        private List<Models.Slider> sliders;
        private Image[] imgs = new Image[8];
        public SliderPanel()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 4);
            timer.Tick += new EventHandler(timer_Tick);
        }
        void timer_Tick(object sender, EventArgs e)
        {
            ctr++;
            if (ctr > 7)
            {
                ctr = 0;
            }
            PlaySlideShow(ctr);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {     
            ctr = 0;
            timer.IsEnabled = true;
            sliders = await service.GetJsonList("Sliders");        
            PlaySlideShow(ctr);
        }
        private async void PlaySlideShow(int ctr)
        {
            //Byte[] img = null;
            //string url = Helper.BaseUrl + "images?name=" + sliders[ctr].ImagePath;
            //try
            //{
            //    HttpClientHandler clientHandler = new HttpClientHandler();
            //    clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            //    using (HttpClient client = new HttpClient(clientHandler))
            //    {
            //        using (HttpResponseMessage res = await client.GetAsync(url))
            //        {
            //            using (HttpContent content = res.Content)
            //            {
            //                img = await content.ReadAsByteArrayAsync();
            //            }
            //        }
            //    }
            //}
            //catch (Exception exception)
            //{
            //    throw exception;
            //}

            //using (var ms = new System.IO.MemoryStream(img))
            //{
            //    var image = new BitmapImage();
            //    image.BeginInit();
            //    image.CacheOption = BitmapCacheOption.OnLoad; // here
            //    image.StreamSource = ms;
            //    image.EndInit();
            //    myImage.Source = image;
            //    myImage.Stretch = Stretch.Uniform;
            //}

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(Helper.BaseUrl + "images?name=" + sliders[ctr].ImagePath);
            //image.StreamSource = img;
            image.EndInit();
            myImage.Source = image;
            myImage.Stretch = Stretch.Uniform;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            ctr++;
            if (ctr > 7)
            {
                ctr = 0;
            }
            PlaySlideShow(ctr);
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            ctr--;
            if (ctr < 0)
            {
                ctr = 7;
            }
            PlaySlideShow(ctr);
        }

        private void chkAutoPlay_Click(object sender, RoutedEventArgs e)
        {
            //btnFirst.Visibility = (btnFirst.IsVisible == true) ? Visibility.Hidden : Visibility.Visible;
            //btnPrevious.Visibility = (btnPrevious.IsVisible == true) ? Visibility.Hidden : Visibility.Visible;
            //btnNext.Visibility = (btnNext.IsVisible == true) ? Visibility.Hidden : Visibility.Visible;
            //btnLast.Visibility = (btnLast.IsVisible == true) ? Visibility.Hidden : Visibility.Visible;
        }    
    }
}
