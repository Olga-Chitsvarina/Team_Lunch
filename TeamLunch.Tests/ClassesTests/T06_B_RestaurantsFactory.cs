using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLunch.Logic;

namespace TeamLunch.Tests.ObjectsTests
{
    /// <summary>
    /// This test class checks to see that RestaurantFactory class methods perform the
    /// intended functionality. It checks bad cases only, that throw exceptions.
    /// </summary>
    [TestClass]

    public class T06_B_RestaurantsFactory
    {
        /// <summary>
        /// This test checks to see that names of restaurants must be unique
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            ("Restaurant name should be unique"))]
        public void RestaurantsFactory_UniqueNames ()
        {
            // Create different restaurants with the same name
            RestaurantsFactory factory = new RestaurantsFactory();
            factory.CreateRestaurant("A", 3, 1, 1, 1, 1, 5);
            factory.CreateRestaurant("A", 0, 0, 0, 0, 0, 4);
        }


    }
}
