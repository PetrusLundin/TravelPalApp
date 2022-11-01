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
using TravelPalApp.Managers;
using TravelPalApp.Models;

namespace TravelPalApp
{
    /// <summary>
    /// Interaction logic for MyPagesWindow.xaml
    /// </summary>
    public partial class MyPagesWindow : Window
    {

        private UserManager _userManager;
        private User _user;
        private Admin _admin;
        private TravelManager _travelManager;

        public MyPagesWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();
            _userManager = userManager;
            _travelManager = travelManager;


            if (_userManager.SignedInUser is User)
            {
                _user = _userManager.SignedInUser as User;
                lblWelcome.Content = $"Welcome {_user.Username}!";
                
            }
            else if (_userManager.SignedInUser is Admin)
            {
                _admin = _userManager.SignedInUser as Admin;
                lblWelcome.Content = $"Welcome {_admin.Username}!";
                lvBookings.Items.Clear();
               
            }
            UpdateUi();


        }
        public void UpdateUi()
        {
            if (_userManager.SignedInUser is User)
            {
                _user = _userManager.SignedInUser as User;
                lblWelcome.Content = $"Welcome {_user.Username}!";
            }


            if (_user.Travels == null)
            {
               return;
            }
            lvBookings.Items.Clear();
            foreach (Travel travel in _user.Travels)
            {
                Travel travel1 = travel as Travel;
                ListViewItem item = new();
                item.Content = travel.Destination;
                item.Tag = travel1;
                lvBookings.Items.Add(item);
            }
        }

        private void btnVoyageDetails_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem booking = lvBookings.SelectedItem as ListViewItem;
            Travel selectedTravel = booking.Tag as Travel;
            DetailsWindow detailsWindow = new(selectedTravel, _userManager, _travelManager);
            detailsWindow.Show();
        }

        private void btnRemoveVoyage_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedBooking = lvBookings.SelectedItem as ListViewItem;
            Travel selectedTravel = selectedBooking.Tag as Travel;

            MessageBoxResult result = MessageBox.Show("Are you sure you want to remove this booking", "You sure?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    _user.Travels.Remove(selectedTravel);
                    break;
                case MessageBoxResult.No:
                    break;

            }
            UpdateUi();
        }

        private void btnAddVoyage_Click(object sender, RoutedEventArgs e)
        {
            AddVoyageWindow addVoyageWindow = new(_user, _travelManager, this);
            addVoyageWindow.Show();
        }

        private void lvBookings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRemoveVoyage.IsEnabled = true;
            btnVoyageDetails.IsEnabled = true;
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(_userManager, _travelManager);
            mainWindow.Show();
            this.Close();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userDetailsWindow = new(this, _userManager, _travelManager);
            userDetailsWindow.Show();
        }
    }
}