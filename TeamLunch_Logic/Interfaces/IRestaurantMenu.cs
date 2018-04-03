
namespace TeamLunch.Logic.Interfaces
{
    interface IRestaurantMenu
    {
        /// <summary>
        /// This method removes the meals from the menu of certain type
        /// </summary>
        /// <param name="mealType">
        /// One of the menu type, it may be: vegetarian, gluten-free, nut-free, fish-free, other
        /// </param>
        /// <param name="mealsNumToRemove">
        /// Number of meals that should be removed from the menu of type specified by the second 
        /// parameter. Assumption: the number of meals of this menu type, that restaurant 
        /// can make is greater or equal to mealsNumToRemove
        /// </param>
        void RemoveFromMenu(RestaurantMeal.MealType mealType, int mealsNumToRemove);
    }
}
