using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludo.Model;

namespace Ludo.Events
{
    public class CellStatusChangedEventArgs : EventArgs
    {
        public CellStatusChangedEventArgs(PawnId id, EPawnState state, int? cell)
        {
            this.id = id;
            this.state = state;
            this.cellId = cellId;

        }

        public PawnId id { get; }
        public EPawnState state { get; }

        private int? cellId { get; }


    }
}
