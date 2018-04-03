using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLunch.Logic;

namespace TeamLunch.Tests.ObjectsTests
{
    /// <summary>
    /// This test class checks to see that RestaurantSignature class methods perform the
    /// intended functionality. It checks bad cases only, that throw exceptions.
    /// </summary>
    [TestClass]
    public class T01_B_RestaurantSignature 
    {

        /// <summary>
        /// This method checks to see that it is not possible to set a rating,
        /// which is negative
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            ("Rating cannot be negaive or greater than 5."))]
        public void RestaurantSignature_NegativeRating()
        {
            new RestaurantSignature("A", -1);
        }

        //===============================================================================

        /// <summary>
        /// This method checks to see that it is not possible to set a rating,
        /// which is greater than 5
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            ("Rating cannot be negaive or greater than 5."))]
        public void RestaurantSignature_RatingGreaterThan5()
        {
            new RestaurantSignature("A", 6);
        }

        //===============================================================================

        /// <summary>
        /// This method checks to see that it is not possible to set a signature 
        /// name, which is an empty string.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            ("Restaurant needs to have a name: cannot be an empty string"))]
        public void RestaurantSignature_NameIsEmptyStr()
        {
            new RestaurantSignature("", 2);
        }
    }
}
