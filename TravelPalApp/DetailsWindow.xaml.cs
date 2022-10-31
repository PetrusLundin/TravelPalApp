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
        public DetailsWindow(Travel travel)
        {
            InitializeComponent();
            _travel = travel;
            lblDestination.Content = travel.Destination;
            lblCountry.Content = travel.Country;
            lblTravelers.Content = travel.Travellers;

            
        }
        private void DecideTravelType()
        {
            
        }
    }
}
