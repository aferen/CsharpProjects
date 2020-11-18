using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Platform;
using CarouselView.FormsPlugin.Android;

namespace XamarinProject.Droid
{
    [Activity(Label = "XamarinProject", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            CachedImageRenderer.InitImageViewHandler();
            base.OnCreate(savedInstanceState);
            //Xamarin.Forms.Init();
            CarouselViewRenderer.Init();
            //FormsPlugin.Iconize.Droid.IconControls.Init(Resource.Id.toolbar);
            //Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule());

            Xamarin.Forms.Forms.SetFlags(new string[] { "Expander_Experimental", "CarouselView_Experimental", "IndicatorView_Experimental", "SwipeView_Experimental" });
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Plugin.Iconize.Iconize.Init(Resource.Id.toolbar, Resource.Id.sliding_tabs); // Could also be Resource.Id.tabs
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}