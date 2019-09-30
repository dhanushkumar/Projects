using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Card_Poker
{
    public interface IPlayer
    {
        //id of the player
        int Id { get; set; }
        //List of cards the player has
        List<IHand> Hands { get; set; }
        IResult Result { get; set; }
    }
}
