using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    //TO BE DELETED
   public  class Accessor
    {

        /// <summary>
        ///Rank1
        /// </summary>
        /// <param name="hands"></param>
        /// <returns></returns>
        private static bool IsStraightFlush(List<IHand> hands)
        {
            hands = hands.OrderBy(i => i.Rank).ToList();
            List<int> array = hands.Select(i => (int)i.Rank).OrderBy(i => i).ToList();

            var suit = hands.FirstOrDefault().Suit;
            var isSameSuit = hands.All(i => i.Suit == suit);
            var isSequential = array.Zip(array.Skip(1), (a, b) => (a + 1) == b).All(x => x);
            //Array.Reverse(array);
            return isSameSuit && isSequential;
        }

        /// <summary>
        /// Rank 2
        /// </summary>
        /// <param name="hands"></param>
        /// <returns></returns>
        private static bool IsThreeOfAKind(List<IHand> hands)
        {
            var rank = hands.FirstOrDefault().Rank;
            return hands.All(i => i.Rank == rank);
        }

        /// <summary>
        /// Rank3
        /// </summary>
        /// <param name="hands"></param>
        /// <returns></returns>
        private static bool IsStraight(List<IHand> hands)
        {
            var previousHand = 0;
            //var ranks = hands.Select(i => (int)i.Rank).OrderBy(i => i).ToList();
            var ranks = HandUtility.GeOrderedRanksAsIntegers(hands);
            HandUtility.ConvertOrOneDefault(ranks);
            //if (ranks.FirstOrDefault() == 2 && ranks.Contains(14))
            //{
            //    ranks.Remove(14);
            //    ranks.Insert(0, 1);
            //}

            for (int i = 0; i < 3; i++)
            {
                if (previousHand > 0 && ranks[i] - 1 != previousHand)
                {
                    return false;
                }
                previousHand = ranks[i];
            }
            return true;
        }
        
        /// <summary>
        /// Rank 4
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public static bool IsFlush(List<IHand> cards)
        {
            var suit = cards.FirstOrDefault().Suit;
            return cards.All(i => i.Suit == suit);
        }

        /// <summary>
        /// Rank 5
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public static bool IsPair(List<IHand> cards)
        {
            var isPair = cards.GroupBy(c => c.Rank).Any(g => g.Count() == 2);
            return isPair;

        }

        /// <summary>
        /// Rank 6 or Default
        /// </summary>
        /// <returns></returns>
        public static bool IsHighCard()
        {
            return true;
        }

    }
}
