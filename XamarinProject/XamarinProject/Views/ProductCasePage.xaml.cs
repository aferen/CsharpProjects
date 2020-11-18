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
    public partial class ProductCasePage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        private List<Product> productsList;
        private List<MainCategory> categories;
        Service<Models.MainCategory> service = new Service<Models.MainCategory>();
        Service<Product> service2 = new Service<Product>();
        Service<List<Comment>> service3 = new Service<List<Comment>>();
        private Product products;
        private List<Comment> comments;
        private int cnt = 1;
        public ProductCasePage()
        {
            InitializeComponent();
            
        }
        private async void ImageClick(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(0);
        }

        protected override async void OnAppearing()
        {
            var list = Helper.productsCaseList;
            if (list.Count > 0)
            {
                NoProduct.IsVisible = false;
                Case.IsVisible = true;
                ProductMenu.ItemsSource = null;
                ProductMenu.ItemsSource = list;
            }
            else
            {
                NoProduct.IsVisible = true;
                Case.IsVisible = false;
            }

            UpdateCost(Helper.productsCaseList);

            base.OnAppearing();

           
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


        private void RemoveProduct(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var sl = btn.Parent as StackLayout;
            var lbl1 = sl.Children[1] as Label;
            var lbl2 = sl.Children[2] as Label;
            Product temp = null;

            foreach (var item in Helper.productsCaseList)
            {
                if (item.Title == lbl1.Text && item.CountProduct == Convert.ToInt32(lbl2.Text))
                {
                    temp = item;
                }
            }

            Helper.productsCaseList.Remove(temp);          
            UpdateCost(Helper.productsCaseList);
            OnAppearing();
        }

      
    }
}