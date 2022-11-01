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
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        Travel _travel;
        UserManager _userManager;
        TravelManager _travelManager;
        public DetailsWindow(Travel travel, UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();
            _travel = travel;
            _userManager = userManager;
            _travelManager = travelManager;

            lblDestination.Content = travel.Destination;
            lblCountry.Content = travel.Country;
            lblTravelers.Content = travel.Travelers;



            if (travel is Trip)
            {
                Trip trip = travel as Trip;
                lblTripVacation.Content = typeof(Trip).Name;
                lblSpeciale.Content = $"Trip type: {trip.TripType.ToString()}";
            }
            else if (travel is Vacation)
            {
                Vacation vacation = travel as Vacation;
                lblTripVacation.Content = typeof(Vacation).Name;
                if (vacation._AllInclusive == true)
                {
                    lblSpeciale.Content = $"All inclusive: Yes";
                }
                else
                {
                    lblSpeciale.Content = $"All inclusive: No";
                }
            }
            

            
        }
        
    }
}
