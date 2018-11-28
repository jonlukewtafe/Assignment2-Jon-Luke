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
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace assignment_2_car_rental_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Vehicle> vehicles;


        public MainWindow()
        {
            InitializeComponent();

            // Add vehicles to a new list of Vehicles
            vehicles = new List<Vehicle>();
            vehicles.Add(new Vehicle("Ford", "T812", 2014, "THA-HEL", 25000, 250));
            vehicles.Add(new Vehicle("Tesla", "M4", 2019, "WTF-HEL", 34986, 367));

            // Bind the list to the listview
            listView_vehicles.ItemsSource = vehicles;

            
            

        }

        private void listView_vehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            initializeListView();
            txtBox_AddKilometers.Text = "";
            txtBox_FuelLitres.Text = "";
            txtBox_Cost.Text = "";
        }

        /// <summary>
        /// Add the distance traveled to the existing odometer reading using the addKilometers method.
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddJourney_Click(object sender, RoutedEventArgs e)
        {
            Vehicle ve = (Vehicle)listView_vehicles.SelectedItem;
            
            if (ve != null && txtBox_AddKilometers.Text != null)
            {
                ve.addKilometers(Int32.Parse(txtBox_AddKilometers.Text));
                txtBlock_OdometerReading.Text = ve.OdometerReading.ToString();
                initializeListView();


            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddFuel_Click(object sender, RoutedEventArgs e)
        {
            Vehicle ve = (Vehicle)listView_vehicles.SelectedItem;
            
            if (ve != null && txtBox_FuelLitres.Text != null && txtBox_Cost != null)
            {
                ve.FuelPurchase.purchaseFuel(Convert.ToDouble(txtBox_FuelLitres.Text), Convert.ToDouble(txtBox_Cost.Text));
                txtBlock_TotalFuel.Text = ve.FuelPurchase.Litres.ToString();
                txtBlock_FuelCost.Text = ve.FuelPurchase.Cost.ToString();
            }
            else
            {
                MessageBox.Show("The data entered is either incorrect or has not been entered", "Incorrect Data");
            }
        }

        private void btn_Service_Click(object sender, RoutedEventArgs e)
        {
            Vehicle ve = (Vehicle)listView_vehicles.SelectedItem;

            if (ve != null)
            {
                ve.Service.recordService(ve.OdometerReading);
                txtBlock_DateLastServiced.Text = ve.Service.lastServiceDate.ToShortDateString();
                txtBlock_ServiceCount.Text = ve.Service.serviceCount.ToString();
                txtBlock_LastServiceOdometerReading.Text = ve.Service.lastServiceOdometerKm.ToString();
            }
        }

        private void btn_calculateTotalCost_Click(object sender, RoutedEventArgs e)
        {
            Vehicle ve = (Vehicle)listView_vehicles.SelectedItem;
            txtBlock_TotalCost.Text = ve.CalculatePrice.rentalKilometer(ve.Journey.getKilometers(), ve.FuelPurchase.Cost).ToString();
            
        }

        private void initializeListView()
        {
            Vehicle ve = (Vehicle)listView_vehicles.SelectedItem;
            if (ve != null)
            {
                txtBlock_VehicleManufacturer.Text = ve.Manufacturer.ToString();
                txtBlock_VehicleModel.Text = ve.Model.ToString();
                txtBlock_ManufactureYear.Text = ve.MakeYear.ToString();
                txtBlock_FuelCapacity.Text = ve.TankCapacity.ToString();
                txtBlock_OdometerReading.Text = ve.OdometerReading.ToString();
                txtBlock_RegistrationNumber.Text = ve.RegistrationNumber.ToString();
                txtBlock_DateLastServiced.Text = ve.Service.lastServiceDate.ToShortDateString();
                txtBlock_ServiceCount.Text = ve.Service.serviceCount.ToString();
                txtBlock_LastServiceOdometerReading.Text = ve.Service.lastServiceOdometerKm.ToString();
                txtBlock_TotalFuel.Text = ve.FuelPurchase.Litres.ToString();
                txtBlock_FuelCost.Text = ve.FuelPurchase.Cost.ToString();
            }

            // Updates Service Required Display
            if (ve != null)
            {
                if (ve.Service.serviceRequired(ve.OdometerReading) == true)
                {
                    txtBlock_ServiceRequired.Text = "Yes";
                }
                else
                {
                    txtBlock_ServiceRequired.Text = "No";
                }
            }
            //
            ObservableCollection<Vehicle> observable = new ObservableCollection<Vehicle>(vehicles);
            listView_vehicles.ItemsSource = observable;
        }
    }
}
