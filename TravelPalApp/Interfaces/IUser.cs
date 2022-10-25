using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalApp.Enums;

namespace TravelPalApp.Interfaces
{
    internal interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Countries location { get; set; }

       public string IUser();
    }
}
