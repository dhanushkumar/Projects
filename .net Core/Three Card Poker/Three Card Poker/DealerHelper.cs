using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Three_Card_Poker
{
    public static class DealerHelper
    {
        /// <summary>
        /// This method could use a lot of refactoring. unfortunately running short of time
        /// </summary>
        /// <param name="numberOfPlayers"></param>
        /// <param name="players"></param>
        public static void AssignCardsToPlayers(int numberOfPlayers, List<IPlayer> players)
        {
            do
            {
                //while request for each player info and assign cards
                for (int i = 1; i <= numberOfPlayers; i++)
                {
                    string line;
                    line = Console.ReadLine();
                    var playerAndAssignedCards = line.Split(' ');
                    if (playerAndAssignedCards.Count() < 4 || playerAndAssignedCards.Count() > 4)
                    {
                        return;
                        //log error
                    }
                    if(string.IsNullOrEmpty(playerAndAssignedCards[0]))
                    {
                        return;
                        //log error
                    }

                    try { 
                        var playerId = Convert.ToInt32(playerAndAssignedCards[0]);//First one is always the ID
                        var setOfCards = playerAndAssignedCards.Skip(1).ToArray();//skip the first one as the rest three are the set of cards
                        if(setOfCards.Count()<3 || setOfCards.Count() > 3)
                        {
                            return;
                        }
                        players.Add(new Player { Hands = setOfCards.GetHands(), Id = playerId, Result = new Result() });// Convert array to appropriate Ranks and suits and assign it to the player
                    }
                    catch
                    {
                        //log error
                        return;
                    }

                }
            }
            while (players.Count() <= numberOfPlayers - 1);
        }

        /// <summary>
        /// returns a winner or space separated winners who are tied
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public static string GetWinnerOrTiedWinners(List<IPlayer> players)
        {
            var sb = new StringBuilder();
            if (players.Count > 0)
            {
                var dealer = new Dealer(players);
                dealer.RankPlayerHands();
                var winners = dealer.GetWinners().ToList();

               
                foreach (var winner in winners)
                {
                    if (winner != winners.Last())
                    {
                        sb.Append(winner.Id + " ");
                    }
                    else
                    {
                        sb.Append(winner.Id);
                    }

                }
              
            }
            return sb.ToString();
        }

    }


}
