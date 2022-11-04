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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelPalApp.Enums;
using TravelPalApp.Interfaces;
using TravelPalApp.Managers;
using TravelPalApp.Models;

namespace TravelPalApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager _userManager;
        private TravelManager _travelManager;
        public MainWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();
            _userManager = userManager;
            _travelManager = travelManager;


        }
        public MainWindow()
        {   
            InitializeComponent();

            _userManager = new();
            _travelManager = new();

            foreach (IUser user in _userManager.GetUsers())
            {
                if (user is User)
                {
                    User u = user as User;

                    _travelManager.Travels.AddRange(u.Travels);
                }
            }
        }

        // Button for openng the Sign up window
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow(_userManager, _travelManager);
            signUpWindow.Show();
            Close();
        }
        // Button for opening the MyPage window
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
           
           if(_userManager.SignInUser(username, password))
            {
                MyPagesWindow myPagesWindow = new MyPagesWindow(_userManager, _travelManager);
                myPagesWindow.Show();
                Close();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
