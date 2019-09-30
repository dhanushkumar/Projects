using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public class Result : IResult
    {
        public bool IsWinner { get; set ; }
        public HandRanking HandRanking { get ; set; }
    }
}
