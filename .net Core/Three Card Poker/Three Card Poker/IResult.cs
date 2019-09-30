using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public interface IResult
    {
        bool IsWinner { get; set; }
        HandRanking HandRanking { get; set; }
    }
}
