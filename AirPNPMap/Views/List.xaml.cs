using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AirPNPMap.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirPNPMap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class List : ContentPage
    {
        public List()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Parking>();
                var parkings = conn.Table<Parking>().ToList();
                parkingListView.ItemsSource = parkings;

            }

        }   
    }
}