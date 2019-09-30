using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Three_Card_Poker
{
    class Program
    {
        static void Main(string[] args)
        {


            /*string reverseExample = "Dhanush Kumar";
            reverseExample = reverseExample.Aggregate(new StringBuilder(), (o, p) => o.Insert(0, p)).ToString();

            string reverseExample2 = "Dhanush Kumar Paramanathan";
            reverseExample2 = reverseExample2.Reverse();*/

            var numberOfPlayers = 0;
            //var input = Console.ReadLine();
            do
            {
                try
                {
                    //var test2 = Console.ReadLine().GetConsoleInputToInt();
                   numberOfPlayers = Convert.ToInt32(Console.ReadLine());
                   // numberOfPlayers = input.GetConsoleInputToInt();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                   
                }
            } while (numberOfPlayers < 1);

            if (numberOfPlayers < 1 || numberOfPlayers > 23)
                {
                    //To do: Log it to file
                    Console.WriteLine("You can only have players between 1-23");
                    Console.ReadLine();
                    return;
                }

                var players = new List<IPlayer>();
                //if number of players fall within the specifcation, go to the next step to assign cards to players
                DealerHelper.AssignCardsToPlayers(numberOfPlayers, players);
                //once assigned call dealer to find the winner(s)
                var winnerOrTiedWinners = DealerHelper.GetWinnerOrTiedWinners(players);
                //announce winner(s)
                Console.WriteLine("");
                Console.WriteLine(winnerOrTiedWinners);
                Console.ReadLine();
          
        }

       
        

       

       


     


       

     
       

    }
}
