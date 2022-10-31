using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPalApp.Interfaces;
using TravelPalApp.Models;

namespace TravelPalApp.Managers
{
    public class UserManager
    {
        List<IUser> users = new();

        public IUser SignedInUser { get; set; }

        public UserManager()
        {

            Admin admin = new("Admin", "password", Enums.Countries.USA);            
            users.Add(admin);

            User user = new("Gandalf", "password", Enums.Countries.Barbados);
            users.Add(user);
            Travel travel1 = new("Trombi", Enums.Countries.Cuba, 1);
            user.travels.Add(travel1);            
            Travel travel2 = new("Mormor", Enums.Countries.Ghana, 2);
            user.travels.Add(travel2);


        }
        

        //Adds a user to the list if username and password are free
        public bool AddUser(IUser user)
        {
           if(ValidateUsername(user.Username)== true && ValidatePassword(user.Password) == true)
            {
                users.Add(user);
                return true;
            }
           else
            {
                return false;
            }
           
        }
        // Removes a user from the list
        public void RemoveUser(IUser user)
        {
            if (users.Contains(user))
            {
                users.Remove(user);
            }
        }
        //Update 
        public bool UpdateUsername(IUser user, string username)
        {
            return true;
        }
        // Checks if the username is occupado
        private bool ValidateUsername(string username)
        {
            foreach (IUser user in users)
            {
                if ( username == user.Username)
                {
                    MessageBox.Show("Username is taken..");
                    return false;
                }       
            }
            return true;
        }

        //Checks if the password is occupado
        private bool ValidatePassword(string password)
        {
            foreach (IUser user in users)
            {
                if (password == user.Password)
                {
                    MessageBox.Show("Password is taken..");
                    return false;                    
                }
            }
            return true;
        }
        //If the user exist in the list of users we log in!
        public bool SignInUser(string username, string password)
        {
           
            foreach (IUser user in users)
            {
                if (username == user.Username && password == user.Password)
                {
                    SignedInUser = user;
                    return true;
                }
            }
            MessageBox.Show("Wrong username or password");
            return false;
            
        }

        // Gets the list of users
        public List<IUser> GetUserList()
        {
            return users;
        }
    }
}
