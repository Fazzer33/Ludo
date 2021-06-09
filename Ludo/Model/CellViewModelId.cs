using System.ComponentModel;
using Ludo.Model;

namespace Ludo
{
    public class CellViewModelId 
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

        private CellViewModelId(int index, EFieldType fieldType, EPlayerColor color)
        {
            _index = index;
            _fieldType = fieldType;
            _color = color;
        }
        public static CellViewModelId Create(int index, EFieldType fieldType, EPlayerColor color)
        {
            return new CellViewModelId(index, fieldType, color);
        }


        public override int GetHashCode()
        {
            return ("" + Index).GetHashCode(); // Create a string and re-use the HashCode
        }
    }
}