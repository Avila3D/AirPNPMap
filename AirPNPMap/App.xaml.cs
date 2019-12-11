using System;
using AirPNPMap.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;

namespace AirPNPMap
{
   
    public partial class App : Application
    {
    //Database
        public static string DatabaseLocation = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        
        //Database
        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new MainPage();

            DatabaseLocation = databaseLocation;

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
