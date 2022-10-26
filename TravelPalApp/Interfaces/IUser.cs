using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalApp.Enums;

namespace TravelPalApp.Interfaces
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Countries Location { get; set; }

      
    }
}
