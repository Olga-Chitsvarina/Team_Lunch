using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLunch.Logic;

namespace TeamLunch.Tests.ObjectsTests
{
    /// <summary>
    /// This test class checks to see that OrderWishList class methods perform the
    /// intended functionality. It checks good cases only, that do not throw exceptions.
    /// </summary>
    [TestClass]
    public class T05_G_OrderWishList
    {
        private Verifier Verifier = new Verifier();

        /// <summary>
        /// This method checks to see that OrderWishList object is created properly
        /// </summary>
        [TestMethod]
        public void OrderWishList_Constructor()
        {
            // Total number of meals is 15:
            // vegetarian - 5
            // gluten free - 4
            // nut free - 3
            // fish free - 2
            // other = 15 - 5 - 4 - 3 - 2 = 1
            OrderWishList orderWishList = new OrderWishList(5, 4, 3, 2, 15);


            // Expected dictionary of meals to order
            Dictionary<RestaurantMeal.MealType, int> expectedMealsToOrder =
                 new Dictionary<RestaurantMeal.MealType, int>
                 {
                    {RestaurantMeal.MealType.Vegetarian, 5 },
                    {RestaurantMeal.MealType.GlutenFree, 4 },
                    {RestaurantMeal.MealType.NutFree, 3 },
                    {RestaurantMeal.MealType.FishFree, 2 },
                    {RestaurantMeal.MealType.Other, 1}
                 };

            // Check to see if expected is the same as actual:
            Assert.IsTrue(Verifier.DictionariesAreEq(orderWishList.MealsToOrder, expectedMealsToOrder));      
        }
    }
}
