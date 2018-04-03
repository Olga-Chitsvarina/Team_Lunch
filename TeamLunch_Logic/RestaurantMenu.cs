using System;
using System.Collections.Generic;

namespace TeamLunch.Logic
{
    public class RestaurantMenu : Interfaces.IRestaurantMenu
    {
        //===============================================================================
        // FIELDS, GETTERS and SETTERS

        public Dictionary<RestaurantMeal.MealType, int> MenuContent { get; set; } 
       
        //===============================================================================
        // CONSTRUCTORS:

        public RestaurantMenu() { }
        public RestaurantMenu
            (int vegMealNum, int gluten3MealNum, int nut3MealNum, 
             int fish3MealNum, int totalMealNum)
        {
            int otherMealNum = totalMealNum - vegMealNum - gluten3MealNum - nut3MealNum - fish3MealNum;
            
            CheckValidityOfMealNum(new int [] { vegMealNum, gluten3MealNum, nut3MealNum, fish3MealNum, otherMealNum });

            MenuContent = new Dictionary<RestaurantMeal.MealType, int>()
            {
                { RestaurantMeal.MealType.Vegetarian, vegMealNum },
                { RestaurantMeal.MealType.GlutenFree, gluten3MealNum },
                { RestaurantMeal.MealType.NutFree, nut3MealNum},
                { RestaurantMeal.MealType.FishFree, fish3MealNum },
                { RestaurantMeal.MealType.Other, otherMealNum }
            };
        }

        //===============================================================================
        // REMOVING FROM MENU LISTS:
                        
        public void RemoveFromMenu (RestaurantMeal.MealType mealType, int mealsNumToRemove)
        {
            int currentNumberOfMeals = MenuContent[mealType];
            MenuContent[mealType] = currentNumberOfMeals - mealsNumToRemove;
        }

        /// <summary>
        /// This method checks the number of meals (of different types: vegetarian, gluten-free...other) 
        /// that restaurant can serve today.It throws the exception if one of the numbers is negative.
        /// </summary>
        /// <param name="mealNumbersOfEachType">
        /// array, containing a number of meals of each type, which a restaurant should 
        /// be able to serve today
        /// </param>
        private void CheckValidityOfMealNum(int [] mealNumbersOfEachType )
        {
            foreach (int x in mealNumbersOfEachType)
            {
                if (x < 0)
                {
                    throw new ArgumentException("Restaurant menu cannot have negative " +
                        "number of meals");
                }
            }
        }
    }
}
