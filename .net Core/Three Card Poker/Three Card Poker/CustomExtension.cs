using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public static class CustomExtension
    {

        public static int GetConsoleInputToInt(this string input)
        {
            var converted = 0;
            string error = string.Empty;
            do
            {
                try
                {
                    error = string.Empty;
                    converted = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    error = e.Message;
                    Console.WriteLine(e.Message);
                   

                }
            } while (string.IsNullOrEmpty(error)  ==  false);

           
            return converted;
        }

        public static string Reverse(this string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static List<IHand> GetHands(this string[] input)
        {
            var cards = input;
            var hands = new List<IHand>();
            foreach (var card in cards)
            {
                hands.Add(new Hand
                {
                    Rank = card[0].ToString().GetRank(),
                    Suit = card[1].ToString().GetSuit()
                });
            }
            return hands;
        }

        public static Rank GetRank(this string input)
        {
            switch(input.ToUpperInvariant())
            {
               
                case "J":
                    return Rank.Jack;
                case "Q":
                    return Rank.Queen;
                case "K":
                    return Rank.King;
                case "A":
                    return Rank.Ace;
                case "2":
                    return Rank.Two;
                case "3":
                    return Rank.Three;
                case "4":
                    return Rank.Four;
                case "5":
                    return Rank.Five;
                case "6":
                    return Rank.Six;
                case "7":
                    return Rank.Seven;
                case "8":
                    return Rank.Eight;
                case "9":
                    return Rank.Nine;
                default:
                    return Rank.None;

            }
           
        }


        public static Suit GetSuit(this string input)
        {
            switch (input.ToLowerInvariant())
            {
                case "h":
                    return Suit.Hearts;
                case "d":
                    return Suit.Diamonds;
                case "s":
                    return Suit.Spades;
                case "c":
                    return Suit.Clubs;
                default:
                    return Suit.None;

            }

        }

    }
}
