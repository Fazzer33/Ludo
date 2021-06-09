using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludo.Events;

namespace Ludo.Model
{
    public interface IGameLogic
    {
        
        void MovePiece(PawnId pawn, int diceResult);
        
        IReadOnlyList<Pawn> ValidMoves(int diceResult);

        void InitializeGame(List<EPlayerColor> players);

        EPlayerColor CurrentPlayer { get;  }

        string ToString();

        event EventHandler<CellStatusChangedEventArgs> CellStatusChangedEvent;
    }
}
