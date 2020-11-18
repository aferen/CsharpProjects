using Plugin.Iconize;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinProject.Views;

namespace XamarinProject
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule())
                         .With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
                         .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule())
                          .With(new Plugin.Iconize.Fonts.MaterialModule())
                          .With(new Plugin.Iconize.Fonts.MaterialDesignIconsModule())
                          .With(new Plugin.Iconize.Fonts.TypiconsModule());
                          
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
