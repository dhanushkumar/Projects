using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public interface IHandStrategy
    {
        bool IsPlayerHand { get; } 
        HandRanking HandRanking { get; }
        
    }
}
