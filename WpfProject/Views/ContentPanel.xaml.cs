using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfProject.Models;

namespace WpfProject.Views
{
    /// <summary>
    /// Interaction logic for ContentPanel.xaml
    /// </summary>
    public partial class ContentPanel : Page
    {
        private List<Product> productsList;
       
        Service<Product> service = new Service<Product>();
        private MainWindow mainWindow;
        public ContentPanel(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        public async void Window_Loaded()
        {
            _Title.Text = "Vitrin Ürünleri";
            productsList = await service.GetJsonList("Products/ShowcaseProduct");
            foreach (var item in productsList)
            {

                item.Image = Helper.BaseUrl + "images?name=" + item.Image;

            }
            ProductMenu.ItemsSource = productsList;
            _Header.Visibility = Visibility.Hidden;
            _Header.Height = 0;
            //ChangeContent(new MainCategory());
        }

        private void StackPanel_MouseMove(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom("#018cd1");
            brush.Freeze();
            StackPanel stap = sender as StackPanel;
            stap.Background = brush;
            WrapPanel wp = stap.FindName("WrapProduct") as WrapPanel;
            wp.Background = brush;
            TextBlock tb = wp.FindName("xTextBlock") as TextBlock;
            tb.Foreground = Brushes.White;
            MaterialDesignThemes.Wpf.PackIcon icon = wp.FindName("xIcon") as MaterialDesignThemes.Wpf.PackIcon;
            icon.Foreground = Brushes.White;
        }
        private void ProductPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom("#018cd1");
            brush.Freeze();
            StackPanel stap = sender as StackPanel;
            stap.Background = Brushes.White;
            WrapPanel wp = stap.FindName("WrapProduct") as WrapPanel;
            wp.Background = Brushes.Transparent;
            TextBlock tb = wp.FindName("xTextBlock") as TextBlock;
            tb.Foreground = brush;
            MaterialDesignThemes.Wpf.PackIcon icon = wp.FindName("xIcon") as MaterialDesignThemes.Wpf.PackIcon;
            icon.Foreground = brush;
        }

        public async void ChangeContent(MainCategory main)
        {
            this.DataContext = null;
            ProductMenu.ItemsSource = null;
            _Title.Text = main.Name;
            productsList = await service.GetJsonList("products/Maincategory", main.Id);
            Update(productsList);
            _Header.Visibility = Visibility.Visible;
            _Header.Height = 65;
        }

        public async void ChangeContent(SubCategory1 sub1)
        {
            this.DataContext = null;
            ProductMenu.ItemsSource = null;
            _Title.Text = sub1.Name;
            productsList = await service.GetJsonList("products", sub1.MainCategoryId, sub1.Id);
            Update(productsList);
            _Header.Visibility = Visibility.Visible;
            _Header.Height = 65;
        }

        public async void ChangeContent(SubCategory2 sub2)
        {
            this.DataContext = null;
            ProductMenu.ItemsSource = null;
            _Title.Text = sub2.Name;
            productsList = await service.GetJsonList("products", 0, sub2.SubCategory1Id, sub2.Id);
            Update(productsList);
            _Header.Visibility = Visibility.Visible;
            _Header.Height = 65;
        }

        private void Update(List<Product> productsList)
        {

            if (productsList.Count == 0)
            {
                _Title.Text += "    --Sonuç Bulunamadı--";
            }
            foreach (var item in productsList)
            {
                item.Image = Helper.BaseUrl + "images?name=" + item.Image;

            }
            ProductMenu.ItemsSource = productsList;
        }

        private void StackPanel_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement fe = e.OriginalSource as FrameworkElement;
            Product product = fe.DataContext as Product;
            mainWindow.ChangeContent(product.Id);
          
        }
        private static T FindVisualChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            if (parent == null)
                return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                T childType = child as T;
                if (childType == null)
                {
                    foundChild = FindVisualChild<T>(child, childName);

                    if (foundChild != null)
                        break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    FrameworkElement frameworkElement = child as FrameworkElement;
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (e.AddedItems[0] as ComboBoxItem).Content as string;

            switch (text)
            {
                case "Varsayılan Sıralama":
                    //Update(productsList);
                    break;

                case "Alfabetik A-Z":
                    ProductMenu.ItemsSource = productsList.OrderBy(x => x.Title).ToList();
                    break;
                case "Alfabetik Z-A":
                    ProductMenu.ItemsSource = productsList.OrderByDescending(x => x.Title).ToList();
                    break;

                case "Yeniden Eskiye":
                    ProductMenu.ItemsSource = productsList.OrderBy(x => x.Description).ToList();
                    break;
                case "Eskiden Yeniye":
                    ProductMenu.ItemsSource = productsList.OrderByDescending(x => x.Description).ToList();
                    break;

                case "Fiyat Artan":
                    ProductMenu.ItemsSource = productsList.OrderBy(x => x.Price).ToList();
                    break;
                case "Fiyat Azalan":
                    ProductMenu.ItemsSource = productsList.OrderByDescending(x => x.Price).ToList();
                    break;

                case "Rastgele":
                    ProductMenu.ItemsSource = productsList.OrderBy(x => x.Origin).ToList();
                    break;
                case "Puana Göre":
                    ProductMenu.ItemsSource = productsList.OrderByDescending(x => x.StockCode).ToList();
                    break;


            }
          
        }
        public void OrderByLowPrice(int value)
        {
            ProductMenu.ItemsSource = productsList.Where(x => x.Price > value).ToList();
        }

        public void OrderByUpperPrice(int value)
        {
            ProductMenu.ItemsSource = productsList.Where(x => x.Price < value).ToList();
        }

        public void OrderByBrand(string text)
        {
            switch (text)
            {
                case "Tüm Markalar":
                    //Update(productsList);
                    break;

                case "Adafruit":
                    ProductMenu.ItemsSource = productsList.Where(x => x.Id <= 5).ToList();
                    break;
                case "China":
                    ProductMenu.ItemsSource = productsList.Where(x => x.Id > 5 && x.Id <= 10).ToList();
                    break;

                case "DFRobot":
                    ProductMenu.ItemsSource = productsList.Where(x => x.Id > 10 && x.Id <= 15).ToList();
                    break;
                case "Espressif":
                    ProductMenu.ItemsSource = productsList.Where(x => x.Id > 15 && x.Id <= 20).ToList();
                    break;

                case "Itead":
                    ProductMenu.ItemsSource = productsList.Where(x => x.Id > 20 && x.Id <= 25).ToList();
                    break;
                case "RAK":
                    ProductMenu.ItemsSource = productsList.Where(x => x.Id > 25 && x.Id <= 30).ToList();
                    break;

                case "SeeedStudio":
                    ProductMenu.ItemsSource = productsList.Where(x => x.Id > 30 && x.Id <= 35).ToList();
                    break;
                case "Türkiye":
                    ProductMenu.ItemsSource = productsList.Where(x => x.Id > 35 && x.Id <= 40).ToList();
                    break;

                case "WaveShare":
                    ProductMenu.ItemsSource = productsList.Where(x => x.Id > 40 && x.Id <= 45).ToList();
                    break;
            }
        }
    }
}
