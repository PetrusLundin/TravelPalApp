using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalApp.Enums;

namespace TravelPalApp.Models
{
    public class Travel
    {
        public string Destination { get; set; }
        public Countries Country { get; set; }
        public int Travelers { get; set; }

        public int ID { get; set; } = Math.Abs(Guid.NewGuid().GetHashCode());

        public Travel()
        {

        }


        public Travel(string destination, Countries country, int travellers)
        {
            Destination = destination;
            Country = country;
            Travelers = travellers;    
        }

        public virtual string GetInfo()
        {
            return $"{Destination}, {Country}, Travellers: {Travelers}";
        }
    }
}
