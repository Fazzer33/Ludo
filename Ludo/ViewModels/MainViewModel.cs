using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Ludo.Annotations;
using Ludo.Logic;
using Ludo.Model;

namespace Ludo
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGameLogic _gameLogic;
        private readonly IDice _dice;
        private CellStatusViewModel _selectedCell;

        private bool _isCellSelected = false;

        private EPlayerColor _currentPlayer;
        public EPlayerColor CurrentPlayer
        {
            get { return _currentPlayer;  }
            set
            {
                _currentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }

        private int _rolledNumber = 6;

        public int RolledNumber
        {
            get { return _rolledNumber; }
            set
            {
                _rolledNumber = value;
                OnPropertyChanged(nameof(RolledNumber));
            }
        }

        private readonly List<CellStatusViewModel> _inGameCells = new List<CellStatusViewModel>();

        public List<CellStatusViewModel> InGameCells
        {
            get { return _inGameCells;  }
        }

        private readonly Dictionary<EPlayerColor, List<CellStatusViewModel>> _inStartCells = new Dictionary<EPlayerColor, List<CellStatusViewModel>>();

        public Dictionary<EPlayerColor, List<CellStatusViewModel>> InStartCells
        {
            get { return _inStartCells;  }
        }

        private readonly Dictionary<EPlayerColor, List<CellStatusViewModel>> _inFinishCells = new Dictionary<EPlayerColor, List<CellStatusViewModel>>();

        public Dictionary<EPlayerColor, List<CellStatusViewModel>> InFinishCells
        {
            get { return _inFinishCells; }
        }

        private List<EPlayerColor> _players = new List<EPlayerColor>()
            {EPlayerColor.Red, EPlayerColor.Blue, EPlayerColor.Green, EPlayerColor.Yellow};


        private CellStatusViewModel fetchInGameCell(CellId identifier)
        {
            return InGameCells[identifier.Index];
        }

        private CellStatusViewModel fetchInStartCell(CellId identifier)
        {
            var cells = InStartCells[identifier.Color];
            return cells[identifier.Index];
        }

        private CellStatusViewModel fetchInFinishCell(CellId identifier)
        {
            var cells = InFinishCells[identifier.Color];
            return cells[identifier.Index];
        }

        private void Cell_CellSelected(object sender, CellId selectedCellIdentifier)
        {
            CellStatusViewModel cell = null;
           
            if (_isCellSelected)
            {
                if (selectedCellIdentifier.FieldType == EFieldType.Home)
                {
                    _gameLogic.MovePiece(cell.Pawn.Id, _dice.Result);
                }

                if (selectedCellIdentifier.FieldType == EFieldType.Basic)
                {
                    cell = fetchInGameCell(selectedCellIdentifier);
                    if (!cell.IsEmpty)
                    {
                        if (cell.Pawn.Id.Color == CurrentPlayer)
                        {
                            _gameLogic.MovePiece(cell.Pawn.Id, _dice.Result);
                            CurrentPlayer = _gameLogic.CurrentPlayer;
                        }

                    }

                }

            }
            if (!_isCellSelected)
            {
                if (selectedCellIdentifier.FieldType == EFieldType.Home)
                {
                    cell = fetchInStartCell(selectedCellIdentifier);
                }
                else if (selectedCellIdentifier.FieldType == EFieldType.Basic)
                {
                    cell = fetchInGameCell(selectedCellIdentifier);
                }
                else if (selectedCellIdentifier.FieldType == EFieldType.Finish)
                {
                    cell = fetchInFinishCell(selectedCellIdentifier);
                }
                Console.WriteLine("Empty?: " +cell.IsEmpty);
                if (cell.IsEmpty)
                {
                    return;
                }

                if (CurrentPlayer == cell.PlayerColor)
                {
                    Console.WriteLine(CurrentPlayer);
                    Console.WriteLine("select it");
                    _selectedCell = cell;
                    _selectedCell.IsCellSelected = true;
               /*     _isCellSelected = true;*/
                    displayValidMoves(_selectedCell);
                }
            }
           
        }

        private void displayValidMoves(CellStatusViewModel selectedCell)
        {
            var validMoves = _gameLogic.ValidMoves(_dice.Result);
            foreach (var moveTarget in validMoves)
            {
                
                if (moveTarget == selectedCell.Pawn.Id)
                {

                    fetchInGameCell(selectedCell.Identifier).IsValidMoveTarget = true;
                }
            }
        }

        public RelayCommand RollDiceCommand { get; }
        public RelayCommand RestartGameCommand { get; }

        private void RollDiceCommandHandle(object obj)
        {
           RolledNumber = _dice.Role();
        }

        private void RestartGameCommandHandle(object obj)
        {
            // restart game
            Console.WriteLine("Restart game");
        }

        public void SetupInGameCells()
        {
            EPlayerColor fieldColor;
            EFieldType fieldType;
            EPlayerColor figureColor;
            for (int i = 0; i < 40; i++)
            {
                if (i == 2)
                {
                    fieldType = EFieldType.Basic;
                    fieldColor = EPlayerColor.Blue;
                    figureColor = EPlayerColor.Empty;
                } else if (i == 12)
                {
                    fieldType = EFieldType.Basic;
                    fieldColor = EPlayerColor.Green;
                    figureColor = EPlayerColor.Empty;
                } else if (i == 22)
                {
                    fieldType = EFieldType.Basic;
                    fieldColor = EPlayerColor.Yellow;
                    figureColor = EPlayerColor.Empty;
                } else if (i == 32)
                {
                    fieldType = EFieldType.Basic;
                    fieldColor = EPlayerColor.Red;
                    figureColor = EPlayerColor.Empty;
                }
                else
                {
                    fieldType = EFieldType.Basic;
                    fieldColor = EPlayerColor.Empty;
                    figureColor = EPlayerColor.Empty;
                }

                var cell = new CellStatusViewModel(i, fieldType, fieldColor, figureColor);
                cell.CellSelected += Cell_CellSelected;
                InGameCells.Add(cell);
            }
        }

        public void SetupInStartCells()
        {
            EPlayerColor fieldColor;
            EFieldType fieldType;
            int cellIndex;
            foreach (var color in _players)
            {
                var cells = new List<CellStatusViewModel>();
                switch (color)
                {
                    case EPlayerColor.Red:
                        break;
                    case EPlayerColor.Blue:
                        break;
                    case EPlayerColor.Green:
                        break;
                    case EPlayerColor.Yellow:
                        break;
                    default:
                        break;
                }
                for (int i = 0; i < 4; i++)
                {
                    fieldType = EFieldType.Home;
                    if (color.Equals(EPlayerColor.Red))
                    {
                        fieldColor = EPlayerColor.Red;
                    }
                    else if (color.Equals(EPlayerColor.Blue))
                    {
                        fieldColor = EPlayerColor.Blue;
                    }
                    else if (color.Equals(EPlayerColor.Yellow))
                    {
                        fieldColor = EPlayerColor.Yellow;
                    }
                    else
                    {
                        fieldColor = EPlayerColor.Green;
                    }

                    var pawn = new Pawn(new PawnId(color, i));
                    var cell = new CellStatusViewModel(i, fieldType, fieldColor, color, pawn);
                    cell.CellSelected += Cell_CellSelected;
                    cells.Add(cell);
                }
                _inStartCells.Add(color, cells);
            }
        }

        public void SetupInFinishCells()
        {
            EPlayerColor fieldColor;
            EFieldType fieldType;
            EPlayerColor playerColor;
            foreach (var color in _players)
            {
                var cells = new List<CellStatusViewModel>();
                for (int i = 0; i < 4; i++)
                {
                    fieldType = EFieldType.Finish;
                    if (color.Equals(EPlayerColor.Red))
                    {
                        fieldColor = EPlayerColor.Red;
                    }
                    else if (color.Equals(EPlayerColor.Blue))
                    {
                        fieldColor = EPlayerColor.Blue;
                    }
                    else if (color.Equals(EPlayerColor.Yellow))
                    {
                        fieldColor = EPlayerColor.Yellow;
                    }
                    else
                    {
                        fieldColor = EPlayerColor.Green;
                    }

                    playerColor = EPlayerColor.Empty;
                    var cell = new CellStatusViewModel(i, fieldType, fieldColor, playerColor);
                    cell.CellSelected += Cell_CellSelected;
                    cells.Add(cell);
                }

                _inFinishCells.Add(color, cells);
               
            }
        }


        private void SetupCellStatusViewModels(int rows)
        {
            SetupInGameCells();
            SetupInStartCells();
            SetupInFinishCells();
        }

        public MainViewModel(IGameLogic gameLogic)
        {
            RestartGameCommand = new RelayCommand(RestartGameCommandHandle, (e) => true);
            RollDiceCommand = new RelayCommand(RollDiceCommandHandle, (e) => true);

            _dice = new Dice(1, 6);

            _gameLogic = gameLogic;
            _gameLogic.InitializeGame(new List<EPlayerColor>() { EPlayerColor.Red, EPlayerColor.Blue, EPlayerColor.Green, EPlayerColor.Yellow });
            _currentPlayer = _gameLogic.CurrentPlayer;
            SetupCellStatusViewModels(11);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}