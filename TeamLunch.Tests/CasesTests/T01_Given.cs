using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLunch.Logic;

namespace TeamLunch.Tests.CasesTests
{
    [TestClass]
    public class T01_Given
    {
        private Verifier Verifier = new Verifier();

        /// <summary>
        /// This test checks the problem, given in the exercise description.
        /// Team needs: total 50 meals including 5 vegetarians and 7 gluten free.
        /// 
        /// Restaurants:
        /// Restaurant A has a rating of 5/5 and can serve 40 meals including 4 vegetarians
        /// Restaurant B has a rating of 3/5 and can serve 100 meals including 20 vegetarians, 
        /// and 20 gluten free
        /// 
        /// Expected meal orders: 
        /// Restaurant A (4 vegetarian + 36 others), 
        /// Restaurant B (1 vegetarian + 7 gluten free + 2 others)
        /// </summary>
        [TestMethod]
        public void Case_Given()
        {

            //Team needs: total 50 meals including 5 vegetarians and 7 gluten free.
            OrderWishList order = new OrderWishList(5, 7, 0, 0, 50);

            RestaurantsFactory factory = new RestaurantsFactory();
            factory.CreateRestaurant("A", 5, 4, 0, 0, 0, 40);
            factory.CreateRestaurant("B", 3, 20, 20, 0, 0, 100);

            OrderProcessor processor = new OrderProcessor(order, factory);

            List<MealsReadyForDelivery> totalOrders = processor.TotalOrders;



            // Expected first element at index 0
            // Restaurant A has a rating of 5/5 and can serve 4 vegetarians, 36 other.
            RestaurantSignature expectS0 = new RestaurantSignature("A", 5);
            Dictionary<RestaurantMeal.MealType, int> expectD0 = new Dictionary<RestaurantMeal.MealType, int>
            {
                {RestaurantMeal.MealType.Vegetarian, 4 },
                {RestaurantMeal.MealType.Other, 36 },
            };
            MealsReadyForDelivery readyForDelivery0 = new MealsReadyForDelivery(expectS0, expectD0);



            // Expected second element at index 1
            // Restaurant B has a rating of 3 / 5 and can serve 20 vegetarians, and 20 gluten free, 60 other.
            RestaurantSignature expectS1 = new RestaurantSignature("B", 3);
            Dictionary<RestaurantMeal.MealType, int> expectD1 = new Dictionary<RestaurantMeal.MealType, int>
            {
                {RestaurantMeal.MealType.Vegetarian, 1 },
                {RestaurantMeal.MealType.GlutenFree, 7 },
                {RestaurantMeal.MealType.Other, 2 },
            };
            MealsReadyForDelivery readyForDelivery1 = new MealsReadyForDelivery(expectS1, expectD1);


            // Check to see that expected meal orders results are the same, as actual
            Assert.AreEqual(totalOrders.Count, 2);
            Assert.IsTrue(Verifier.MealsReayForDeliveryAreEq(totalOrders[0], readyForDelivery0));
            Assert.IsTrue(Verifier.MealsReayForDeliveryAreEq(totalOrders[1], readyForDelivery1));
        }
    }
}
