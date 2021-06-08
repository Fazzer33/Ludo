using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ludo
{

    public enum EFieldType
    {
        Home,
        Finish,
        Basic
    }

}

namespace Ludo.Model
{
 

    public enum EPlayerColor
    {
        Red,
        Blue,
        Green,
        Yellow,
        Empty
    }

    public enum EPawnState
    {
        Start,
        InGame,
        Finished
    }
  
}
