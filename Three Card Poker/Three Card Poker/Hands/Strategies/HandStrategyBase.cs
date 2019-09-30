using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public abstract class HandStrategyBase : IHandStrategy
    {
        
        internal protected List<IHand> hands;
        internal protected IPlayer player;
        public bool IsPlayerHand => IsHand();

        public abstract HandRanking HandRanking { get; }

        public HandStrategyBase(IPlayer player)
        {
            this.player = player;
            this.hands = player.Hands;
          
            
        }

      

        abstract internal bool IsHand();
    }
}
