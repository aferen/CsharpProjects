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

namespace WpfProject.View
{
    /// <summary>
    /// Navbar.xaml etkileşim mantığı
    /// </summary>
    public partial class Navbar : Page
    {
        private MainWindow main;
        //private static int productCnt = 0;
        //private static decimal totalprice = 0;
        public Navbar(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void Image_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            main.ChangeContent(true, 1);
        }

        private void Label_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            main.ChangeContent(false, 2);
        }

        private void Label_PreviewMouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            main.ChangeContent(false, 2);
        }
        public void UpdateCost(List<Product> lst)
        {
            int? productCnt = 0;
            decimal? totalprice = 0;
            string total = null;
            if (lst.Count > 0)
            {
                foreach (var item in lst)
                {
                    productCnt += item.CountProduct;
                    totalprice += (item.CountProduct * item.NewPrice);
                }
                total = productCnt + " Ürün / " + totalprice + " TL";
                CaseTotal.Content = total;
            }
            else
            {
                total = "0 Ürün / 0.00 TL";
                CaseTotal.Content = total;
            }

        }

        private void Button_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            main.ChangeContent(false, 3);
        }
    }
}
