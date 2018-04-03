using System.Collections.Generic;
using System.Linq;
using TeamLunch.Logic;

namespace TeamLunch.Tests
{
    public class Verifier
    {

        // Check to see if dictionaries are equal:
        public bool DictionariesAreEq <TKey, TValue>(Dictionary<TKey,TValue> D1, Dictionary<TKey, TValue> D2)
        {
            if (D1.Count != D2.Count) { return false; };
            return D1.Keys.All(k => D2.ContainsKey(k) && D1[k].Equals(D2[k]));
        } 


        // Check to see if restaurants are equal:
        public bool RestaurantsAreEq(Restaurant R1, Restaurant R2)
        {
            if (! R1.Signature.Equals(R2.Signature)) { return false; }
            return (DictionariesAreEq(R1.Menu.MenuContent, R2.Menu.MenuContent));
        }


        // Check to see if lists of restaurants are equal:
        public bool ListsOfRestaurantsAreEq(List<Restaurant> L1, List<Restaurant> L2)
        {
            if (L1.Count != L2.Count) { return false; }

            foreach(Restaurant R in L1)
            {
                if (!L2.Contains(R)) { return false; }
            }
            return true;
        }
        

        //Check to see that meals ready for delivery are equal
        public bool MealsReayForDeliveryAreEq(MealsReadyForDelivery R1, MealsReadyForDelivery R2)
        {
            if (!R1.Signature.Equals(R2.Signature)) { return false; }

            return DictionariesAreEq(R1.ReadyMeals, R2.ReadyMeals);
        }  
    }
}
