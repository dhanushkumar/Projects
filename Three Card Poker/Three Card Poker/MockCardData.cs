using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public static class MockCardData
    {
        public static List<IHand> GetFlushCards()
        {
            var cards = new List<IHand>
             {
                new Hand{ Rank = Rank.Four, Suit = Suit.Clubs},
                new Hand{ Rank = Rank.Queen, Suit = Suit.Clubs},
                new Hand{ Rank = Rank.Two, Suit = Suit.Clubs}

              };
            return cards;
        }

        public static List<IHand> GetStraightFlushCards()
        {
            var cards = new List<IHand>
             {
                new Hand{ Rank = Rank.Four, Suit = Suit.Clubs},
                new Hand{ Rank = Rank.Three, Suit = Suit.Clubs},
                new Hand{ Rank = Rank.Two, Suit = Suit.Clubs}

              };
            return cards;
        }
        public static List<IHand> GetStraightCards()
        {
            var cards = new List<IHand>
             {
                new Hand{ Rank = Rank.Queen, Suit = Suit.Hearts},
                new Hand{ Rank = Rank.King, Suit = Suit.Clubs},
                new Hand{ Rank = Rank.Ace, Suit = Suit.Clubs}
              };
            return cards;
        }
        public static List<IHand> GetPairCards()
        {
            var cards = new List<IHand>
             {
                new Hand{ Rank = Rank.Eight, Suit = Suit.Clubs},
                new Hand{ Rank = Rank.Eight, Suit = Suit.Hearts},
                new Hand{ Rank = Rank.Four, Suit = Suit.Diamonds}

              };
            return cards;
        }

        public static List<IHand> GetPairCards1()
        {
            var cards = new List<IHand>
             {
                new Hand{ Rank = Rank.Eight, Suit = Suit.Spades},
                new Hand{ Rank = Rank.Eight, Suit = Suit.Diamonds},
                new Hand{ Rank = Rank.Two, Suit = Suit.Hearts}

              };
            return cards;
        }

        public static List<IHand> GetThreeOfAKindCards()
        {
            var cards = new List<IHand>
             {
                new Hand{ Rank = Rank.Three, Suit = Suit.Diamonds},
                new Hand{ Rank = Rank.Three, Suit = Suit.Hearts},
                new Hand{ Rank = Rank.Three, Suit = Suit.Clubs}

              };
            return cards;
        }

        public static List<IHand> GetHighCards()
        {
            var cards = new List<IHand>
             {
                new Hand{ Rank = Rank.King, Suit = Suit.Clubs},
                new Hand{ Rank = Rank.Eight, Suit = Suit.Diamonds},
                new Hand{ Rank = Rank.Two, Suit = Suit.Spades}

              };
            return cards;
        }

       
        public static List<IHand> GetWinnerAmongTwoPlayersCardsPlayerZero()
        {
            var cards = new List<IHand>
             {
                new Hand{ Rank = Rank.Queen, Suit = Suit.Clubs},
                new Hand{ Rank = Rank.King, Suit = Suit.Clubs},
                new Hand{ Rank = Rank.Four, Suit = Suit.Spades}

              };
            return cards;
        }
        public static List<IHand> GetWinnerAmongTwoPlayersCardsPlayerOne()
        {
            var cards = new List<IHand>
             {
                new Hand{ Rank = Rank.Ace, Suit = Suit.Hearts},
                new Hand{ Rank = Rank.Two, Suit = Suit.Clubs},
                new Hand{ Rank = Rank.Jack, Suit = Suit.Spades}

              };
            return cards;
        }
        public static List<IHand> GetWinnerAmongTwoPlayersCardsPlayerTwo()
        {
            var cards = new List<IHand>
             {
                new Hand{ Rank = Rank.Three, Suit = Suit.Hearts},
                new Hand{ Rank = Rank.Nine, Suit = Suit.Hearts},
                new Hand{ Rank = Rank.Ten, Suit = Suit.Hearts}

              };
            return cards;
        }
        public static List<IHand> GetPlayerThree()
        {
            var cards = new List<IHand>
             {
                new Hand{ Rank = Rank.Ten, Suit = Suit.Clubs},
                new Hand{ Rank = Rank.Nine, Suit = Suit.Clubs},
                new Hand{ Rank = Rank.Three, Suit = Suit.Clubs}

              };
            return cards;
        }
    }
}
