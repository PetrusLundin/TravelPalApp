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
            Admin admin = new();
            admin.Username = "admin";
            admin.Password = "password";

            users.Add(admin);


        }
        //public User CreateUser(string username, string password)
        //{
        //    User user = new();
        //    user.Username = username;
        //    user.Password = password;
        //    bool isValid = ValidateUsername(username);
        //    if (isValid)
        //    {
        //        return user;
        //    }
        //}
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
        public void RemoveUser(IUser user)
        {
            if (users.Contains(user))
            {
                users.Remove(user);
            }
        }
        public bool UpdateUsername(IUser user, string username)
        {
            return true;
        }
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
        public bool SignInUser(string username, string password)
        {
           
            foreach (IUser user in users)
            {
                if (username == user.Username && password == user.Password)
                {
                    return true;
                }
            }
            MessageBox.Show("Wrong username or password");
            return false;
            
        }
        public List<IUser> GetUserList()
        {
            return users;
        }
    }
}
