using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ludo
{
    public enum FieldColor
    {
        FieldBlue,
        FieldRed,
        FieldGreen,
        FieldYellow,
        FieldBasic
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
        Finish
    }
}
