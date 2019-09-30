using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public class StraightStrategy : HandStrategyBase
    {
        public override HandRanking HandRanking => HandRanking.Straight;
        public StraightStrategy(IPlayer player):base(player)
        {
        }

        /// <summary>
        ///Rank3
        /// </summary>
        /// <param name="hands"></param>
        /// <returns></returns>
        internal override bool IsHand()
        {
            var previousHand = 0;
            var ranks = HandUtility.GeOrderedRanksAsIntegers(hands);
            HandUtility.ConvertToOneOrDefault(ranks); //Utility to convert to Ace to either Ace or One
       

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


    }
}
    
