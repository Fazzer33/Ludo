using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Model
{
    public interface IGameLogic
    {
        
        void MovePiece(PawnId pawn, int diceResult);
        
        IReadOnlyList<PawnId> ValidMoves(int diceResult);

        void InitializeGame(List<EPlayerColor> players);

        string ToString();
    }
}
