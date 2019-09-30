using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public class PairStrategy: HandStrategyBase
    {
        public override HandRanking HandRanking => HandRanking.Pair;
        public PairStrategy(IPlayer player):base(player)
        {
        }

        /// <summary>
        ///Rank5
        /// </summary>
        /// <param name="hands"></param>
        /// <returns></returns>
        internal override bool IsHand()
        {
            var isPair = hands.GroupBy(c => c.Rank).Any(g => g.Count() == 2);
            return isPair;
        }


    }
}
