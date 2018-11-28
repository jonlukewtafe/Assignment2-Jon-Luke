using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using assignment_2_car_rental_system;

namespace CarRentalSystemUnitTesting
{
    [TestClass]
    public class AddKilometersTest
    {
        [TestMethod]
        public void testAddKilometersPass()
        {
            Vehicle test = new Vehicle("Ford", "T812", 2014, "THA-HEL", 25000, 250);
            // Run the AddKilometers method twice
            // to provide two a comparison value
            test.addKilometers(345);
            test.addKilometers(678);

            double actual = test.Journey.getKilometers();
            double expected = 1023;
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void testAddKilometersFail()
        {
            Vehicle test = new Vehicle("Ford", "T812", 2014, "THA-HEL", 25000, 250);
            test.addKilometers(345);
            double actual = test.Journey.getKilometers();
            double expected = 2609;
            Assert.AreEqual(expected, actual);
        }
    }
}
