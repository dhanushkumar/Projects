using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public static class HandUtility
    {
        /// <summary>
        /// Order ranks as integers for the given hand. Helpful to rank them and not worry about integers and strings seaparately
        /// </summary>
        /// <param name="hands"></param>
        /// <returns></returns>
        public static List<int> GeOrderedRanksAsIntegers(List<IHand> hands)
        {
            var ranks = hands.Select(i => (int)i.Rank).OrderBy(i => i).ToList();
            return ranks;

        }

        /// <summary>
        /// converts to one or default. Used for Ace conversion
        /// </summary>
        /// <param name="ranks"></param>
        public static void ConvertToOneOrDefault(List<int> ranks)
        {
            if (ranks.FirstOrDefault() == 2 && ranks.Contains(14))
            {
                ranks.Remove(14);
                ranks.Insert(0, 1);
            }

        }


    }
}
