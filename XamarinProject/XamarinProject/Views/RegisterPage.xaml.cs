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
    public partial class RegisterPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        public RegisterPage()
        {
            InitializeComponent();
        }
        private async void ImageClick(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(0);
        }

        private async void RegisterEvent(object sender, EventArgs e)
        {
            if (SignUpPassword1.Text == SignUpPassword2.Text)
            {
                using (var client = new HttpClient())
                {
                    User user = new User { Email = SignUpEmail.Text, Password = SignUpPassword1.Text };
                    client.BaseAddress = new Uri(Helper.BaseUrl);
                    var response = client.PostAsJsonAsync("users", user).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        AlertText.IsVisible = true;
                        AlertText.BackgroundColor = Color.FromHex("28A745");
                        AlertText.Text = "Kullanıcı Oluşturuldu";
                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        AlertText.IsVisible = true;
                        AlertText.BackgroundColor = Color.FromHex("DC3545");
                        AlertText.Text = result;
                    }
                }
            }
            else
            {
                AlertText.IsVisible = true;
                AlertText.BackgroundColor = Color.FromHex("DC3545");
                AlertText.Text = "Şifre ve Şifre Tekrar Aynı Değil.";
            }
        }


        protected override async void OnAppearing()
        {
            AlertText.IsVisible = false;
            AlertText.BackgroundColor = Color.Transparent;
            AlertText.Text = null;
            SignUpEmail.Text = null;
            SignUpPassword1.Text = null;
            SignUpPassword2.Text = null;
        }
    }
}