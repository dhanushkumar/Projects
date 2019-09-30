using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public class ThreeOfAKindStrategy : HandStrategyBase
    {
        public override HandRanking HandRanking => HandRanking.ThreeOfAKind;
        public ThreeOfAKindStrategy(IPlayer player) : base(player)
        {
        }

        /// <summary>
        ///Rank2
        /// </summary>
        /// <param name="hands"></param>
        /// <returns></returns>
        internal override bool IsHand()
        {
            var rank = hands.FirstOrDefault().Rank;
            return hands.All(i => i.Rank == rank);
        }

    }
}

