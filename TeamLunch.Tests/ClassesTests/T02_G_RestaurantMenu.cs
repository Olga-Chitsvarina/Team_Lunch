using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLunch.Logic;

namespace TeamLunch.Tests.ObjectsTests
{
    /// <summary>
    /// This test class checks to see that RestaurantMenu class methods perform the
    /// intended functionality. It checks good cases only, that do not throw exceptions.
    /// </summary>
    [TestClass]

    public class T02_G_RestaurantMenu
    {
        private Verifier Verifier = new Verifier();

        /// <summary>
        /// This test checks to see that RemoveFromMenu function removes the 
        /// correct number of meals of certain type from the menu.
        /// </summary>
        [TestMethod]
        public void RestauranMenu_RemoveFromMenu()
        {
            // Create the object for a test
            Dictionary<RestaurantMeal.MealType, int> menuContent =
            new Dictionary<RestaurantMeal.MealType, int>
            {
                {RestaurantMeal.MealType.Vegetarian, 5},
                {RestaurantMeal.MealType.GlutenFree, 10}
            };

            RestaurantMenu restaurantMenu = new RestaurantMenu();
            restaurantMenu.MenuContent = menuContent;

            //Remove 5 gluten free meals
            restaurantMenu.RemoveFromMenu(RestaurantMeal.MealType.GlutenFree, 5);

            // Create expected dictionary
            Dictionary<RestaurantMeal.MealType, int> expectMenuContent =
           new Dictionary<RestaurantMeal.MealType, int>
           {
                {RestaurantMeal.MealType.Vegetarian, 5},
                {RestaurantMeal.MealType.GlutenFree, 5}
           };

            // Test if they are the same
            Assert.IsTrue(Verifier.DictionariesAreEq(menuContent, expectMenuContent));
        }
    }
}
