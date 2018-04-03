using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLunch.Logic;

namespace TeamLunch.Tests.ObjectsTests
{
    /// <summary>
    /// This test class checks to see that RestaurantSignature class methods perform the
    /// intended functionality. It checks good cases only, that do not throw any exceptions.
    /// </summary>
    [TestClass]
    public class T01_G_RestaurantSignature
    {
        /// <summary>
        /// This method checks to see that it is possible to set a signature 
        /// rating, which is nonnegative and less than 6.
        /// </summary>
        [TestMethod]
        public void RestaurantSignature_RatingIsValid()
        {
            new RestaurantSignature("A", 0);
            new RestaurantSignature("A", 5);
            new RestaurantSignature("A", 3);
        }

        //===============================================================================

        /// <summary>
        /// This method checks to see that signature name and rating fields have expected values
        /// </summary>
        [TestMethod]
        public void RestaurantSignature_RatingAndNameAreValid()
        {
            RestaurantSignature restaurantSignature = new RestaurantSignature("A", 1);

            Assert.IsTrue(restaurantSignature.Name.Equals("A"));
            Assert.IsTrue(restaurantSignature.Rating == 1);
        }


        //===============================================================================

        /// <summary>
        /// This test checks too see that method Equals works properly:
        /// If signatures are the same, it returns true and false otherwise
        /// </summary>
        [TestMethod]
        public void RestaurantSignature_Equals()
        {
            // Create two different signatures using the same parameters
            RestaurantSignature S1 = new RestaurantSignature("A", 3);
            RestaurantSignature S2 = new RestaurantSignature("A", 3);

            // Based on how equals method is defined, true should be returned:
            Assert.IsTrue(S1.Equals(S2));

            // Create another signature with the same rating, but different name
            RestaurantSignature S3 = new RestaurantSignature("B", 3);

            // Based on how equals method is defined, false should be returned:
            // Since A is not the same as B
            Assert.IsFalse(S2.Equals(S3));

            // Create another signature with the same name, but different rating
            RestaurantSignature S4 = new RestaurantSignature("A", 4);

            // Based on how equals method is defined, false should be returned:
            // Since 3!= 4
            Assert.IsFalse(S2.Equals(S4));

            // Create another signature with different name and rating
            RestaurantSignature S5 = new RestaurantSignature("C", 1);

            // Based on how equals method is defined, false should be returned:
            // Since 3!= 4
            Assert.IsFalse(S2.Equals(S5));
        }
    }
}

