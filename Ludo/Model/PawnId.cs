namespace Ludo.Model
{
    public class PawnId
    {
        private EPlayerColor _color;
        private int _id;


        public PawnId(EPlayerColor color, int id)
        {
            _color = color;
            _id = id;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public EPlayerColor Color
        {
            get => _color;
            set => _color = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is PawnId)
            {
                PawnId objCasted = (PawnId) obj;
                return objCasted.Color == _color && objCasted.Id == _id;
            }

            return false;
        }

        public override string ToString()
        {
            return "COLOR: " + _color + " ID: " + _id;
        }
    }
}