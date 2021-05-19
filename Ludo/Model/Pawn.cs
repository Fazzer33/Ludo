namespace Ludo.Model
{
    public class Pawn
    {
        private PawnId _id;
        private EPawnState _state;

        public PawnId Id
        {
            get => _id;
            set => _id = value;
        }

        public Pawn(PawnId id)
        {
            _id = id;
            _state = EPawnState.Start;
        }


        private CellModel _cell = null;

        public CellModel Cell
        {
            get => _cell;
            set => _cell = value;
        }


        public void MoveToStart(CellModel cell)
        { 
            cell.PawnInCell = this;
            _cell = cell;
            _state = EPawnState.InGame;
        }

        public void MoveToFinish()
        {
            _cell.PawnInCell = null;
            _cell = null;
            _state = EPawnState.Finished;
        }

        public void MovePawn(CellModel cell)
        {

            _cell.PawnInCell = null;

            cell.PawnInCell?.MoveToHouse();

            cell.PawnInCell = this;
            _cell = cell;

        }


        public void MoveToHouse()
        {
            _cell = null;
            _state = EPawnState.Start;
        }

        public EPawnState State
        {
            get => _state;
            set => _state = value;
        }



        public override string ToString()
        {
            return Id.ToString() + " STATE " + _state + " CELL " + _cell;
        }
    }
}