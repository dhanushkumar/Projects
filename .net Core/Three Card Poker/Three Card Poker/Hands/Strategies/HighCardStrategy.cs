using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public class HighCardStrategy :  HandStrategyBase
    {
        public override HandRanking HandRanking => HandRanking.HighCard;
        public HighCardStrategy(IPlayer player):base(player)
        {
           
        }

        /// <summary>
        ///Rank6 or Default. Will return true if none of the hands meets the criteria
        /// </summary>
        /// <param name="hands"></param>
        /// <returns></returns>
        internal override bool IsHand()
        {
            return true;
        }
    }
}