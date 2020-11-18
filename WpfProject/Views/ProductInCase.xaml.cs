using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for ProductInCase.xaml
    /// </summary>
    public partial class ProductInCase : Page
    {
        private Navbar navbar;
        public ProductInCase(Navbar navbar)
        {
            InitializeComponent();
            this.navbar = navbar;
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //ProductDetail.productsList = ProductDetail.productsList.GroupBy(x => new {
            //   x.Id, x.Image, x.IsActive, x.IsShowcaseProduct, x.Name, x.NewPrice, x.Origin, x.Price, x.Property, x.StockCode, x.SubCategory1Id, x.SubCategory2Id, x.Title, x.TotalPrice, x.CategoryId, x.CommentCount, x.Description, x.CountProduct }
            //).Select(x => new Product { CategoryId = x.Key.CategoryId, CommentCount = x.Key.CommentCount, CountProduct = x.Sum(k => k.CountProduct), Description = x.Key.Description,  Image = x.Key.Image, Id = x.Key.Id, IsActive = x.Key.IsActive, IsShowcaseProduct = x.Key.IsShowcaseProduct, Name = x.Key.Name, NewPrice = x.Key.NewPrice, Origin = x.Key.Origin, Price = x.Key.Price, Property = x.Key.Property, StockCode = x.Key.StockCode, SubCategory1Id = x.Key.SubCategory1Id, SubCategory2Id = x.Key.SubCategory2Id, Title = x.Key.Title, TotalPrice = x.Sum(f => f.TotalPrice) }).ToList();
            var list = ProductDetail.productsList;
            if (list.Count > 0)
            {
                NoProduct.Visibility = Visibility.Collapsed;
                Case.Visibility = Visibility.Visible;
                ProductMenu.ItemsSource = null;               
                ProductMenu.ItemsSource = list;
            }
            else
            {
                NoProduct.Visibility = Visibility.Visible;
                Case.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement fe = e.OriginalSource as FrameworkElement;
            Product product = fe.DataContext as Product;
            ProductDetail.productsList.Remove(product);
            navbar.UpdateCost(ProductDetail.productsList);
            Window_Loaded(sender, e);
        }
    }
}
