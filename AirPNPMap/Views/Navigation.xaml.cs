using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirPNPMap.Models;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace AirPNPMap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Navigation : ContentPage
    {
        public Navigation()
        {
            InitializeComponent();
        }



        private async void Save_Button (object sender, EventArgs e)
        {
            var address = LocationEntry.Text;
            var locations = await Geocoding.GetLocationsAsync(address);

            var location = locations?.FirstOrDefault();
            if (location != null)
            {
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            
            }
            parking parking = new parking
            {

                Location = LocationEntry.Text,
                Description = DescriptionEntry.Text,
                Price = PriceEntry.Text,
                Name = NameEntry.Text,
                Avalability = AvalavilityEntry.Text,
                Latitude = location.Latitude,
                Longitude =location.Longitude,


            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<parking>();
                int rows = conn.Insert(parking);

                if (rows > 0)
                    DisplayAlert("Success", $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}", "Ok");
                else
                    DisplayAlert("Failure", "Parking spot failed to be inserted", "Ok");
            }
        }

            
    }
}