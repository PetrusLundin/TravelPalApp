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
using TravelPalApp.Interfaces;
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
        private IUser _user;
        private TravelManager _travelManager;

        public MyPagesWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();
            _userManager = userManager;
            _travelManager = travelManager;
            _user = _userManager.SignedInUser;

            UpdateUi();   
        }

        //Updates the Window with the correct uptodate informtion
        public void UpdateUi()
        {
            lvBookings.Items.Clear();   
            lblWelcome.Content = $"Welcome {_user.Username}!";
            

            if (_user is User)
            {
                User signedInUser = _user as User;

                foreach (Travel travel in signedInUser.Travels)
                {
                    ListViewItem item = new();
                    item.Content = travel.Destination;
                    item.Tag = travel;
                    lvBookings.Items.Add(item);
                }
            }
            else if(_user is Admin)
            {
                btnAddVoyage.IsEnabled = false;
                foreach(Travel travel in _travelManager.Travels)
                {
                    ListViewItem item = new();
                    item.Content = $"{travel.Destination}";
                    item.Tag = travel;
                    lvBookings.Items.Add(item);

                }
            }
        }

        private void btnVoyageDetails_Click(object sender, RoutedEventArgs e)
        {
            if (lvBookings.SelectedItem == null)
            {
                MessageBox.Show("No travel selected");
                return;
            }
            else
            {
                ListViewItem booking = lvBookings.SelectedItem as ListViewItem;
                Travel selectedTravel = booking.Tag as Travel;
                DetailsWindow detailsWindow = new(selectedTravel, _userManager, _travelManager);
                detailsWindow.Show();
            }
        }

        private void btnRemoveVoyage_Click(object sender, RoutedEventArgs e)
        {
            if (lvBookings.SelectedItem == null)
            {
                MessageBox.Show("No travel selected");
                return;
            }
            else
            {
                ListViewItem selectedBooking = lvBookings.SelectedItem as ListViewItem;
                Travel selectedTravel = selectedBooking.Tag as Travel;

                MessageBoxResult result = MessageBox.Show("Are you sure you want to remove this booking", "You sure?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                switch (result)
                {
                    case MessageBoxResult.Yes:

                        _travelManager.RemoveTravel(selectedTravel);

                        foreach (IUser user in _userManager.GetUsers())
                        {
                            if (user is User)
                            {
                                User u = user as User;

                                if (u.Travels.Contains(selectedTravel))
                                {
                                    u.Travels.Remove(selectedTravel);
                                }
                            }
                        }

                        break;
                    case MessageBoxResult.No:
                        break;

                }
                UpdateUi();
            }
        }

        private void btnAddVoyage_Click(object sender, RoutedEventArgs e)
        {
            User user = _user as User;
            AddVoyageWindow addVoyageWindow = new(user, _travelManager, this);
            addVoyageWindow.Show();
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

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Den här appen hjälper dig att hålla ordning på alla dina resor som du har planerat.\n\n" +
                "TravelPal är ett företag med kunden i fokus som vill att våra användare ska få den bästa upplevelsen när de planerar sina resor. ");
        }
    }
}