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
        private UserManager userManager = new();
        public MainWindow()
        {   

            InitializeComponent();

            
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow(userManager);
            signUpWindow.Show();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
           
           if(userManager.SignInUser(txtUsername.ToString(), txtPassword.ToString()))
            {
                MyPagesWindow myPagesWindow = new MyPagesWindow();
                myPagesWindow.Show();
            }
        }
    }
}
