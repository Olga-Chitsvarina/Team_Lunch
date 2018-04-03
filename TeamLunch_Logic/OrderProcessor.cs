using System.Collections.Generic;
using System.Linq;

namespace TeamLunch.Logic
{
    public class OrderProcessor : Interfaces.IOrderProcessor
    {
        //===============================================================================
        // FIELDS, GETTERS and SETTERS

        public OrderWishList OrderWishList { get; set; } = new OrderWishList();
        public List<Restaurant> ListOfRestaurants { get; set; } = new List<Restaurant>();
        public List<MealsReadyForDelivery> TotalOrders { get; set; } = new List<MealsReadyForDelivery>();

        //===============================================================================
        // CONSTRUCTORS and SET-UP:
        public OrderProcessor() { }
        public OrderProcessor(OrderWishList orderWishList, RestaurantsFactory factory)
        {
            OrderWishList = orderWishList;
            SetListOfRestaurants(factory.ListOfRestaurants);
            ProcessOrder();
        }

        public void SetListOfRestaurants(List<Restaurant> listOfRestaurantsUnsorted)
        {
            ListOfRestaurants = listOfRestaurantsUnsorted.OrderByDescending(x => x.Signature.Rating).ToList();
        }


        //===============================================================================
        // PROCESSING ORDERS:

        public bool GoalIsSatisfied()
        {
            List<RestaurantMeal.MealType> dictionaryKeys = OrderWishList.MealsToOrder.Keys.ToList();
            int count = 0;
            foreach (RestaurantMeal.MealType mealType in dictionaryKeys)
            {
                int value = OrderWishList.MealsToOrder[mealType];
                count += value;
            }
            return count == 0;
        }


        public void ProcessOrder()
        {
           
            int numberOfRestaurants = ListOfRestaurants.Count;
            List<RestaurantMeal.MealType> mealTypesKeys = OrderWishList.MealsToOrder.Keys.ToList();

            int i = 0;
            while (i < numberOfRestaurants && !GoalIsSatisfied())
            {
                Restaurant restaurant = ListOfRestaurants.ElementAt(i);
                RestaurantSignature signature = restaurant.Signature;
                MealsReadyForDelivery mealsOrdered = new MealsReadyForDelivery(signature);

                
                foreach (RestaurantMeal.MealType typeX in mealTypesKeys)
                {
                    int expectedNumOfMeals = OrderWishList.MealsToOrder[typeX];
                    int actualNumOfMeals = restaurant.HandleOrder(typeX, expectedNumOfMeals);
                   
                    if (actualNumOfMeals > 0)
                    {
                        mealsOrdered.ReadyMeals.Add(typeX, actualNumOfMeals);
                        OrderWishList.MealsToOrder[typeX] = expectedNumOfMeals - actualNumOfMeals;
                    }
                }

                
                if (mealsOrdered.ReadyMeals.Count > 0)
                {
                    TotalOrders.Add(mealsOrdered);
                }

                i++;
            }
        }
    }
}

      

