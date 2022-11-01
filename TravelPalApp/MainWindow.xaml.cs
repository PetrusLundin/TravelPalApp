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
using TravelPalApp.Managers;

namespace TravelPalApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager _userManager = new();
        private TravelManager _travelManager = new();
        public MainWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();
            _userManager = userManager;
            _travelManager = travelManager;
        }
        public MainWindow()
        {   

            InitializeComponent();

            
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow(_userManager, _travelManager);
            signUpWindow.Show();
            Close();
        }

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
