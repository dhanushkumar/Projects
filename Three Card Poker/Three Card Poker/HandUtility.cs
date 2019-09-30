using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public static class HandUtility
    {
        public static List<int> GeOrderedRanksAsIntegers(List<IHand> hands)
        {
            var ranks = hands.Select(i => (int)i.Rank).OrderBy(i => i).ToList();
            return ranks;

        }

        public static void ConvertOrOneDefault(List<int> ranks)
        {
            if (ranks.FirstOrDefault() == 2 && ranks.Contains(14))
            {
                ranks.Remove(14);
                ranks.Insert(0, 1);
            }

        }


    }
}
