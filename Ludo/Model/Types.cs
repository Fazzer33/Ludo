using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ludo
{
    public enum EFieldColor
    {
        FieldBlue,
        FieldRed,
        FieldGreen,
        FieldYellow,
        FieldBasic
    }

    public enum EFieldType
    {
        Home,
        Finish,
        Basic
    }

    public enum ELudoFigureColor
    {
        Blue,
        Red,
        Green,
        Yellow,
        Empty
    }
}

namespace Ludo.Model
{
 

    public enum EPlayerColor
    {
        Red,
        Blue,
        Green,
        Yellow
    }

    public enum EPawnState
    {
        Start,
        InGame,
        Finished
    }
  
}
