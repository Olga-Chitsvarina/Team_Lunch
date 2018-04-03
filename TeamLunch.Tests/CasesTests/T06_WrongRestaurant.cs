using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLunch.Logic;

namespace TeamLunch.Tests.CasesTests
{
    [TestClass]
    public class T05_WrongRestaurant

    {
        private Verifier Verifier = new Verifier();

        /// <summary>
        /// This test checks to see that if a customer wants to order vegetarian meal,
        /// but none of the restaurants sell vegetarian meal, the list of ordered meals should be empty.
        /// Thus, the customer provided a wrong list of restaurants (wrong = does not sell meals, which customer
        /// wants to order)
        /// </summary>
        [TestMethod]
        public void Case_WrongRestaurant()
        {

            //Team needs: total 5 meals including 5 vegetarians
            OrderWishList order = new OrderWishList(5, 0, 0, 0, 5);

            // Create Restaurants that do not have vegetarian meals
            RestaurantsFactory factory = new RestaurantsFactory();
            factory.CreateRestaurant("B", 1, 0, 0, 0, 0, 50);
            factory.CreateRestaurant("A", 2, 0, 0, 100, 0, 100);

            // Process order:
            OrderProcessor processor = new OrderProcessor(order, factory);
            List<MealsReadyForDelivery> totalOrders = processor.TotalOrders;


            // Check to see that total list of meals ordered is empty
            Assert.AreEqual(totalOrders.Count, 0);
        }
    }
}
