using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Model
{
    public class CellModel
    {

        public CellModel(int cellIndex)
        {
            CellIndex = cellIndex;
            PawnInCell = null;
        }
        public Pawn PawnInCell { get; set; } = null;
        public int CellIndex { get; }
        

        public static int GetStartCellIndexForPlayer(EPlayerColor color)
        {
            switch (color)
            {
                case EPlayerColor.Blue:
                    return 2;
                case EPlayerColor.Green:
                    return 12;
                case EPlayerColor.Red:
                    return 32;
                case EPlayerColor.Yellow:
                    return 22;
                default:
                    return 2;
            }
        }

     

        public override string ToString() {
            return "CELL ID: " + CellIndex;
        }
    }
}
