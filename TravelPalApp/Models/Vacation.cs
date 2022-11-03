using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalApp.Enums;

namespace TravelPalApp.Models
{
    internal class Vacation : Travel
    {
        public bool _AllInclusive { get; set; }

        public Vacation(bool allInclusive, string destination, Countries country, int travellers) : base(destination, country, travellers)
        {
            _AllInclusive = allInclusive;
            
        }
        // method that returns a string of info of a Vacation
        public override string GetInfo()
        {
            return $"{Destination}, {Travelers}, {Country}, {_AllInclusive}, {this.GetType().Name}";
        }
    }
}
