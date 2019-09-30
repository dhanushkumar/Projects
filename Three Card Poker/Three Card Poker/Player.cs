using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public class Player : IPlayer
    {
        public int Id { get; set; }
        public List<IHand> Hands { get ; set; }
        public IResult Result { get ; set ; }
    }
}
