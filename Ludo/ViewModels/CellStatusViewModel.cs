using System.ComponentModel;
using System.Runtime.CompilerServices;
using Ludo.Annotations;

namespace Ludo
{
    public class CellStatusViewModel : ICellStatusViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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

        private ELudoFigureColor _ludoFigureColor = ELudoFigureColor.Empty;
        public ELudoFigureColor LudoFigureColor
        {
            get { return _ludoFigureColor; }
            private set
            {
                if (_ludoFigureColor != value)
                {
                    _ludoFigureColor = value;
                    OnPropertyChanged(nameof(LudoFigureColor));
                }
            }
        }

        public void SetFigure(ELudoFigureColor color)
        {
            LudoFigureColor = color;
        }
        

        private int _rowIndex;
        private int _colIndex;

        public CellStatusViewModel(int row, int col, EFieldType fieldType, EFieldColor fieldColor, ELudoFigureColor figureColor)
        {
            _fieldType = fieldType;
            _colorType = fieldColor;
            _ludoFigureColor = figureColor;
            _colIndex = col;
            _rowIndex = row;

        }
    }
}