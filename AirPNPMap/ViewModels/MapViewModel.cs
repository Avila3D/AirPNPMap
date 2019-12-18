using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AirPNPMap.Models;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;
using AirPNPMap.Views;
using System.Linq;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirPNPMap.ViewModels
{
    public class MapViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsLocationAvailable()
        {
            if (!CrossGeolocator.IsSupported)
                return false;

            return CrossGeolocator.Current.IsGeolocationAvailable;
        }


        public MapViewModel()
        {
            Navigation NavPag  = new Navigation();
            
            

            Task.Run(async () =>
            {

                var position = await CrossGeolocator.Current.GetPositionAsync();
                MyPosition = new Position(position.Latitude, position.Longitude);

           

                var db = new SQLiteConnection(App.DatabaseLocation);
                var testList = db.Table<Parking>().ToList(); 

                foreach (Parking parkingPosition in testList)
                {
                    PinCollection.Add(new CustomPin() { Position = new Position(parkingPosition.Latitude, parkingPosition.Longitude), Type = PinType.SearchResult, Label = parkingPosition.Name });
                }
            });
        }



        private ObservableCollection<CustomPin> _pinCollection = new ObservableCollection<CustomPin>();
        public ObservableCollection<CustomPin> PinCollection { get { return _pinCollection; } set { _pinCollection = value; OnPropertyChanged(); } }

        //40.7711865, -111.9024351
        private Position _myPosition = new Position();
        public Position MyPosition { get { return _myPosition; } set { _myPosition = value; OnPropertyChanged(); } }

    }
}