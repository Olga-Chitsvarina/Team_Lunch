using System;
using System.Collections.Generic;


namespace TeamLunch.Logic
{
    public class OrderWishList: Interfaces.IOrderWishList
    {
        //===============================================================================
        // FIELDS, GETTERS and SETTERS

        public Dictionary<RestaurantMeal.MealType, int> MealsToOrder { get; set; }
        public List<int> arrayOfMealNumbers = new List<int>();
        //===============================================================================
        // CONSTRUCTORS:

        public OrderWishList() { }
        public OrderWishList(int vegMealNum, int gluten3MealNum, int nut3MealNum, 
            int fish3MealNum, int totalMealNum)
        {
            int otherMealNum = totalMealNum - vegMealNum - gluten3MealNum - nut3MealNum - fish3MealNum;
            arrayOfMealNumbers = new List<int> { vegMealNum, gluten3MealNum, nut3MealNum, fish3MealNum, otherMealNum };
            CheckValidityOfMealNum();

            MealsToOrder = new Dictionary<RestaurantMeal.MealType, int>()
            {
                { RestaurantMeal.MealType.Vegetarian, vegMealNum },
                { RestaurantMeal.MealType.GlutenFree, gluten3MealNum },
                { RestaurantMeal.MealType.NutFree, nut3MealNum},
                { RestaurantMeal.MealType.FishFree, fish3MealNum },
                { RestaurantMeal.MealType.Other, otherMealNum }
            };
        }

        //===============================================================================
        // CHECK VALIDITY:

        public void CheckValidityOfMealNum()
        {
            foreach (int x in arrayOfMealNumbers)
            {
                if (x < 0)
                {
                    throw new ArgumentException("You cannot order negative number of meals");
                }
            }
        }
    }
}
