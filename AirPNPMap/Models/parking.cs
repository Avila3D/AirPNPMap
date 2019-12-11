using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace AirPNPMap.Models
{
    public class parking
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Price { get; set; }
        
        public string Location { get; set; }
        
        public string Description { get; set; }

        public string Avalability { get; set; }

       public double Latitude { get; set; }

        public double Longitude { get; set; }

        //public string PositionMap { get; set; }


    }
}
