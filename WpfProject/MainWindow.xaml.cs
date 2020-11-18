using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
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
using WpfProject.Models;
using WpfProject.View;
using WpfProject.Views;

namespace WpfProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<MainCategory> categories;
        private ProductDetail detail;
        private About about;
        private ContentPanel content;
        private Login login;
        private ProductInCase productCase;
        private List<Currency> currency;
        private Navbar navbar;
        int lowerValue = 1;
        int upperValue = 1500;
        Service<Models.MainCategory> service = new Service<Models.MainCategory>();
        Service<Models.Currency> service2 = new Service<Models.Currency>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            navbar = new Navbar(this);
            View.SliderPanel slider = new View.SliderPanel();
            content = new ContentPanel(this);
            login = new Login();
            productCase = new ProductInCase(navbar);
            content.Window_Loaded();
            categories = await service.GetJsonList("Categories");
            currency = await service2.GetJsonList("Currencies");
            currency.Remove(currency.FirstOrDefault());
            Currencies.ItemsSource = currency;
            foreach (var item in categories)
            {
                Menu.Children.Add(new UserControlMenuItem(item, this));
            }
            navbarframe.NavigationService.Navigate(navbar);
            sliderframe.NavigationService.Navigate(slider);
            contentframe.NavigationService.Navigate(content);
            Filters.Visibility = Visibility.Collapsed;
        }

        private void AboutButton_MouseMove(object sender, MouseEventArgs e)
        {
            AboutButton.Foreground = Brushes.Black;
            AboutButton.Background = Brushes.Transparent;
        }

        private void AboutButton_MouseLeave(object sender, MouseEventArgs e)
        {
            AboutButton.Foreground = Brushes.White;
            AboutButton.Background = Brushes.Transparent;
        }

        public async void ChangeContent(bool state, int type)
        {
            if (type == 1)
            {
                contentframe.NavigationService.Navigate(content);
                content.Window_Loaded();
                LeftImages.Visibility = Visibility.Visible;
                sliderframe.Visibility = Visibility.Visible;
                sliderframe.Height = 400;
                _ScrollViewer.ScrollToTop();
                _MenuScroll.ScrollToTop();
                LeftImages.Height = 1400;
                Filters.Visibility = Visibility.Collapsed;
            }
            else if (type == 2)
            {
                contentframe.NavigationService.Navigate(login);
                content.Window_Loaded();
                LeftImages.Visibility = Visibility.Hidden;
                sliderframe.Visibility = Visibility.Hidden;
                sliderframe.Height = 0;
                _ScrollViewer.ScrollToTop();
                _MenuScroll.ScrollToTop();
                LeftImages.Height = 0;
                Filters.Visibility = Visibility.Collapsed;
            }
            else if (type == 3)
            {
                contentframe.NavigationService.Navigate(productCase);
                content.Window_Loaded();
                LeftImages.Visibility = Visibility.Hidden;
                sliderframe.Visibility = Visibility.Hidden;
                sliderframe.Height = 0;
                _ScrollViewer.ScrollToTop();
                _MenuScroll.ScrollToTop();
                LeftImages.Height = 0;
                Filters.Visibility = Visibility.Collapsed;
            }
        }

        public async void ChangeContent(int? id)
        {
            detail = new ProductDetail(navbar, id);
            contentframe.NavigationService.Navigate(detail);
            LeftImages.Visibility = Visibility.Hidden;
            sliderframe.Visibility = Visibility.Hidden;
            sliderframe.Height = 0;
            _ScrollViewer.ScrollToTop();
            _MenuScroll.ScrollToTop();
            LeftImages.Height = 0;
            Filters.Visibility = Visibility.Collapsed;
        }

        public async void ChangeContent(MainCategory main)
        {
            contentframe.NavigationService.Navigate(content);
            content.ChangeContent(main);
            LeftImages.Visibility = Visibility.Hidden;
            sliderframe.Visibility = Visibility.Hidden;
            sliderframe.Height = 0;
            _ScrollViewer.ScrollToTop();
            _MenuScroll.ScrollToTop();
            LeftImages.Height = 0;
            Filters.Visibility = Visibility.Visible;
        }

        public async void ChangeContent(SubCategory1 sub1)
        {
            contentframe.NavigationService.Navigate(content);
            content.ChangeContent(sub1);
            LeftImages.Visibility = Visibility.Hidden;
            sliderframe.Visibility = Visibility.Hidden;
            sliderframe.Height = 0;
            _ScrollViewer.ScrollToTop();
            _MenuScroll.ScrollToTop();
            LeftImages.Height = 0;
            Filters.Visibility = Visibility.Visible;
        }

        public async void ChangeContent(SubCategory2 sub2)
        {
            contentframe.NavigationService.Navigate(content);
            content.ChangeContent(sub2);
            LeftImages.Visibility = Visibility.Hidden;
            sliderframe.Visibility = Visibility.Hidden;
            sliderframe.Height = 0;
            _ScrollViewer.ScrollToTop();
            _MenuScroll.ScrollToTop();
            LeftImages.Height = 0;
            Filters.Visibility = Visibility.Visible;
        }

        private void AboutButton_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            about = new About();
            contentframe.NavigationService.Navigate(about);
            LeftImages.Visibility = Visibility.Hidden;
            sliderframe.Visibility = Visibility.Hidden;
            sliderframe.Height = 0;
            _ScrollViewer.ScrollToTop();
            _MenuScroll.ScrollToTop();
            LeftImages.Height = 0;
            Filters.Visibility = Visibility.Collapsed;
        }

        private void RangeSlider_LowerThumbDragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            var thump = e.OriginalSource as MahApps.Metro.Controls.MetroThumb;
            var range = thump.TemplatedParent as MahApps.Metro.Controls.RangeSlider;
            lowerValue = Convert.ToInt32(range.LowerValue);
            PriceTitle.Text = $"{lowerValue} TL - {upperValue} TL";
            content.OrderByLowPrice(lowerValue);
        }

        private void RangeSlider_UpperThumbDragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            //var thump = e.OriginalSource as MahApps.Metro.Controls.MetroThumb;
            //var range = thump.TemplatedParent as MahApps.Metro.Controls.RangeSlider;
            //upperValue = Convert.ToInt32(range.UpperValue);
            //PriceTitle.Text = $"{lowerValue} TL - {upperValue} TL";
            //content.OrderByUpperPrice(upperValue);

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (e.AddedItems[0] as ComboBoxItem).Content as string;

            if (text != null)
            {
                content.OrderByBrand(text);

            }


        }
    }
}
