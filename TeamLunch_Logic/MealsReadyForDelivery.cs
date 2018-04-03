using System.Collections.Generic;
using System.Linq;

namespace TeamLunch.Logic
{
    public class MealsReadyForDelivery
    {
        //===============================================================================
        // FIELDS, GETTERS and SETTERS

        public RestaurantSignature Signature { get; set; } = new RestaurantSignature();
        public Dictionary <RestaurantMeal.MealType, int> ReadyMeals { get; set; }

        //===============================================================================
        // CONSTRUCTORS:
        public MealsReadyForDelivery() { }


        public MealsReadyForDelivery(RestaurantSignature signature)
        {
            ReadyMeals =  new Dictionary<RestaurantMeal.MealType, int>();
            Signature = signature;
        }


        public MealsReadyForDelivery(RestaurantSignature signature, 
            Dictionary<RestaurantMeal.MealType,int> readyMeals): this(signature)
        {
            ReadyMeals = readyMeals;
        }

        //===============================================================================
        // FOR PRINTING:

        public override string ToString()
        {
            string restaurantInfo = "Order details from the Restaurant " + Signature.Name + "\n";
            string orderInfo = "";
            List<RestaurantMeal.MealType> dictionaryKeys = ReadyMeals.Keys.ToList();
            foreach(RestaurantMeal.MealType key in dictionaryKeys)
            {
                orderInfo += key + ": " + ReadyMeals[key] + "\n";
            }

            return restaurantInfo + orderInfo;
        }
    }
}
