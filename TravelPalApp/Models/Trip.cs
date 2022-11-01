using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalApp.Enums;

namespace TravelPalApp.Models
{
    public class Trip : Travel
    {
        public TripTypes TripType { get; set; }
        public Trip(TripTypes tripType, string destination, Countries country, int travellers) : base(destination, country, travellers)
        {
            TripType = tripType;
        }

        public override string GetInfo()
        {
            return $"{Destination}, {Travelers}, {Country}, {TripType}";
        }
    }
}
