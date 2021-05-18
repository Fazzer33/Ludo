namespace Ludo
{
    public class CellStatusViewModel : ICellStatusViewModel
    {
        private readonly EFieldColor _colorType;

        public EFieldColor ColorType
        {
            get { return _colorType; }
        }

        private readonly EFieldType _fieldType;
        public EFieldType FieldType
        {
            get { return _fieldType; }
        }

        

        private int _rowIndex;
        private int _colIndex;

        public CellStatusViewModel(int row, int col, EFieldType fieldType, EFieldColor fieldColor)
        {
            _fieldType = fieldType;
            _colorType = fieldColor;
            _colIndex = col;
            _rowIndex = row;

        }
    }
}