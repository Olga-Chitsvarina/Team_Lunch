
namespace TeamLunch.Logic.Interfaces
{
    interface IRestaurantsFactory
    {
        /// <summary>
        /// This method compares parameter name with names of already created restaurants
        /// </summary>
        /// <param name="name">
        /// presumably unique name for the new restaurant
        /// </param>
        /// <returns>
        /// True: there is no restaurants with the same name: name is unique, can be used
        /// as a name for the new restaurant
        /// OR
        /// False: there is another restaurant with the same name: name is not unique
        /// </returns>
        bool IsUniqueName(string name);


        /// <summary>
        /// This method creates a new restaurant, if name, passed as a parameter is unique
        /// (there is no other restaurant with the same name) and other parameters are valid.
        /// It thows the exception if name is not unique
        /// </summary>
        /// <param name="name">
        /// Presumably unique name for the new restaurant
        /// </param>
        /// <param name="rating">
        /// Restaurant rating (0-5)
        /// </param>
        /// <param name="vegMealNum">
        /// Number of vegetarian meals restaurant can make today.
        /// Should be a nonnegative int
        /// </param>
        /// <param name="gluten3MealNum">
        /// Number of gluten-free meals restaurant can make today
        /// Should be a nonnegative int
        /// </param>
        /// <param name="nut3MealNum">
        /// Number of nut-free meals restaurant can make today
        /// Should be a nonnegative int
        /// </param>
        /// <param name="fish3MealNum">
        /// Number of fish-free meals restaurant can make today
        /// Should be a nonnegative int
        /// </param>
        /// <param name="totalMealNum">
        /// Total number of meals restaurant can make today
        /// Should be a nonnegative int and greater or equal to
        /// sum1 = vegetarian meals + gluten-free meals + nut-free meals + fish-free meals
        /// Toal number of meals = meals of type "other" + sum1
        /// </param>
        void CreateRestaurant(string name, int rating, int vegMealNum,
            int gluten3MealNum, int nut3MealNum, int fish3MealNum, int totalMealNum);
    }
}
