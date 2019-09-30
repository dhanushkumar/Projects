using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public class ThreeCardPoker
    {
        private readonly IPlayer player;
        private List<IHandStrategy> strategies = new List<IHandStrategy>();


        public ThreeCardPoker(IPlayer player)
        {
            this.player = player;
            Add();
        }
            

        public void Add()
        {
            //need to refactor to create a proper context for the strategy
            strategies.Add(new HighCardStrategy(player));
            strategies.Add(new StraightFlushStrategy(player));
            strategies.Add(new ThreeOfAKindStrategy(player));
            strategies.Add(new StraightStrategy(player));
            strategies.Add(new FlushStrategy(player));
            strategies.Add(new PairStrategy(player));
        }

        public void PlayHand()
        {
            // sorted based on ranking
            strategies = strategies.OrderBy(i => i.HandRanking).ToList();
            foreach (var handRank in strategies)
            {
                if (handRank.IsPlayerHand)
                {
                    player.Result.HandRanking = handRank.HandRanking;
                    return;
                }
            }
        }
    }
}
