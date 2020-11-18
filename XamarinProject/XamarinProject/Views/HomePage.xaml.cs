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
    public partial class HomePage : ContentPage
    {
        private List<Product> productsList;
        private List<MainCategory> categories;
        Service<Models.MainCategory> service = new Service<Models.MainCategory>();
        Service<Product> service2 = new Service<Product>();
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        public HomePage()
        {
            InitializeComponent();
        }

        public HomePage(MainCategory main)
        {
            InitializeComponent();
            MainCategoryUpdate(main);
        }
        public HomePage(SubCategory1 sub1)
        {
            InitializeComponent();
            Sub1CategoryUpdate(sub1);


        }

        public HomePage(SubCategory2 sub2)
        {
            InitializeComponent();
            Sub2CategoryUpdate(sub2);

        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Product;
            if (item == null)
                return;

            await RootPage.NavigateFromMenu(6, item.Id);
            //MenuPages.Add(1, new NavigationPage(new ProductDetailPage(item.Id)));
            //await Navigation.PushModalAsync(new NavigationPage(new ProductDetailPage(item.Id)));
            // await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            //ItemsListView.SelectedItem = null;
        }



        async void ShowCase(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(5);
        }
        async void OpenAbout(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(1);
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
            Update();
            ExpBrand.IsVisible = false;
            ExpBrand.IsExpanded = false;
            base.OnAppearing();


        }

        private async void Update()
        {
            categories = await service.GetJsonList("Categories");
            _Title.Text = "Vitrin Ürünleri";
            productsList = await service2.GetJsonList("Products/ShowcaseProduct");
            foreach (var item in productsList)
            {
                item.Image = Helper.BaseUrl + "images?name=" + item.Image;
            }
            CategoryPanel.ItemsSource = categories;
            ProductMenu.HasUnevenRows = true;
            ProductMenu.ItemsSource = productsList;
            Exp1.IsExpanded = false;
            FilterPanel.IsVisible = false;
            ImagesPanel.IsVisible = true;
            UpdateCost(Helper.productsCaseList);

        }

        private async void MainCategoryClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var sl = btn.Parent as StackLayout;
            var grd = sl.Parent as Grid;
            var main = grd.BindingContext as MainCategory;
            MainCategoryUpdate(main);
        }

        private async void MainCategoryUpdate(MainCategory main)
        {
            categories = await service.GetJsonList("Categories");
            productsList = await service2.GetJsonList("products/Maincategory", main.Id);
            foreach (var item in productsList)
            {
                item.Image = Helper.BaseUrl + "images?name=" + item.Image;
            }

            if (productsList.Count == 0)
            {
                _Title.Text = main.Name + "   --Kayıt Bulunamadı--";
            }
            else
            {
                _Title.Text = main.Name;

            }
            Exp1.IsExpanded = false;
            CategoryPanel.ItemsSource = categories;
            ProductMenu.HasUnevenRows = true;
            ProductMenu.ItemsSource = null;
            ProductMenu.ItemsSource = productsList;
            ExpBrand.IsVisible = true;
            ExpBrand.IsExpanded = false;
            FilterPanel.IsVisible = true;
            ImagesPanel.IsVisible = false;
            UpdateCost(Helper.productsCaseList); base.OnAppearing();
        }

        private async void Sub1CategoryClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var sl = btn.Parent as StackLayout;
            var grd = sl.Parent as Grid;
            var sub1 = grd.BindingContext as SubCategory1;
            Sub1CategoryUpdate(sub1);
        }

        private async void Sub1CategoryUpdate(SubCategory1 sub1)
        {
            categories = await service.GetJsonList("Categories");
            productsList = await service2.GetJsonList("products", sub1.MainCategoryId, sub1.Id);
            foreach (var item in productsList)
            {
                item.Image = Helper.BaseUrl + "images?name=" + item.Image;
            }

            if (productsList.Count == 0)
            {
                _Title.Text = sub1.Name + "   --Kayıt Bulunamadı--";
            }
            else
            {
                _Title.Text = sub1.Name;

            }
            Exp1.IsExpanded = false;
            CategoryPanel.ItemsSource = categories;
            ProductMenu.HasUnevenRows = true;
            ProductMenu.ItemsSource = productsList;
            ExpBrand.IsVisible = true;
            ExpBrand.IsExpanded = false;
            FilterPanel.IsVisible = true;
            ImagesPanel.IsVisible = false;
            UpdateCost(Helper.productsCaseList); base.OnAppearing();
        }

        private async void Sub2CategoryClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var sl = btn.Parent as StackLayout;
            var grd = sl.Parent as Grid;
            var sub2 = grd.BindingContext as SubCategory2;
            Sub2CategoryUpdate(sub2);
        }


        private async void Sub2CategoryUpdate(SubCategory2 sub2)
        {
            categories = await service.GetJsonList("Categories");
            productsList = await service2.GetJsonList("products", 0, sub2.SubCategory1Id, sub2.Id);
            foreach (var item in productsList)
            {
                item.Image = Helper.BaseUrl + "images?name=" + item.Image;
            }

            if (productsList.Count == 0)
            {
                _Title.Text = sub2.Name + "   --Kayıt Bulunamadı--";
            }
            else
            {
                _Title.Text = sub2.Name;

            }

            Exp1.IsExpanded = false;
            CategoryPanel.ItemsSource = categories;
            ProductMenu.HasUnevenRows = true;
            ProductMenu.ItemsSource = productsList;
            ExpBrand.IsVisible = true;
            ExpBrand.IsExpanded = false;
            FilterPanel.IsVisible = true;
            ImagesPanel.IsVisible = false;
            UpdateCost(Helper.productsCaseList); base.OnAppearing();

        }
        private void ImageClick(object sender, EventArgs e)
        {
            OnAppearing();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var text = picker.SelectedItem;

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

        private void Picker_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var text = picker.SelectedItem;

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
    }

}