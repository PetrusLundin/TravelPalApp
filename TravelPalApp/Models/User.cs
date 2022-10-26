using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalApp.Enums;
using TravelPalApp.Interfaces;

namespace TravelPalApp.Models
{
    public class User : IUser
    {
        public List<Travel> travels = new();
        public int MyProperty { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }

        public string IUser()
        {
            return "";
        }
    }
}
