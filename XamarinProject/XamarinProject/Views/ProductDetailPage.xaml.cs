using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinProject.Models;
using XamarinProject.Views;

namespace XamarinProject.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ProductDetailPage : ContentPage
    {
        private List<Product> productsList;
        private List<MainCategory> categories;
        Service<Models.MainCategory> service = new Service<Models.MainCategory>();
        Service<Product> service2 = new Service<Product>();
        Service<List<Comment>> service3 = new Service<List<Comment>>();
        private int? id;
        private Product products;
        private List<Comment> comments;
        private int cnt = 1;
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        public ProductDetailPage(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private async void ImageClick(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(0);
        }

        private void Decrease(object sender, EventArgs e)
        {
            var button = sender as Button;
            var sl1 = button.Parent as StackLayout;
            var frm = sl1.Children[1] as Frame;
            var sl2 = frm.Children[0] as StackLayout;
            var Cnt = sl2.Children[0] as Label;
           
            cnt = Convert.ToInt32(Cnt.Text);
            if (cnt > 1)
            {
                cnt = Convert.ToInt32(Cnt.Text)-1;
                Cnt.Text = (Convert.ToInt32(Cnt.Text) - 1).ToString();
            }
        }

        private void Increase(object sender, EventArgs e)
        {
            var button = sender as Button;
            var sl1 = button.Parent as StackLayout;
            var frm = sl1.Children[1] as Frame;
            var sl2 = frm.Children[0] as StackLayout;
            var Cnt = sl2.Children[0] as Label;
            cnt = Convert.ToInt32(Cnt.Text)+1;
            Cnt.Text = (Convert.ToInt32(Cnt.Text) + 1).ToString();
        }

        async void AddCase(object sender, EventArgs e)
        {
            products.CountProduct = cnt;
            products.TotalPrice = products.NewPrice * cnt;
            Helper.productsCaseList.Add(products);
            UpdateCost(Helper.productsCaseList);
        }


        async void ShowCase(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(5);
        }


        async void UpdateCost(List<Product> lst)
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
                CaseTotal.Text = total;
            }
            else
            {
                total = "0 Ürün / 0.00 TL";
                CaseTotal.Text = total;
            }
        }


        protected override async void OnAppearing()
        {
            categories = await service.GetJsonList("Categories");

            products = await service2.GetJson("Products", id);
            products.Image = Helper.BaseUrl + "images?name=" + products.Image;
            decimal price = Convert.ToDecimal(products.Price);
            products.NewPrice = price + (price * 18 / 100);
            products.NewPrice = Math.Round(products.NewPrice, 2);
            _Title.Text = "Ana Sayfa > ";
            if (products.CategoryId <= 10)
            {
                MainCategory main = await service.GetJson("Categories", products.CategoryId);
                _Title.Text += main.Name;
            }

            comments = await service3.GetJson("Comments", products.Id);
            products.CommentCount = comments.Count;
            productsList = new List<Product>();
            productsList.Add(products);
            ProductPanel.ItemsSource = productsList;
            ProductPanel2.ItemsSource = productsList;
            CommentPanel.ItemsSource = comments;
            //CategoryPanel.ItemsSource = categories;
            //Exp1.IsExpanded = false;
            theTabView.SelectNext();
            theTabView.SelectPrevious();
            UpdateCost(Helper.productsCaseList);

            base.OnAppearing();
           
        }

        private async void MainCategoryClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var sl = btn.Parent as StackLayout;
            var grd = sl.Parent as Grid;
            var main = grd.BindingContext as MainCategory;
            await RootPage.NavigateFromMenu(7,main);

        }


        private async void Sub1CategoryClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var sl = btn.Parent as StackLayout;
            var grd = sl.Parent as Grid;
            var sub1 = grd.BindingContext as SubCategory1;
            await RootPage.NavigateFromMenu(8, sub1);


        }

        private async void Sub2CategoryClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var sl = btn.Parent as StackLayout;
            var grd = sl.Parent as Grid;
            var sub2 = grd.BindingContext as SubCategory2;
            await RootPage.NavigateFromMenu(9, sub2);


        }


    }
}