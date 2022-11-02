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
        public List<Travel> Travels = new();

        public Travel AddTravel(string destination, Countries country, int travellers, TripTypes tripType) // Skapar trip
        {
            Trip trip = new Trip(tripType, destination, country, travellers);
            Travels.Add(trip);
            return trip;
        }
        public Travel AddTravel(string destination, Countries country, int travellers, bool allInclusive) // Skapar vacation
        {
            Vacation vacation = new Vacation(allInclusive, destination, country, travellers);
            Travels.Add(vacation);
            return vacation;
        }

        public void RemoveTravel(Travel travel)
        {
            Travels.Remove(travel);
        }
        public List<Travel> GetTravelList()
        {
            return Travels;
        }
    }
}
