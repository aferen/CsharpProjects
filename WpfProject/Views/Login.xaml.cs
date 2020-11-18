using System;
using System.Collections.Generic;
using System.Net.Http;
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

namespace WpfProject.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();          
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AlertText.Visibility = Visibility.Collapsed;
            AlertText.Background = Brushes.Transparent;
            AlertText.Text = null;
        }
        private void Button_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            using (var client = new HttpClient())
            {
                User user = new User { Email = SignInEmail.Text, Password = SignInPassword.Password };
                client.BaseAddress = new Uri(Helper.BaseUrl);
                var response = client.PostAsJsonAsync("users/login", user).Result;
                if (response.IsSuccessStatusCode)
                {
                    BrushConverter bc = new BrushConverter();
                    Brush brush = (Brush)bc.ConvertFrom("#28A745");
                    brush.Freeze();
                    AlertText.Visibility = Visibility.Visible;
                    AlertText.Background = brush;
                    AlertText.Text = "Merhaba " + SignInEmail.Text;
                    //LoginPanel.Visibility = Visibility.Collapsed;
                    //xBorder.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BrushConverter bc = new BrushConverter();
                    Brush brush = (Brush)bc.ConvertFrom("#DC3545");
                    brush.Freeze();
                    AlertText.Visibility = Visibility.Visible;
                    AlertText.Background = brush;
                    AlertText.Text = "Email veya Şifre Hatalı.";
                }
            }
        }

        private async void Button_PreviewMouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            if (SignUpPassword1.Password == SignUpPassword2.Password)
            {
                using (var client = new HttpClient())
                {
                    User user = new User { Email = SignUpEmail.Text, Password = SignUpPassword1.Password };
                    client.BaseAddress = new Uri(Helper.BaseUrl);
                    var response = client.PostAsJsonAsync("users", user).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        BrushConverter bc = new BrushConverter();
                        Brush brush = (Brush)bc.ConvertFrom("#28A745");
                        brush.Freeze();
                        AlertText.Visibility = Visibility.Visible;
                        AlertText.Background = brush;
                        AlertText.Text = "Kullanıcı Oluşturuldu";
                        //user = await response.Content.ReadAsAsync<User>();

                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        BrushConverter bc = new BrushConverter();
                        Brush brush = (Brush)bc.ConvertFrom("#DC3545");
                        brush.Freeze();
                        AlertText.Visibility = Visibility.Visible;
                        AlertText.Background = brush;
                        AlertText.Text = result;
                    }
                }
            }
            else
            {
                BrushConverter bc = new BrushConverter();
                Brush brush = (Brush)bc.ConvertFrom("#DC3545");
                brush.Freeze();
                AlertText.Visibility = Visibility.Visible;
                AlertText.Background = brush;
                AlertText.Text = "Şifre ve Şifre Tekrar Aynı Değil.";
            }
        }
    }
}
