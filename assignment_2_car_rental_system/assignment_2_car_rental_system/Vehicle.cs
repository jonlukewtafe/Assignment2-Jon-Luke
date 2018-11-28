using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2_car_rental_system
{
    class Vehicle
    {
        public String Manufacturer { get; set; }
        public String Model { get; set; }
        public int MakeYear { get; set; }
        public string RegistrationNumber { get; set; }
        public double OdometerReading { get; set; }
        public int TankCapacity { get; set; }

        public FuelPurchase FuelPurchase { get; set; }
        public Journey Journey { get; set; }
        public Service Service { get; set; }
        public CalculatePrice CalculatePrice { get; set; }

        /**
         * Class constructor specifying name of make (manufacturer), model, the year the car was made, the car's registration number,
         * it's current odometer reading and it's fuel tank capacity.
         *
         * @param manufacturer
         * @param model
         * @param makeYear
         * @param registrationNumber
         * @param odometerReading
         * @param tankCapacity
         */
        public Vehicle(String Manufacturer, String Model, int MakeYear, String RegistrationNumber, double OdometerReading, int TankCapacity)
        {
            this.Manufacturer = Manufacturer;
            this.Model = Model;
            this.MakeYear = MakeYear;
            this.RegistrationNumber = RegistrationNumber;
            this.OdometerReading = OdometerReading;
            this.TankCapacity = TankCapacity;
            Service = new Service();
            FuelPurchase = new FuelPurchase();
            Journey = new Journey();
            CalculatePrice = new CalculatePrice();
        }

        /// <summary>
        ///  Adds the distance travelled to the pre-existing odometer reading
        /// </summary>
        /// <param name="KilometersTravelled"></param>
        public void addKilometers(double KilometersTravelled)
        {
            Journey.addKilometers(KilometersTravelled);
            OdometerReading += KilometersTravelled;
        }


        /// <summary>
        /// Adds fuel to the car
        /// </summary>
        /// <param name="litres"></param>
        /// <param name="price"></param>
        public void addFuel(double litres, double price)
        {
            FuelPurchase.purchaseFuel(litres, price);
        }
        
    }
}
