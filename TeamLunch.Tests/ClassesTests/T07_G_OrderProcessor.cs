using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLunch.Logic;

namespace TeamLunch.Tests.ObjectsTests
{
    /// <summary>
    /// This test class checks to see that OrderProcessor class methods perform the
    /// intended functionality. It checks good cases only, that do not throw any exceptions.
    /// </summary>
    [TestClass]
    public class T07_G_OrderProcessor
    {
        private Verifier Verifier = new Verifier();

        /// <summary>
        /// This test checks to see that OrderProcessor's ListOfRestaurants stores 
        /// restaurants in decsending order
        /// </summary>
        [TestMethod]
        public void ObjectProcessor_SetListOfRestaurants()
        {
            // Create order processor:
            OrderProcessor orderProcessor = new OrderProcessor();


            // Restaurants to pass to the function:
            // Restaurant A: rating 1
            // Restaurant B: rating 2
            // Restaurant C: rating 0
            // Restaurant D: rating 2
            // Restaurant E: rating 3
            Restaurant RA = new Restaurant("A", 1, 0, 0, 0, 0, 0);
            Restaurant RB = new Restaurant("B", 2, 0, 0, 0, 0, 0);
            Restaurant RC = new Restaurant("C", 0, 0, 0, 0, 0, 0);
            Restaurant RD = new Restaurant("D", 2, 0, 0, 0, 0, 0);
            Restaurant RE = new Restaurant("E", 3, 0, 0, 0, 0, 0);


            // Pass list to the function:
            orderProcessor.SetListOfRestaurants(new List<Restaurant> { RA, RB, RC, RD, RE });


            // Expected list of restaurants (sorted by rating):
            // Restaurants in descending order:
            // Restaurant E: rating 3
            // Restaurant B: rating 2
            // Restaurant D: rating 2
            // Restaurant A: rating 1
            // Restaurant C: rating 0
            List<Restaurant> expectedLofR = new List<Restaurant> { RE, RB, RD, RA, RC };

            // Check to see that lists of restaurants are the same
            Assert.IsTrue(Verifier.ListsOfRestaurantsAreEq(orderProcessor.ListOfRestaurants, expectedLofR));
        }



        //===============================================================================



        /// <summary>
        /// This test checks to see that GoalIsSatisfied method detects correctly that 
        /// not all meals have been ordered yet
        /// </summary>
        [TestMethod]
        public void ObjectProcessor_GoalIsSatisfied()
        {
            // Create order processor:
            OrderProcessor orderProcessor = new OrderProcessor();

            // Create a wish list, where 1 nut free meal should be still ordered
            OrderWishList orderWishList = new OrderWishList();
            orderWishList.MealsToOrder = new Dictionary<RestaurantMeal.MealType, int>
            {
                {RestaurantMeal.MealType.Vegetarian, 0 },
                {RestaurantMeal.MealType.GlutenFree, 0 },
                {RestaurantMeal.MealType.NutFree, 1 },
                {RestaurantMeal.MealType.FishFree, 0 },
                {RestaurantMeal.MealType.Other, 0 },
            };


            // Add a wish list to order processor
            orderProcessor.OrderWishList = orderWishList;


            // Check that order processor detects that something should be still ordered:
            Assert.IsFalse(orderProcessor.GoalIsSatisfied());
        }



        //===============================================================================


        /// <summary>
        /// This test checks to see that GoalIsSatisfied method detects correctly that 
        /// not all meals have been ordered yet
        /// </summary>
        [TestMethod]
        public void ObjectProcessor_ProcessOrder()
        {
            // Create order processor:
            OrderProcessor orderProcessor = new OrderProcessor();

            // Create a wish list, where 3 nut free meal should be still ordered
            OrderWishList orderWishList = new OrderWishList();
            orderWishList.MealsToOrder = new Dictionary<RestaurantMeal.MealType, int>
            {
                {RestaurantMeal.MealType.Vegetarian, 0 },
                {RestaurantMeal.MealType.GlutenFree, 0 },
                {RestaurantMeal.MealType.NutFree, 3 },
                {RestaurantMeal.MealType.FishFree, 0 },
                {RestaurantMeal.MealType.Other, 0 },
            };


            // Add a wish list to order processor
            orderProcessor.OrderWishList = orderWishList;

            // Add a restaurant to order processor, which has 4 nut free meals
            orderProcessor.ListOfRestaurants.Add(new Restaurant("A", 5, 0, 0, 4, 0, 4));

            // Process order
            orderProcessor.ProcessOrder();

            // Check that order processor has processed the order properly
            // It is supposed that 3 nut free meals were ordered from the restaurant A
            MealsReadyForDelivery mealsReadyForDelivery = orderProcessor.TotalOrders[0];

            // Expected:
            RestaurantSignature expectSignature = new RestaurantSignature("A", 5);
            Dictionary<RestaurantMeal.MealType, int> expectReadyMeals =
                new Dictionary<RestaurantMeal.MealType, int>
                {
                    {RestaurantMeal.MealType.NutFree, 3 }
                };

            // Check that actual is the same as expected:
            Assert.IsTrue(mealsReadyForDelivery.Signature.Equals(expectSignature));
            Assert.IsTrue(Verifier.DictionariesAreEq(mealsReadyForDelivery.ReadyMeals, expectReadyMeals));
        }
    }
}
