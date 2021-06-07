using System.ComponentModel;
using System.Runtime.CompilerServices;
using Ludo.Annotations;
using Ludo.Model;

namespace Ludo
{
    public class InStartCellViewModel
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

        private EPlayerColor _playerColor = EPlayerColor.Empty;
        public EPlayerColor PlayerColor
        {
            get { return _playerColor; }
            private set
            {
                if (_playerColor != value)
                {
                    _playerColor = value;
                    OnPropertyChanged(nameof(PlayerColor));
                }
            }
        }


    }
}