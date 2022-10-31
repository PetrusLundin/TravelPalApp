using System;
using System.Collections.Generic;
using System.Linq;
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
using TravelPalApp.Managers;
using TravelPalApp.Models;

namespace TravelPalApp
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private UserManager _userManager;
        public SignUpWindow(UserManager userManager)
        {
            InitializeComponent();

            string[] getAllCountries = Enum.GetNames(typeof(Countries));

            cbCountries.ItemsSource = getAllCountries;

            _userManager = userManager;

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            User user = CreateUser();
            if (_userManager.AddUser(user) == true)
            {
               // MessageBox.Show("Thank you for registring");                
                MainWindow mainWindow = new(_userManager);
                mainWindow.Show();
                this.Close();
            }


        }

        private User CreateUser()
        {
            string country = cbCountries.SelectedItem as string;
            Countries selectedCountries = (Countries)Enum.Parse(typeof(Countries), country);
              User user = new(txtUsername.Text,txtPassword.Text, selectedCountries);
           
            
            return user;
        }


    }
}
