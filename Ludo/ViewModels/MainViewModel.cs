﻿using System;
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

        private ELudoFigureColor _currentPlayer = ELudoFigureColor.Red;
        public ELudoFigureColor CurrentPlayer
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

        private readonly Dictionary<ELudoFigureColor, CellStatusViewModel> _inStartCells = new Dictionary<ELudoFigureColor, CellStatusViewModel>();

        public Dictionary<ELudoFigureColor, CellStatusViewModel> InStartCells
        {
            get { return _inStartCells;  }
        }

        private readonly Dictionary<ELudoFigureColor, CellStatusViewModel> _inFinishCells = new Dictionary<ELudoFigureColor, CellStatusViewModel>();

        public Dictionary<ELudoFigureColor, CellStatusViewModel> InFinishCells
        {
            get { return _inFinishCells; }
        }

        private List<ELudoFigureColor> _players = new List<ELudoFigureColor>()
            {ELudoFigureColor.Red, ELudoFigureColor.Blue, ELudoFigureColor.Green, ELudoFigureColor.Yellow};

        public RelayCommand RollDiceCommand { get; }
        public RelayCommand RestartGameCommand { get; }

        private void RollDiceCommandHandle(object obj)
        {
            RolledNumber = _dice.Role();
            // TODO: Choose piece, then let it move (changes current player and set current player to mainviewmodel
            CurrentPlayer = ELudoFigureColor.Blue;
        }

        private void RestartGameCommandHandle(object obj)
        {
            // restart game
            Console.WriteLine("Restart game");
        }

        public void SetupInGameCells()
        {
            EFieldColor fieldColor;
            EFieldType fieldType;
            ELudoFigureColor figureColor;
            for (int i = 0; i < 40; i++)
            {
                if (i == 2)
                {
                    fieldType = EFieldType.Home;
                    fieldColor = EFieldColor.FieldBlue;
                    figureColor = ELudoFigureColor.Empty;
                } else if (i == 12)
                {
                    fieldType = EFieldType.Home;
                    fieldColor = EFieldColor.FieldGreen;
                    figureColor = ELudoFigureColor.Empty;
                } else if (i == 22)
                {
                    fieldType = EFieldType.Home;
                    fieldColor = EFieldColor.FieldYellow;
                    figureColor = ELudoFigureColor.Empty;
                } else if (i == 32)
                {
                    fieldType = EFieldType.Home;
                    fieldColor = EFieldColor.FieldRed;
                    figureColor = ELudoFigureColor.Empty;
                }
                else
                {
                    fieldType = EFieldType.Basic;
                    fieldColor = EFieldColor.FieldBasic;
                    figureColor = ELudoFigureColor.Empty;
                }

                var cell = new CellStatusViewModel(i, fieldType, fieldColor, figureColor);
                InGameCells.Add(cell);
            }
        }

        public void SetupInStartCells()
        {
            EFieldColor fieldColor;
            EFieldType fieldType;
            int index = 0;
            foreach (var color in _players)
            {
                fieldType = EFieldType.Home;
                if (color.Equals(ELudoFigureColor.Red))
                {
                    fieldColor = EFieldColor.FieldRed;
                } else if (color.Equals(ELudoFigureColor.Blue))
                {
                    fieldColor = EFieldColor.FieldBlue;
                }
                else if (color.Equals(ELudoFigureColor.Yellow))
                {
                    fieldColor = EFieldColor.FieldYellow;
                }
                else 
                {
                    fieldColor = EFieldColor.FieldGreen;
                }
                
                var cell = new CellStatusViewModel(index, fieldType, fieldColor, color);
                _inStartCells.Add(color, cell);
                index++;
            }
        }

        public void SetupInFinishCells()
        {
            EFieldColor fieldColor;
            EFieldType fieldType;
            ELudoFigureColor figureColor;
            int index = 0;
            foreach (var color in _players)
            {
                fieldType = EFieldType.Finish;
                if (color.Equals(ELudoFigureColor.Red))
                {
                    fieldColor = EFieldColor.FieldRed;
                }
                else if (color.Equals(ELudoFigureColor.Blue))
                {
                    fieldColor = EFieldColor.FieldBlue;
                }
                else if (color.Equals(ELudoFigureColor.Yellow))
                {
                    fieldColor = EFieldColor.FieldYellow;
                }
                else
                {
                    fieldColor = EFieldColor.FieldGreen;
                }

                figureColor = ELudoFigureColor.Empty;

                var cell = new CellStatusViewModel(index, fieldType, fieldColor, figureColor);
                _inFinishCells.Add(color, cell);
                index++;
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
            _gameLogic.InitializeGame(new List<EPlayerColor>() { EPlayerColor.Blue, EPlayerColor.Green, EPlayerColor.Red, EPlayerColor.Yellow });
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