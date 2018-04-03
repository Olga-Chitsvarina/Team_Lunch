
using System.Collections.Generic;

namespace TeamLunch.Logic.Interfaces
{
    interface IOrderProcessor
    {
        /// <summary>
        /// This method takes a list of restaurants, sorts them by rating, so that
        /// restaurants with higher rating go first. It assignes the resulted list
        /// of sorted restaurants to the ListOfRestaurants field.
        /// </summary>
        /// <param name="listOfRestaurantsUnsorted">
        /// List of restaurants in random order (not sorted)
        /// </param>
        void SetListOfRestaurants(List<Restaurant> listOfRestaurantsUnsorted);



        /// <summary>
        /// This method checks a wish list in order to find out if more meals should be ordered
        /// from the restaurants.
        /// </summary>
        /// <returns>
        /// True: no need to check other restaurants, all items from the wish list have been ordered.
        /// OR
        /// False: not all items from the wish list have been ordered, check other restaurants.
        /// </returns>
        bool GoalIsSatisfied();



        /// <summary>
        /// Get a number of restaurants and food categories
        /// While there are unchecked restaurants,
        /// or goal of ordering all meals from the wish list has not been satisfied,
        /// do the following:
        /// Take a restaurant from the list
        /// For each category of meals, try to order food from that restaurant
        /// If was able to order some type of meals, prepare food for delivery
        /// If something was ordered from the restaurant, store it in the total list of ordered 
        /// meals from all restaurants with the restaurant signature
        /// </summary>
        void ProcessOrder();
    }
}
