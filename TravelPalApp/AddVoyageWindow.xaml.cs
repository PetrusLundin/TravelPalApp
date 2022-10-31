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
    /// Interaction logic for AddVoyageWindow.xaml
    /// </summary>
    public partial class AddVoyageWindow : Window
    {
        MyPagesWindow _myPagesWindow;
        string selectedTravelType;
        TravelManager _travelManager;
        User _user;
        UserManager _userManager;
        private Travel newTravel;

        public AddVoyageWindow(User user, TravelManager travelManager, MyPagesWindow myPagesWindow)
        {
            InitializeComponent();
            _user = user;            
            _travelManager = travelManager;            
            _myPagesWindow = myPagesWindow;
            

            string[] getAllCountries = Enum.GetNames(typeof(Countries));
            cbCountries.ItemsSource = getAllCountries;
            string[] getTripTypes = Enum.GetNames(typeof(TripTypes));
            cbTripType.ItemsSource = getTripTypes;
            string[] getTravelTypes = Enum.GetNames(typeof(TravelType));
            cbTripVacChoice.ItemsSource = getTravelTypes;
            
        }

        private void btnAddVoyage_Click(object sender, RoutedEventArgs e)
        {
            string country = cbCountries.SelectedItem as string;
            string destination = txtDestination.Text;
            Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), country);

            try
            {            
                int travellers = int.Parse(txtAmountOfTravelers.Text);

                if(this.selectedTravelType == "Trip")
                {
                    string tripTypeString = cbTripType.SelectedItem.ToString();
                    TripTypes tripType = (TripTypes)Enum.Parse(typeof(TripTypes), tripTypeString);

                    newTravel = this._travelManager.AddTravel(destination, selectedCountry, travellers, tripType);
                }
                else if (this.selectedTravelType == "Vacation")
                {
                    bool allInclusive = (bool)xbAllinclusive.IsChecked;

                    newTravel = this._travelManager.AddTravel(destination, selectedCountry, travellers, allInclusive);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if(newTravel != null)
            {
                _user.travels.Add(newTravel); // TODO: Check if this is the right user 
                _myPagesWindow.UpdateUi();
                Close();
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            _myPagesWindow.UpdateUi();
            Close();            
        }

        private void cbTripVacChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.selectedTravelType = cbTripVacChoice.SelectedItem as string;
            
            if(selectedTravelType == "Trip")
            {
                cbTripType.Visibility = Visibility.Visible;
                xbAllinclusive.Visibility = Visibility.Hidden;
            }
            else if (selectedTravelType == "Vacation")
            {
                xbAllinclusive.Visibility = Visibility.Visible;
                cbTripType.Visibility = Visibility.Hidden;
            }
        }
    }
}
