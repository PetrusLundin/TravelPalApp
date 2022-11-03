using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TravelPalApp.Enums;
using TravelPalApp.Interfaces;
using TravelPalApp.Managers;
using TravelPalApp.Models;

namespace TravelPalApp
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        IUser _user;
        UserManager _userManager;
        TravelManager _travelManager;
        MyPagesWindow _myPagesWindow;
        public UserDetailsWindow(MyPagesWindow myPagesWindow, UserManager userManager, TravelManager travelManager)
        {
            _myPagesWindow = myPagesWindow;
            _user = userManager.SignedInUser;
            _userManager = userManager;
            _travelManager = travelManager;
            InitializeComponent();
            lblNameCountry.Content = $"{_user.Username},  {_user.Location}";


            string[] getAllCountries = Enum.GetNames(typeof(Countries));
            cbCountry.ItemsSource = getAllCountries;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string newUsername = txtUsername.Text;
                string newPassword = txtPassword.Text;
                string confirmPassword = txtConfirmPassword.Text;
                if (newPassword == confirmPassword)
                {
                    if (_userManager.UpdateUsername(_user, newUsername) && _userManager.UpdatePassword(_user, newPassword) == true)
                    {
                        

                        string country = cbCountry.SelectedItem as string;
                        Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), country);
                        _user.Location = selectedCountry;
                        _user.Username = txtUsername.Text;
                        _user.Password = txtPassword.Text;
                        MessageBox.Show("User has been updated");
                        _myPagesWindow.UpdateUi();
                        Close();
                    }



                }
                else
                {
                    MessageBox.Show("You fool! The passwords must be the same");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Please select the country you're from.");
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
