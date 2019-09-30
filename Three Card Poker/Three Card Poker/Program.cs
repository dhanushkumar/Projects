using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    class Program
    {
        static void Main(string[] args)
        {
           
          var playerCount = Console.ReadLine();
          var numberOfPlayers = 0;
           try
            {
                numberOfPlayers = Convert.ToInt32(playerCount);
            }
            catch
            {
                return;
            }
            if(numberOfPlayers < 1 || numberOfPlayers > 23)
            {
                return;
            }

            var players = new List<IPlayer>();
            //if number of players fall within the specifcation, go to the next step to assign cards to players
            AssignCardsToPlayers(numberOfPlayers, players);
            //once assigned call judge to find the winner(s)
            var winnerOrTiedWinners = GetWinnerOrTiedWinners(players);
            //announce winner(s)
            Console.WriteLine("");
            Console.WriteLine(winnerOrTiedWinners);
            Console.ReadLine();
        }

        private static string GetWinnerOrTiedWinners(List<IPlayer> players)
        {
            var dealer = new Dealer(players);
            dealer.RankPlayerHands();
            var winners = dealer.GetWinners().ToList();
           
            var sb = new StringBuilder();
            foreach (var winner in winners)
            {
                if(winner != winners.Last())
                {
                    sb.Append(winner.Id + " ");
                }
                else
                {
                    sb.Append(winner.Id);
                }
                
            }
            return sb.ToString();
        }

        private static void AssignCardsToPlayers(int numberOfPlayers, List<IPlayer> players)
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
                    }

                    var playerId = Convert.ToInt32(playerAndAssignedCards[0]);//First one is always the ID
                    var setOfCards = playerAndAssignedCards.Skip(1).ToArray();//skip the first one as the rest three are the set of cards
                    players.Add(new Player { Hands = setOfCards.GetHands(), Id = playerId, Result = new Result() });

                }
            }
            while (players.Count() <= numberOfPlayers - 1);
        }

       

       


     


       

     
       

    }
}
