using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamLunch.Logic
{
    public class RestaurantsFactory : Interfaces.IRestaurantsFactory
    {
        //===============================================================================
        // FIELDS, GETTERS and SETTERS

        public List<Restaurant> ListOfRestaurants { get; set; } = new List<Restaurant>();

        //===============================================================================
        // CONSTRUCTORS:

        public RestaurantsFactory() { }

        public RestaurantsFactory(List<Restaurant> restaurantsList)
        {
            ListOfRestaurants = restaurantsList;
        }

        //===============================================================================
        // ADD A NEW RESTAURANT

        public bool IsUniqueName(string name)
        {
            int i = 0;
            while (i < ListOfRestaurants.Count)
            {
                if (ListOfRestaurants.ElementAt(i).Signature.Name == name)
                {
                    return false;
                }
                i++;
            }
            return true;
        }


        public void CreateRestaurant(string name, int rating, int vegMealNum,
            int gluten3MealNum, int nut3MealNum, int fish3MealNum, int totalMealNum)
        {
            if (IsUniqueName(name))
            {
                Restaurant newRestaurant = new Restaurant(name, rating, vegMealNum,
                    gluten3MealNum, nut3MealNum, fish3MealNum, totalMealNum);

                ListOfRestaurants.Add(newRestaurant);
            }
            else
            {
                throw new ArgumentException("Restaurant name should be unique");
            }
        }
    }
}
