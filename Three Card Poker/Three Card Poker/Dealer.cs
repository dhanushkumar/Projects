using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public class Dealer
    {
        private readonly List<IPlayer> players;
        public Dealer(List<IPlayer> players)
        {
            this.players = players;
        }
       
        public void RankPlayerHands()
        {
            //needs to be refactored so that the porker class is instantiated outside the loop
            foreach(var player in players)
            {
                var poker = new ThreeCardPoker(player);
                poker.PlayHand();
            }
        }

        public IEnumerable<IPlayer> GetWinners()
        {
            var groupedPlayersByRanking = players.GroupBy(p => p.Result.HandRanking).Select( group => new { group.Key, Items = group.ToList() }).OrderBy(g => g.Key);
            var winningGroupPlayersByRanking = groupedPlayersByRanking.FirstOrDefault();
          
            if (winningGroupPlayersByRanking.Items.Count > 1)
            {
                return GetWinnersFromGroup(winningGroupPlayersByRanking.Items);
            }
            return winningGroupPlayersByRanking.Items;
        }

        /// <summary>
        /// Get winners from the same typ High Card for high card
        /// </summary>
        /// <param name="players"></param>
        private IEnumerable<IPlayer> GetWinnersFromGroup(List<IPlayer> players)
        {
            var winningRankGroup = GetHighHandWinners(players).FirstOrDefault();
            do
            {
                var hands = players.Select(i => i.Hands);
                foreach(var group in winningRankGroup.Items)
                { 
                    foreach(var hand in hands)
                    {
                       hand.RemoveAll(h => (int)h.Rank == group.Rank); //remove all equal cards till we have none (a tie!)
                    }
                }
                winningRankGroup = GetHighHandWinners(players).FirstOrDefault();
            }
            while (winningRankGroup.Items.Count > 1 && winningRankGroup.Items[0].Rank != 0); //recurse till we have a tie or an individual
            return players.OrderBy(i => i.Id).Select(i => i); // return multiple players (if any) in ascending order
        }

        private IEnumerable<dynamic> GetHighHandWinners(List<IPlayer> players)
        {
            var winningRank = players
                .Select(i => new
                {
                    Id = i.Id,
                    Rank = i.Hands.Select(r => (int)r.Rank).OrderByDescending(r => r)
                   .FirstOrDefault()
                }).OrderByDescending( i=>i.Rank).GroupBy(i => i.Rank).Select(i => new { Items = i.ToList() });

            PurgeNonWinners(players,winningRank.Skip(1)); //The first one is always the winner. Only a group or an individual is selected

            return winningRank;
        }

        
        /// <summary>
        /// Elimates the low scoring players
        /// </summary>
        /// <param name="players"></param>
        /// <param name="nonWinners"></param>
        private void PurgeNonWinners(List<IPlayer> players, IEnumerable<dynamic> nonWinners)
        {
            foreach (var player in nonWinners)
            {
                foreach (var item in player.Items)
                {
                    players.RemoveAll(x => x.Id == item.Id);
                }
            }
        }
    }
}
