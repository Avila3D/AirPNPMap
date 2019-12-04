using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AirPNPMap.Models;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;

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

            PinCollection.Add(new CustomPin() { Position = MyPosition, Type = PinType.Place, Label = "I'm available $3hr",  Url = "https://www.google.com/maps/place/LDS+Business+College/@40.7710573,-111.9001472,3a,75y,90t/data=!3m8!1e2!3m6!1sAF1QipOIUCEL3E0PLiKF26q7zTvSQja0i7yg8mwgLHbq!2e10!3e12!6shttps:%2F%2Flh5.googleusercontent.com%2Fp%2FAF1QipOIUCEL3E0PLiKF26q7zTvSQja0i7yg8mwgLHbq%3Dw203-h270-k-no!7i3024!8i4032!4m5!3m4!1s0x8752f5aa721d9be3:0xc118ae242cfd5461!8m2!3d40.7711865!4d-111.9002464"});
            PinCollection.Add(new CustomPin() { Position = new Position(40.772068, -111.899517), Type = PinType.SearchResult, Label = "I'm available $2.50hr" });
            PinCollection.Add(new CustomPin() { Position = new Position(40.770541, -111.902285), Type = PinType.SearchResult, Label = "I'm taken until 3pm" });

            Task.Run(async () =>
            {

                var position = await CrossGeolocator.Current.GetPositionAsync();
                MyPosition = new Position(position.Latitude, position.Longitude);
            });
        }



        private ObservableCollection<CustomPin> _pinCollection = new ObservableCollection<CustomPin>();
        public ObservableCollection<CustomPin> PinCollection { get { return _pinCollection; } set { _pinCollection = value; OnPropertyChanged(); } }

        //40.7711865, -111.9024351
        private Position _myPosition = new Position();
        public Position MyPosition { get { return _myPosition; } set { _myPosition = value; OnPropertyChanged(); } }

    }
}