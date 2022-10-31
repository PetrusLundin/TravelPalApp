using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalApp.Enums;
using TravelPalApp.Models;

namespace TravelPalApp.Managers
{
    public class TravelManager
    {
        public List<Travel> travels;

        public Travel AddTravel(string destination, Countries country, int travellers, TripTypes tripType) // Skapar trip
        {
            return new Trip(tripType, destination, country, travellers);
        }
        public Travel AddTravel(string destination, Countries country, int travellers, bool allInclusive) // Skapar vacation
        {
            return new Vacation(allInclusive, destination, country, travellers);
        }

        public void removeTravel(Travel travel)
        {
            travels.Remove(travel);
        }
        public List<Travel> GetTravelList()
        {
            return travels;
        }
    }
}
