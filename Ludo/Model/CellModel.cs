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
        }
        public Pawn PawnInCell { get; set; } = null;
        public int CellIndex { get; }
        

        public static int GetStartCellIndexForPlayer(EPlayerColor color)
        {
            switch (color)
            {
                case EPlayerColor.Blue:
                    return 0;
                case EPlayerColor.Green:
                    return 10;
                case EPlayerColor.Red:
                    return 20;
                case EPlayerColor.Yellow:
                    return 30;
                default:
                    return 0;
            }
        }

     

        public override string ToString() {
            return "CELL ID: " + CellIndex;
        }
    }
}
