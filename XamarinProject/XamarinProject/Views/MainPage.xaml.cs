using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinProject.Models;

namespace XamarinProject.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;
            MenuPages.Add((int)MenuItemType.AnaSayfa, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.AnaSayfa:
                        MenuPages.Add(id, new NavigationPage(new HomePage()));
                        break;
                    case (int)MenuItemType.Hakkimizda:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Giris:
                        MenuPages.Add(id, new NavigationPage(new LoginPage()));
                        break;
                    case (int)MenuItemType.Kayit:
                        MenuPages.Add(id, new NavigationPage(new RegisterPage()));
                        break;
                    case (5):
                        MenuPages.Add(5, new NavigationPage(new ProductCasePage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

        public async Task NavigateFromMenu(int id, int pid)
        {
            id = pid+50;
            if (!MenuPages.ContainsKey(id))
            {

                MenuPages.Add(id, new NavigationPage(new ProductDetailPage(pid)));
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

        public async Task NavigateFromMenu(int id, MainCategory main)
        {
            id = main.Id+100;
            if (!MenuPages.ContainsKey(id))
            {

                MenuPages.Add(id, new NavigationPage(new HomePage(main)));
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

        public async Task NavigateFromMenu(int id, SubCategory1 sub1)
        {
            id = sub1.Id + 150;
            if (!MenuPages.ContainsKey(id))
            {

                MenuPages.Add(id, new NavigationPage(new HomePage(sub1)));
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

        public async Task NavigateFromMenu(int id, SubCategory2 sub2)
        {
            id = sub2.Id + 200;
            if (!MenuPages.ContainsKey(id))
            {

                MenuPages.Add(id, new NavigationPage(new HomePage(sub2)));
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}