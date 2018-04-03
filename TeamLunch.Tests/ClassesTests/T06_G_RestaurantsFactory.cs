using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLunch.Logic;

namespace TeamLunch.Tests.ObjectsTests
{
    /// <summary>
    /// This test class checks to see that RestaurantFactory class methods perform the
    /// intended functionality. It checks good cases only, that do not throw any exceptions.
    /// </summary>
    [TestClass]

    public class T06_G_RestaurantsFactory
    {
        private Verifier Verifier = new Verifier();

        /// <summary>
        /// This test checks to see that restaurants are added to the list of restaurants
        /// </summary>
        [TestMethod]
        public void RestaurantsFactory_ListOfRestaurants ()
        {
            // Ask factory to create two restaurants
            RestaurantsFactory factory = new RestaurantsFactory();
            factory.CreateRestaurant("A", 3, 1, 1, 1, 1, 5);
            factory.CreateRestaurant("B", 3, 0, 0, 0, 0, 10);

            // Create the expected restaurants:
            Restaurant restaurantAt0 = new Restaurant("A", 3, 1, 1, 1, 1, 5);
            Restaurant restaurantAt1 = new Restaurant("B", 3, 0, 0, 0, 0, 10);

            // Check to see that list stores restaurants as the ones, which are expected.
            Assert.IsTrue(Verifier.RestaurantsAreEq(factory.ListOfRestaurants[0], restaurantAt0));
            Assert.IsTrue(Verifier.RestaurantsAreEq(factory.ListOfRestaurants[1], restaurantAt1));
        }
    }
}
