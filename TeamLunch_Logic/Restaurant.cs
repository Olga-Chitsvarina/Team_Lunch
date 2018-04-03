using System;

namespace TeamLunch.Logic 
{
    public class Restaurant : Interfaces.IRestaurant
    {
        //===============================================================================
        // FIELDS, GETTERS and SETTERS

        public RestaurantSignature Signature { get; set; }
        public RestaurantMenu Menu { get; set; }
        
        //===============================================================================
        // CONSTRUCTORS:

        public Restaurant(){}
        public Restaurant(string name, int rating, int vegMealNum, 
            int gluten3MealNum, int nut3MealNum, int fish3MealNum, int totalMealNum)
        {
            Signature = new RestaurantSignature(name, rating);
            Menu = new RestaurantMenu(vegMealNum, gluten3MealNum, nut3MealNum, fish3MealNum, totalMealNum);
        }

        //================================================================================
        // HANDLE ORDER
        public int HandleOrder (RestaurantMeal.MealType mealType, int maxMeals)
        {
            int availableMealsOfThisType = Menu.MenuContent[mealType];
            int cookedMeals = Math.Min(availableMealsOfThisType, maxMeals);
            Menu.RemoveFromMenu(mealType, cookedMeals);

            return cookedMeals;
        }
    }
}
