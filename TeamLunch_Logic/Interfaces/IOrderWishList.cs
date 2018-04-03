
namespace TeamLunch.Logic.Interfaces
{
    interface IOrderWishList
    {
        /// <summary>
        /// This method checks the array of numbers of meals of certain type.
        /// It is not possible to order negative numbers of meals, thus it 
        /// throws an exception if at least one of the numbers is negative
        /// </summary>
        void CheckValidityOfMealNum();
    }
}
