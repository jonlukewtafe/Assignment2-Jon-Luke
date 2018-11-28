using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2_car_rental_system
{
    public class Service
    {
        // Constant to indicate that the vehicle needs to be serviced every 10,000km
        public static int SERVICE_KILOMETER_LIMIT = 10000;

        public double lastServiceOdometerKm { get; set; }
        public int serviceCount { get; set; }
        public DateTime lastServiceDate = DateTime.Now;

        // 
        /// <summary>
        /// Return the last service 
        /// </summary>
        /// <returns></returns>
        public double getLastServiceOdometerKm()
        {
            return this.lastServiceOdometerKm;
        }


        
        /**
         * The function recordService expects the total distance traveled by the car, 
         * saves it and increase serviceCount.
         * @param distance 
         */
        public void recordService(double distance)
        {
            if (serviceRequired(distance) == true)
            {
                this.lastServiceOdometerKm = distance;
                this.serviceCount++;
                this.lastServiceDate = DateTime.Now;
            }
        }

        // return how many services the car has had
        public int getServiceCount()
        {
            return this.serviceCount;
        }

        /**
         * Calculates the total services by dividing kilometers by
         * {@link #SERVICE_KILOMETER_LIMIT} and floors the value. 
         * 
         * @return the number of services needed per SERVICE_KILOMETER_LIMIT
         */
        public int getTotalScheduledServices()
        {
            // TODO: Better variable name
           double a = lastServiceOdometerKm / SERVICE_KILOMETER_LIMIT;
           return (int)Math.Floor(a);
        }

        public bool serviceRequired(double distance)
        {
            double isServiceRequired = distance / SERVICE_KILOMETER_LIMIT;
            if (Math.Floor(isServiceRequired) > serviceCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
