using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinProject.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        public AboutPage()
        {
            InitializeComponent();
        }

        private async void ImageClick(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(0);
        }
    }
}