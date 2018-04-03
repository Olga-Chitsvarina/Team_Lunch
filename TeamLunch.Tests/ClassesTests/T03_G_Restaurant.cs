using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLunch.Logic;

namespace TeamLunch.Tests.ObjectsTests
{
    /// <summary>
    /// This test class checks to see that Restaurant class methods perform the
    /// intended functionality.
    /// </summary>
    [TestClass]
    public class T03_G_Restaurant
    {
        private Verifier Verifier = new Verifier();

        /// <summary>
        /// This method checks to see that restaurant cooks the maximum number of 
        /// meals which it can cook
        /// </summary>
        [TestMethod]
        public void Restaurant_HandleOrderMax()
        {
            // This restaurant can cook 80 others, and 5 meals of each kind (gluten free, fish fre...)
            // Total number of meals is 100
            Restaurant restaurant = new Restaurant("A", 4, 5, 5, 5, 5, 100);

            // As it was mentioned, restaurant can cook only 5 gluten free meals,
            // but below it is asked to cook 6 gluten free meals
            int mealsNumberOrdered = restaurant.HandleOrder(RestaurantMeal.MealType.GlutenFree, 6);


            // Since only 5 gluten free meals are available, number of meals ordered of this type is 5
            Assert.AreEqual(mealsNumberOrdered, 5);


            // This restaurant after handling the order should be the same as the one below
            // This restaurant can cook 80 others, 0 of gluten free, 5 meals of each other kind (fish fre...)
            // Total number of meals is 95 = 100 -5 (5 of gluten free were requested)
            Restaurant expectRestaurant = new Restaurant("A", 4, 5, 0, 5, 5, 95);

            // Check that the restaurants are equal
            Assert.IsTrue(Verifier.RestaurantsAreEq(restaurant, expectRestaurant));
        }

        //===============================================================================

        /// <summary>
        /// This method checks to see that restaurant cooks the same number of meals, that was requested
        /// </summary>
        [TestMethod]
        public void Restaurant_HandleOrderExact()
        {
            // This restaurant can cook 80 others, and 5 meals of each kind (gluten free, fish fre...)
            // Total number of meals is 100
            Restaurant restaurant = new Restaurant("A", 4, 5, 5, 5, 5, 100);

            // As it was mentioned, restaurant can cook only 5 gluten free meals,
            // but below it is asked to cook only 1 gluten free meal
            int mealsNumberOrdered = restaurant.HandleOrder(RestaurantMeal.MealType.GlutenFree, 1);

            //Since only 1 was ordered
            Assert.AreEqual(mealsNumberOrdered, 1);

            // This restaurant after handling the order should be the same as the one below
            // This restaurant can cook 80 others, 4 of gluten free, 5 meals of each other kind (fish fre...)
            // Total number of meals is 94 = 100 - 1 (1  of gluten free was requested)
            Restaurant expectRestaurant = new Restaurant("A", 4, 5, 4, 5, 5, 99);

            // Check that restaurants are equal
            Assert.IsTrue(Verifier.RestaurantsAreEq(restaurant, expectRestaurant));
        }
    }
}
