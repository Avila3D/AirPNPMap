using System;
using Xamarin.Forms.Maps;

namespace AirPNPMap.Models
{
    public class CustomPin : Pin
    {
        public string Price { get; set; }
        public string Url { get; set; }
        public bool IsAvailable { get; set; }
    }
}
