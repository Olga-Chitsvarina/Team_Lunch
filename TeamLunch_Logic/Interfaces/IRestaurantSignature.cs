namespace TeamLunch.Logic.Interfaces
{
    interface IRestaurantSignature
    {
        /// <summary>
        /// This method compares two signatures: 
        /// both objects have the same type RestaurantSignature and also
        /// have the same name and rating, signatures are the same
        /// </summary>
        /// <param name="obj">
        /// presumably it is an instane of RestaurantSignature 
        /// </param>
        /// <returns>
        /// True: if signatures are the same,
        /// OR
        /// False: otherwise
        /// </returns>
        bool Equals(object obj);
    }
}
