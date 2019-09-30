using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Three_Card_Poker_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        //private static void RemoveLater()
        //{
        //    var players = new List<IPlayer>();
        //    var flushCardsPlayer = new Player { Hands = MockCardData.GetFlushCards(), Id = 10, Result = new Result() };
        //    var straightFlushCardsPlayer = new Player { Hands = MockCardData.GetStraightFlushCards(), Id = 9, Result = new Result() };
        //    var StraightHandPlayer = new Player { Hands = MockCardData.GetStraightCards(), Id = 8, Result = new Result() };
        //    var pairCardPlayer = new Player { Hands = MockCardData.GetPairCards(), Id = 7, Result = new Result() };
        //    var pairCardPlayer1 = new Player { Hands = MockCardData.GetPairCards1(), Id = 6, Result = new Result() };
        //    var highPlayer = new Player { Hands = MockCardData.GetHighCards(), Id = 5, Result = new Result() };
        //    var threeOfAKindPlayer = new Player { Hands = MockCardData.GetThreeOfAKindCards(), Id = 4, Result = new Result() };
        //    var winnerAmongZeroPlayerZero = new Player { Hands = MockCardData.GetWinnerAmongTwoPlayersCardsPlayerZero(), Id = 0, Result = new Result() };
        //    var winnerAmongOnePlayerOne = new Player { Hands = MockCardData.GetWinnerAmongTwoPlayersCardsPlayerOne(), Id = 1, Result = new Result() };
        //    var winnerAmongTwoPlayerTwo = new Player { Hands = MockCardData.GetWinnerAmongTwoPlayersCardsPlayerTwo(), Id = 2, Result = new Result() };
        //    var winnerAmongTwoPlayerThree = new Player { Hands = MockCardData.GetPlayerThree(), Id = 3, Result = new Result() };


        //    players.Add(straightFlushCardsPlayer);
        //    players.Add(winnerAmongZeroPlayerZero);
        //    players.Add(winnerAmongOnePlayerOne);
        //    players.Add(winnerAmongTwoPlayerTwo);
        //    players.Add(winnerAmongTwoPlayerThree);
        //    players.Add(StraightHandPlayer);
        //    players.Add(pairCardPlayer);
        //    players.Add(pairCardPlayer1);
        //    players.Add(highPlayer);
        //    players.Add(flushCardsPlayer);
        //    players.Add(threeOfAKindPlayer);

        //    var judge = new Judge(players);
        //    judge.RankPlayerHands();
        //    var winners = judge.GetWinners().ToList();
        //    var sb = new StringBuilder();
        //    foreach (var winner in winners)
        //    {
        //        sb.Append(winner.Id + " ");
        //    }
        //    Console.WriteLine(sb.ToString());

        //    Console.ReadLine();
        //}
    }
}
