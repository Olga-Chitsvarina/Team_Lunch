using System;

namespace TeamLunch.Logic
{
    class CommunicationWithAUser
    {
        //===============================================================================
        // FIELDS:

        private OrderWishList OrderWishList;
        private RestaurantsFactory Factory = new RestaurantsFactory();
        private OrderProcessor OrderProcessor;


        //===============================================================================
        // CONSTRUCTORS:

        public CommunicationWithAUser()
        {
            PrintDivider();
            CreateOrder();
            PrintDivider();
            AddRestaurants();
           
            OrderProcessor = new OrderProcessor(OrderWishList, Factory);
            PrintDivider();
            DisplayResult();
        }
        
        //===============================================================================
        // CREATE ORDER WISH LIST
        public void CreateOrder()
        {
            int totalMealNum = PromptForInteger("Enter a total number of meals you wish to order:");
            int vegMealNum = PromptForInteger("Enter a number of vegetarian meals you wish to order:");
            int gluten3MealNum = PromptForInteger("Enter a number of gluten-free meals you wish to order:");
            int nut3MealNum = PromptForInteger("Enter a number of nut-free meals you wish to order:");
            int fish3MealNum = PromptForInteger("Enter a number of fish-free meals you wish to order:");

            try
            {
                OrderWishList = new OrderWishList(vegMealNum, gluten3MealNum, nut3MealNum, fish3MealNum, totalMealNum);
            }
            catch (Exception e)
            {
                PrintDivider();
                Console.WriteLine(e.Message);
                Console.WriteLine("Please try again...");
                CreateOrder();
            }
        }

        //===============================================================================
        // ADD RESTAURANS

        public void AddRestaurants()
        {
            int numberOfRestaurants = PromptForInteger("Please enter a number of restaurants you want to create");
            PrintDivider();

            int i = 0;
            while (i < numberOfRestaurants)
            {
                AddRestaurant(i+1);
                i++;
            }
        }

        public void AddRestaurant(int restaurantNumber)
        {

            try
            {
                Console.WriteLine($"Please enter information for the Restaurant number {restaurantNumber}");
                Console.WriteLine($"Restaurant name:");
                string name = Console.ReadLine();
                int rating = PromptForInteger("Restaurant rating (0-5):");

                int totalMealNum = 
                    PromptForInteger("Enter a total number of meals restaurant can serve today:");
                int vegMealNum = 
                    PromptForInteger("Enter a number of vegetarian meals, which restaurant can serve today:");
                int gluten3MealNum = 
                    PromptForInteger("Enter a number of gluten-free meals, which restaurant can serve today:");
                int nut3MealNum = 
                    PromptForInteger("Enter a number of nut-free meals, which restaurant can serve today:");
                int fish3MealNum = 
                    PromptForInteger("Enter a number of fish-free meals, which restaurant can serve today:");

                Factory.CreateRestaurant(name, rating, vegMealNum, gluten3MealNum, nut3MealNum, 
                                        fish3MealNum, totalMealNum);
            }
            catch(Exception e)
            {
                PrintDivider();
                Console.WriteLine(e.Message);
                Console.WriteLine("Please try again to create a restauran...");
                AddRestaurant(restaurantNumber);
            }  
        }

        //===============================================================================
        // PROMPT A USER FOR AN INTEGER

        public int PromptForInteger(string message)
        {
            Console.WriteLine(message);
            var strEntered = Console.ReadLine();
            if (int.TryParse(strEntered, out int numberEntered))
            {
                return numberEntered;
            }
            else
            {
                Console.WriteLine($"{strEntered} is not a number");
            }

            return PromptForInteger(message);
        }


        //===============================================================================
        // PRINTING:

        public void PrintDivider()
        {
            Console.WriteLine("==========================================================");
        }


        public void DisplayResult()
        {
            Console.WriteLine("RESULT OF YOUR ORDER:");
            foreach(MealsReadyForDelivery mealsReadyForDelivery in OrderProcessor.TotalOrders)
            {
                Console.WriteLine(mealsReadyForDelivery.ToString());
                Console.WriteLine("----------------------------------------------");
            }
        }
    }
}
