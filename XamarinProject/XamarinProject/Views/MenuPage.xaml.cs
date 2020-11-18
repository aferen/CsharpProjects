using XamarinProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinProject.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.AnaSayfa, Title="Ana Sayfa", IconName="fas-home" },
                new HomeMenuItem {Id = MenuItemType.Hakkimizda, Title="Hakkımızda", IconName="fas-store-alt"  },
                new HomeMenuItem {Id = MenuItemType.Giris, Title="Üye Girişi", IconName="fas-user"  },
                new HomeMenuItem {Id = MenuItemType.Kayit, Title="Üye Ol", IconName="fas-user-plus"  }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}