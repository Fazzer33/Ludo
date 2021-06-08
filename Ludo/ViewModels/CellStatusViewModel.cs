using System;
using System.Collections.Generic;
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

        private readonly EPlayerColor _fieldColor;

        public EPlayerColor ColorType
        {
            get { return _fieldColor; }
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

        private Pawn _pawn;

        public Pawn Pawn
        {
            get { return _pawn; }
            private set
            {
                if (_pawn != value)
                {
                    _pawn = value;
                    OnPropertyChanged(nameof(Pawn));
                }
            }
        }

        public bool IsEmpty
        {
            get { return _pawn == null;  }
        }
        

        private bool _isCellSelected;
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

        public void SetPawn(Pawn pawn)
        {
            Pawn = pawn;
        }

        public CellId Identifier
        {
            get { return CellId.Create(_index, _fieldType, _playerColor); }
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
                               CellSelected(this, CellId.Create(_index, _fieldType, _fieldColor));

                           }, // Execute
                           (x) => { return true; } // CanExecute
                       ));
            }
        }

        private int _index;

        public CellStatusViewModel(int index, EFieldType fieldType, EPlayerColor fieldFieldColor, EPlayerColor figureColor)
        {
            _index = index;
            _fieldType = fieldType;
            _fieldColor = fieldFieldColor;
            _playerColor = figureColor;
        }

        public CellStatusViewModel(int index, EFieldType fieldType, EPlayerColor fieldFieldColor, EPlayerColor figureColor, Pawn pawn)
        {
            _index = index;
            _fieldType = fieldType;
            _fieldColor = fieldFieldColor;
            _playerColor = figureColor;
            _pawn = pawn;
        }
    }
}