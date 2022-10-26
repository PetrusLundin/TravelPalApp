using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPalApp.Models
{
    internal class Vacation
    {
        public bool AllInclusive { get; set; }

        public Vacation(bool allInclusive)
        {
            AllInclusive = allInclusive;
        }
        
        public string GetInfo()
        {
            return $"";
        }
    }
}
