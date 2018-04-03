
namespace TeamLunch.Logic.Interfaces
{
    interface IRestaurant
    {
        /// <summary>
        /// This method checks the number of meals of defined type, which can be cooked today.
        /// Then it compares this number with the number of meals a customer wants to order, 
        /// it cooks the maximum possible number of meals (which restaurant can serve today,
        /// but not greater than the number of meals, which the customer wants to get).
        /// It updates the menu after cooking,
        /// since cooked meals are not longer available to other customers and returns the
        /// number of cooked meals.
        /// </summary>
        /// <param name="mealType">
        /// Stores the value of meal type that should be cooked
        /// </param>
        /// <param name="maxMeals">
        /// Stores the number of meals, which customer wants to order
        /// </param>
        /// <returns>
        /// Returned integer stores a number of meals, which restaurant was able to cook
        /// for a customer
        /// </returns>
        int HandleOrder(RestaurantMeal.MealType mealType, int maxMeals);
    }
}
