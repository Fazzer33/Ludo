using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Ludo.Annotations;
using Ludo.Model;

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

        public event EventHandler<CellId> CellSelected = delegate { };

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

        private PawnId _pawnId;

        public PawnId PawnId
        {
            get { return _pawnId; }
            private set
            {
                if (_pawnId != value)
                {
                    _pawnId = value;
                    OnPropertyChanged(nameof(PawnId));
                }
            }
        }

        private bool _isCellSelected = false;
        public bool IsCellSelected
        {
            get { return _isCellSelected; }
            set
            {
                if (_isCellSelected != value)
                {
                    _isCellSelected = value;
                    OnPropertyChanged(nameof(IsCellSelected));
                }
            }
        }

        private bool _isValidMoveTarget = false;
        public bool IsValidMoveTarget
        {
            get { return _isValidMoveTarget; }
            set
            {
                if (_isValidMoveTarget != value)
                {
                    _isValidMoveTarget = value;
                    OnPropertyChanged(nameof(IsValidMoveTarget));
                }
            }
        }

        public void SetPawn(PawnId pawn)
        {
            PawnId = pawn;
        }

        private RelayCommand _cellSelectedCommand = null;
        public RelayCommand CellSelectedCommand
        {
            get
            {
                return _cellSelectedCommand ??
                       (_cellSelectedCommand = new RelayCommand(
                           (x) =>
                           {
                               CellSelected(this, CellId.Create(_index));

                           }, // Execute
                           (x) => { return true; } // CanExecute
                       ));
            }
        }

        private int _index;

        public CellStatusViewModel(int index, EFieldType fieldType, EFieldColor fieldColor, EPlayerColor figureColor)
        {
            _index = index;
            _fieldType = fieldType;
            _colorType = fieldColor;
            _playerColor = figureColor;
        }

        public CellStatusViewModel(int index, EFieldType fieldType, EFieldColor fieldColor, EPlayerColor figureColor, PawnId pawnId)
        {
            _index = index;
            _fieldType = fieldType;
            _colorType = fieldColor;
            _playerColor = figureColor;
            _pawnId = pawnId;
        }
    }
}