using System;
using System.Collections.Generic;

namespace TeamLunch.Logic
{
    public class RestaurantSignature: Interfaces.IRestaurantSignature
    {
        //===============================================================================
        // FIELDS, GETTERS and SETTERS

        private string name = "";
        public string Name
        {
            get { return name; }
            set {
                if (value.Equals(""))
                {
                    throw new ArgumentException("Restaurant needs to have a name: cannot be an empty string");
                }
                name = value;
            }
        }

        private int rating = 0;
        public int Rating
        {
            get { return rating; }
            set
            {
                if (value < 0 || value > 5)
                {
                    throw new ArgumentException("Restaurant rating cannot be negaive or greater than 5.");
                }
                rating = value;
            }
        }

        //===============================================================================
        // CONSTRUCTORS:

        public RestaurantSignature() { }
        public RestaurantSignature(string name, int rating)
        {
            Name = name;
            Rating = rating;
        }

        //==============================================================================
        // EQUALS

        public override bool Equals(object obj)
        {
            if (!(obj is RestaurantSignature anotherSignature))
            {
                return false;
            }

            return (this.Name.Equals(anotherSignature.Name) && 
                    this.Rating == anotherSignature.Rating);
        }
    }
}
