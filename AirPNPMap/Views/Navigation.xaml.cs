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
using Xamarin.Forms.Maps;




namespace AirPNPMap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Navigation : ContentPage
    {
        public List<Parking> parkingLot;
        public Navigation()
        {
            InitializeComponent();
            
        }



        private async void Save_Button (object sender, EventArgs e)
        {
            var address = LocationEntry.Text;
            var locations = await Geocoding.GetLocationsAsync(address);
            

            
            var location = locations?.FirstOrDefault();

            //Position addressPosition = new Position(location.Latitude, location.Longitude);

            




            if (location != null)
            {
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            
            }
            Parking parking = new Parking
            {

                Location = LocationEntry.Text,
                Description = DescriptionEntry.Text,
                Price = PriceEntry.Text,
                Name = NameEntry.Text,
                Availability = AvailabilityEntry.Text,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                //PositionMap = location.ToString,

            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Parking>();
                

                int rows = conn.Insert(parking);

                if (rows > 0) {
                    await DisplayAlert("Success", $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}", "Ok");
                }
                
                else { 
                    await DisplayAlert("Failure", "Parking spot failed to be inserted", "Ok");
                }

                parkingLot = conn.Table<Parking>().ToList();

            }

        }

            
    }
    
}