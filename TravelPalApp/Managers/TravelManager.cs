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

        // Skapar trip and adds to list
        public Travel AddTravel(string destination, Countries country, int travellers, TripTypes tripType) 
        {
            Trip trip = new Trip(tripType, destination, country, travellers);
            Travels.Add(trip);
            return trip;
        }

        // Skapar vacation and adds to list
        public Travel AddTravel(string destination, Countries country, int travellers, bool allInclusive) 
        {
            Vacation vacation = new Vacation(allInclusive, destination, country, travellers);
            Travels.Add(vacation);
            return vacation;
        }

        //Takes a travel and removes it from travelsList
        public void RemoveTravel(Travel travel)
        {
            Travels.Remove(travel);
        }
        
    }
}
