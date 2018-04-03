using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLunch.Logic;

namespace TeamLunch.Tests.ObjectsTests
{
    [TestClass]
    public class T03_RestaurantsHas0Meals
    {
        /// <summary>
        /// This test checks that if the customer wants to order 0 meals of each type,
        /// total list of orders should be empty.
        /// </summary>
        [TestMethod]
        public void Case_Order0Meals()
        {
            //Team needs: total 0 meals
            OrderWishList order = new OrderWishList(0, 0, 0, 0, 0);

            // Create restaurants
            RestaurantsFactory factory = new RestaurantsFactory();
            factory.CreateRestaurant("A", 5, 4, 0, 0, 0, 40);
            factory.CreateRestaurant("B", 3, 20, 20, 0, 0, 100);

            // Process order
            OrderProcessor processor = new OrderProcessor(order, factory);
            List<MealsReadyForDelivery> totalOrders = processor.TotalOrders;


            // Check to see that nothing was ordered
            Assert.IsTrue((totalOrders.Count == 0));
            
        }
    }
}
