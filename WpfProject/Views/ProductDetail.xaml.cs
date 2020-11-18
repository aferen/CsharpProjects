using System;
using System.Collections.Generic;
using System.Text;
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

namespace WpfProject.Views
{
    /// <summary>
    /// Interaction logic for ProductDetail.xaml
    /// </summary>
    public partial class ProductDetail : Page
    {
        public static List<Product> productsList = new List<Product>();
        private Product products;
        private List<Comment> comments;
        Service<Product> service = new Service<Product>();
        Service<MainCategory> service2 = new Service<MainCategory>();
        Service<List<Comment>> service3 = new Service<List<Comment>>();
        private Navbar navbar;
        private int? id;
        public ProductDetail(Navbar navbar,int? id)
        {
            InitializeComponent();
            this.id = id;
            this.navbar = navbar;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        { 
            products = await service.GetJson("Products", id);
            products.Image = Helper.BaseUrl + "images?name=" + products.Image;
            decimal price = Convert.ToDecimal(products.Price);
            products.NewPrice = price + (price * 18 / 100);
            products.NewPrice = Math.Round(products.NewPrice, 2);
            _Title.Text = "Ana Sayfa > ";
            if (products.CategoryId <= 10)
            {
                MainCategory main = await service2.GetJson("Categories", products.CategoryId);
                _Title.Text += main.Name;
            }
            
            comments = await service3.GetJson("Comments", products.Id);
            products.CommentCount = comments.Count;
            Comment.ItemsSource = comments;
            this.DataContext = products;
        }

        private void Button_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int cnt = Convert.ToInt32(Cnt.Content);
            if (cnt > 1)
            {
                Cnt.Content = (Convert.ToInt32(Cnt.Content) - 1).ToString();
            }
        }

        private void Button_PreviewMouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Cnt.Content = (Convert.ToInt32(Cnt.Content) + 1).ToString();
        }

        private void Button_PreviewMouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            int cnt = Convert.ToInt32(Cnt.Content);
            products.CountProduct = cnt;
            products.TotalPrice = products.NewPrice * cnt;
            productsList.Add(products);
            navbar.UpdateCost(productsList);
        }
    }
}
