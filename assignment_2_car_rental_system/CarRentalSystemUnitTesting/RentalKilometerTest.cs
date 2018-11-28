using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using assignment_2_car_rental_system;

namespace CarRentalSystemUnitTesting
{
    [TestClass]
    public class RentalKilometerTest
    {
        [TestMethod]
        public void testRentalKilometerPass()
        {
            Vehicle test = new Vehicle("Ford", "T812", 2014, "THA-HEL", 25000, 250);
            double actual = test.CalculatePrice.rentalKilometer(300, 12);
            double expected = 312;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testRentalKilometerFail()
        {
            Vehicle test = new Vehicle("Ford", "T812", 2014, "THA-HEL", 25000, 250);
            double actual = test.CalculatePrice.rentalKilometer(300, 12);
            double expected = 302;
            Assert.AreEqual(expected, actual);
        }
    }
}
