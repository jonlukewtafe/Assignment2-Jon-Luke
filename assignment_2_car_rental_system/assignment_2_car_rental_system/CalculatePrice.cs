using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2_car_rental_system
{
    public class CalculatePrice
    {
        public double Kilometers { get; set; }
        public DateTime CurrentDate = DateTime.Now;
        public double CostPerKilometer = 1;

        public CalculatePrice()
        {
            Kilometers = 0;
        }

        public double rentalKilometer(double distance, double fuelCost)
        {
            double totalCost = distance * CostPerKilometer;
            totalCost += fuelCost;
            return totalCost;
        }
    }
}
