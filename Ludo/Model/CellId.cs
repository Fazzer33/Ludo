using Ludo.Model;

namespace Ludo
{
    public class CellId
    {
        private int _index;
        public int Index
        {
            get { return _index; }
        }

        private EFieldType _fieldType;

        public EFieldType FieldType
        {
            get { return _fieldType; }
        }

        private EPlayerColor _color;

        public EPlayerColor Color
        {
            get { return _color;  }
        }

        private CellId(int index, EFieldType fieldType, EPlayerColor color)
        {
            _index = index;
            _fieldType = fieldType;
            _color = color;
        }

        private CellId(int index)
        {
            _index = index;
            _fieldType = EFieldType.Basic;
            _color = EPlayerColor.Empty;
        }

        public static CellId Create(int index)
        {
            return new CellId(index);
        }

        public static CellId Create(int index, EFieldType fieldType, EPlayerColor color)
        {
            return new CellId(index, fieldType, color);
        }


        public override int GetHashCode()
        {
            return ("" + Index).GetHashCode(); // Create a string and re-use the HashCode
        }
    }
}