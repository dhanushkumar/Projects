using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public interface IHand
    {
        Suit Suit { get; set; }
        Rank Rank { get; set; }
    }

    public enum Rank
    {
        None = 0,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14 //can be also 1
    }


  
    public enum Suit
    {
        None,
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }

  
    /// <summary>
    /// Set the ranking here for every new hand
    /// </summary>
    public enum HandRanking
    {
        HighCard =6,
        StraightFlush = 1,
        ThreeOfAKind = 2,
        Straight =3,
        Flush = 4,
        Pair = 5
        

    }
}
