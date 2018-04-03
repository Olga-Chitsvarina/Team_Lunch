using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLunch.Logic;

namespace TeamLunch.Tests.CasesTests
{
    [TestClass]
    public class T05_OrderMoreThanAvailable

    {
        private Verifier Verifier = new Verifier();

        /// <summary>
        /// This test checks to see that if a customer orders more than it is available 
        /// the customer gets the maximum amount of meals which is possible.
        /// </summary>
        [TestMethod]
        public void Case_OrderMoreThanAvailable() 
        {

            //Team needs: total 50 meals including 5 vegetarians and 7 gluten free.
            OrderWishList order = new OrderWishList(5, 7, 0, 0, 50);


            // Create Restaurants
            RestaurantsFactory factory = new RestaurantsFactory();
            factory.CreateRestaurant("B", 1, 1, 1, 0, 0, 2);
            factory.CreateRestaurant("A", 2, 1, 1, 0, 0, 2);

            OrderProcessor processor = new OrderProcessor(order, factory);
            List<MealsReadyForDelivery> totalOrders = processor.TotalOrders;



            // Expected first element at index 0
            // Restaurant A has a rating of 2/5 and can serve 1 vegetarian and 1 gluten free, total: 2
            RestaurantSignature expectS0 = new RestaurantSignature("A", 2);
            Dictionary<RestaurantMeal.MealType, int> expectD0 = new Dictionary<RestaurantMeal.MealType, int>
            {
                {RestaurantMeal.MealType.Vegetarian, 1 },
                {RestaurantMeal.MealType.GlutenFree, 1 },
            };
            MealsReadyForDelivery readyForDelivery0 = new MealsReadyForDelivery(expectS0, expectD0);



            // Expected second element at index 1
            // Restaurant B has a rating of 1 / 5 and can serve 1 vegetarian and 1 gluten free, total: 2
            RestaurantSignature expectS1 = new RestaurantSignature("B", 1);
            Dictionary<RestaurantMeal.MealType, int> expectD1 = new Dictionary<RestaurantMeal.MealType, int>
            {
                {RestaurantMeal.MealType.Vegetarian, 1 },
                {RestaurantMeal.MealType.GlutenFree, 1 },
            };
            MealsReadyForDelivery readyForDelivery1 = new MealsReadyForDelivery(expectS1, expectD1);



            // Check to see that expected meal orders results are the same, as actual
            Assert.AreEqual(totalOrders.Count, 2);
            Assert.IsTrue(Verifier.MealsReayForDeliveryAreEq(totalOrders[0], readyForDelivery0));
            Assert.IsTrue(Verifier.MealsReayForDeliveryAreEq(totalOrders[1], readyForDelivery1));
        }
    }
}
