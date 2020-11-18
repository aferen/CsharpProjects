using System;
using System.ComponentModel;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinProject.Models;

namespace XamarinProject.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void ImageClick(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(0);
        }
        private async void LoginEvent(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                User user = new User { Email = SignInEmail.Text, Password = SignInPassword.Text };
                client.BaseAddress = new Uri(Helper.BaseUrl);
                var response = client.PostAsJsonAsync("users/login", user).Result;
                if (response.IsSuccessStatusCode)
                {
                    //BrushConverter bc = new BrushConverter();
                    //Brush brush = (Brush)bc.ConvertFrom("#28A745");
                    //brush.Freeze();
                    AlertText.IsVisible = true;
                    AlertText.BackgroundColor = Color.FromHex("28A745");
                    AlertText.Text = "Merhaba " + SignInEmail.Text;
                    //LoginPanel.Visibility = Visibility.Collapsed;
                    //xBorder.Visibility = Visibility.Collapsed;
                }
                else
                {
                    //BrushConverter bc = new BrushConverter();
                    //Brush brush = (Brush)bc.ConvertFrom("#DC3545");
                    //brush.Freeze();
                    AlertText.IsVisible = true;
                    AlertText.BackgroundColor = Color.FromHex("DC3545");
                    AlertText.Text = "Email veya Şifre Hatalı.";
                }
            }
        }


        protected override async void OnAppearing()
        {
            AlertText.IsVisible = false;
            AlertText.BackgroundColor = Color.Transparent;
            AlertText.Text = null;
            SignInEmail.Text = null;
            SignInPassword.Text = null;

        }
    }
}