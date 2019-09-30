using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    class FlushStrategy: HandStrategyBase
    {
        public override HandRanking HandRanking => HandRanking.Flush;
        public FlushStrategy(IPlayer player):base(player)
        {
           
        }

        /// <summary>
        ///Rank4
        /// </summary>
        /// <param name="hands"></param>
        /// <returns></returns>
        internal override bool IsHand()
        {
            var suit = hands.FirstOrDefault().Suit;
            return hands.All(i => i.Suit == suit);
        }


    }
}