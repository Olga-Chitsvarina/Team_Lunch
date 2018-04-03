using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLunch.Logic;

namespace TeamLunch.Tests.ObjectsTests
{
    [TestClass]
    public class T03_Order0Meals
    {
        /// <summary>
        /// This test checks that if restaurants has 0 meals,
        /// total list of orders should be empty, nothing was ordered
        /// </summary>
        [TestMethod]
        public void Case_RestaurantsHas0Meals()
        {
            //Team needs: total of 100 meals (50 vegetarian + 50 gluten-free)
            OrderWishList order = new OrderWishList(50, 50, 0, 0, 100);

            // Create restaurants, which has 0 meals
            RestaurantsFactory factory = new RestaurantsFactory();
            factory.CreateRestaurant("A", 5, 0, 0, 0, 0, 0);
            factory.CreateRestaurant("B", 3, 0, 0, 0, 0, 0);

            // Process order
            OrderProcessor processor = new OrderProcessor(order, factory);
            List<MealsReadyForDelivery> totalOrders = processor.TotalOrders;


            // Check to see that nothing was ordered
            Assert.IsTrue((totalOrders.Count == 0));
        }
    }
}
