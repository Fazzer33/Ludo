using System;
using Ludo.Model;

namespace Ludo.Events
{
    public class CellStatusChangedEventArgs : EventArgs
    {
        public CellStatusChangedEventArgs(CellId source, Pawn newPawn, CellId target)
        {
            NewPawn = newPawn;
            Source = source;
            Target = target;

        }

        public Pawn NewPawn { get; }
        public CellId Source { get; }
        public CellId Target { get; }


    }
}
