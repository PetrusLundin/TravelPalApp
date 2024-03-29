﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalApp.Enums;
using TravelPalApp.Interfaces;

namespace TravelPalApp.Models
{
    public class Admin : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }

        public Admin(string username, string password, Countries location)
        {
            Username = username;
            Password = password;
            Location = location;    
        }
    }
}
