using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FoodShare
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public static bool loggedin { get; set; }
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzIwNjVAMzEzNjJlMzQyZTMwVDJiZUFDVTJ6SCt1b0NmbjBUS1gralYxd2JnbmhOWC8yaWNDQ2VrOUJXND0=");
            IsUserLoggedIn = false;
            loggedin = false;
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            if(loggedin == true)
            {
                MainPage = new NavigationPage(new Home());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
