using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public class StraightFlushStrategy : HandStrategyBase
    {
        public override HandRanking HandRanking => HandRanking.StraightFlush;
        public StraightFlushStrategy(IPlayer player):base(player)
        {
        }

        /// <summary>
        ///Rank1
        /// </summary>
        /// <param name="hands"></param>
        /// <returns></returns>
        internal override bool IsHand()
        {
            hands = hands.OrderBy(i => i.Rank).ToList();
            if(hands.Count > 0)
            { 
                List<int> array = hands.Select(i => (int)i.Rank).OrderBy(i => i).ToList();
                var suit = hands.FirstOrDefault().Suit;
                var isSameSuit = hands.All(i => i.Suit == suit);
                var isSequential = array.Zip(array.Skip(1), (a, b) => (a + 1) == b).All(x => x);
                return isSameSuit && isSequential;

            }
            return false;
        }


    }
}
