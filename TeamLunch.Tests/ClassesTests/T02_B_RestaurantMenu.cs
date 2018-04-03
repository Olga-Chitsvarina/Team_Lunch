using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLunch.Logic;

namespace TeamLunch.Tests.ObjectsTests
{
    /// <summary>
    /// This test class checks to see that RestaurantMenu class methods perform the
    /// intended functionality. It checks bad cases only, that throw exceptions.
    /// </summary>
    [TestClass]
    
    public class T02_B_RestaurantMenu
    {
        /// <summary>
        /// This test checks to see that number of meals cannot be negative
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), 
            ("Restaurant menu cannot have negative number of meals"))]
        public void RestauranMenu_NegNumOfMels()
        {
            new RestaurantMenu(2, 3, -1, 4, 10);
        }

        //===============================================================================

        /// <summary>
        /// This test checks to see that total number of meals is not less than the total
        /// of number of vegetarian, gluten free, nut free and fish free meals requested.
        /// In the case tested: gluten free = fish free = nut free= vegetarian = 1, other = 0
        /// total number of meals = 4, but total provided is 3. (3 less than 4)
        /// meals of type "other" = total number - all other types = 3 - 4 = -1 (not possible)
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            ("Restaurant menu cannot have negative number of meals"))]
        public void RestauranMenu_NegTotal()
        {
            new RestaurantMenu(1, 1, 1, 1, 3);
        }
    }
}
