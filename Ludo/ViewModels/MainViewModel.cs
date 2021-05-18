using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using Ludo.Annotations;

namespace Ludo
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private readonly List<List<CellStatusViewModel>> _cells = new List<List<CellStatusViewModel>>();

        public List<List<CellStatusViewModel>> Cells
        {
            get { return _cells;  }
        }

        private void SetupCellStatusViewModels(int rows)
        {
            for (int j = 0; j < rows; j++)
            {
                Cells.Add(new List<CellStatusViewModel>());
                if (j == 0 || j == 1)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        EFieldColor fieldColor;
                        EFieldType fieldType;
                        ELudoFigureColor figureColor;

                        if (i == 0 || i == 1)
                        {
                            fieldType = EFieldType.Home;
                            fieldColor = EFieldColor.FieldRed;
                            figureColor = ELudoFigureColor.Red;
                        }
                        else if (i == 6 && j == 0)
                        {
                            fieldType = EFieldType.Home;
                            fieldColor = EFieldColor.FieldBlue;
                            figureColor = ELudoFigureColor.Empty;
                        }
                        else if (i == 5 && j == 1)
                        {
                            fieldType = EFieldType.Finish;
                            fieldColor = EFieldColor.FieldBlue;
                            figureColor = ELudoFigureColor.Empty;
                        } else if (i == 9 || i == 10)
                        {
                            fieldType = EFieldType.Home;
                            fieldColor = EFieldColor.FieldBlue;
                            figureColor = ELudoFigureColor.Blue;
                        }
                        else
                        {
                            fieldType = EFieldType.Basic;
                            fieldColor = EFieldColor.FieldBasic;
                            figureColor = ELudoFigureColor.Empty;
                        }

                        var cell = new CellStatusViewModel(j, i, fieldType, fieldColor, figureColor);
                        Cells[j].Add(cell);
                    }

                }

                if (j > 1 && j < 4)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        EFieldColor fieldColor;
                        EFieldType fieldType;
                        ELudoFigureColor figureColor;

                        if (i == 1)
                        {
                            fieldType = EFieldType.Finish;
                            fieldColor = EFieldColor.FieldBlue;
                            figureColor = ELudoFigureColor.Empty;
                        }
                        else
                        {
                            fieldType = EFieldType.Basic;
                            fieldColor = EFieldColor.FieldBasic;
                            figureColor = ELudoFigureColor.Empty;
                        }
                        var cell = new CellStatusViewModel(j, i, fieldType, fieldColor, figureColor);
                        Cells[j].Add(cell);
                    }
                }

                if (j == 4)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        EFieldColor fieldColor;
                        EFieldType fieldType;
                        ELudoFigureColor figureColor;

                        if (i == 0)
                        {
                            fieldType = EFieldType.Home;
                            fieldColor = EFieldColor.FieldRed;
                            figureColor = ELudoFigureColor.Empty;
                        } else if (i == 5)
                        {
                            fieldType = EFieldType.Finish;
                            fieldColor = EFieldColor.FieldBlue;
                            figureColor = ELudoFigureColor.Empty;
                        }
                        else
                        {
                            fieldType = EFieldType.Basic;
                            fieldColor = EFieldColor.FieldBasic;
                            figureColor = ELudoFigureColor.Empty;
                        }
                        var cell = new CellStatusViewModel(j, i, fieldType, fieldColor, figureColor);
                        Cells[j].Add(cell);
                    }
                }

                if (j == 5)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        EFieldColor fieldColor;
                        EFieldType fieldType;
                        ELudoFigureColor figureColor;

                        if (i > 0 && i < 5)
                        {
                            fieldType = EFieldType.Finish;
                            fieldColor = EFieldColor.FieldRed;
                            figureColor = ELudoFigureColor.Empty;
                        }
                        else if (i > 5 && i < 10)
                        {
                            fieldType = EFieldType.Finish;
                            fieldColor = EFieldColor.FieldGreen;
                            figureColor = ELudoFigureColor.Empty;
                        }
                        else
                        {
                            fieldType = EFieldType.Basic;
                            fieldColor = EFieldColor.FieldBasic;
                            figureColor = ELudoFigureColor.Empty;
                        }
                        var cell = new CellStatusViewModel(j, i, fieldType, fieldColor, figureColor);
                        Cells[j].Add(cell);
                    }
                }

                if (j == 6)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        EFieldColor fieldColor;
                        EFieldType fieldType;
                        ELudoFigureColor figureColor;

                        if (i == 10)
                        {
                            fieldType = EFieldType.Home;
                            fieldColor = EFieldColor.FieldGreen;
                            figureColor = ELudoFigureColor.Empty;
                        }
                        else if (i == 5)
                        {
                            fieldType = EFieldType.Finish;
                            fieldColor = EFieldColor.FieldYellow;
                            figureColor = ELudoFigureColor.Empty;
                        }
                        else
                        {
                            fieldType = EFieldType.Basic;
                            fieldColor = EFieldColor.FieldBasic;
                            figureColor = ELudoFigureColor.Empty;
                        }
                        var cell = new CellStatusViewModel(j, i, fieldType, fieldColor, figureColor);
                        Cells[j].Add(cell);
                    }
                }

                if (j > 6 && j < 9)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        EFieldColor fieldColor;
                        EFieldType fieldType;
                        ELudoFigureColor figureColor;

                        if (i == 1)
                        {
                            fieldType = EFieldType.Finish;
                            fieldColor = EFieldColor.FieldYellow;
                            figureColor = ELudoFigureColor.Empty;
                        }
                        else
                        {
                            fieldType = EFieldType.Basic;
                            fieldColor = EFieldColor.FieldBasic;
                            figureColor = ELudoFigureColor.Empty;
                        }
                        var cell = new CellStatusViewModel(j, i, fieldType, fieldColor, figureColor);
                        Cells[j].Add(cell);
                    }
                }

                if (j == 9 || j == 10)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        EFieldColor fieldColor;
                        EFieldType fieldType;
                        ELudoFigureColor figureColor;

                        if (i == 0 || i == 1)
                        {
                            fieldType = EFieldType.Home;
                            fieldColor = EFieldColor.FieldYellow;
                            figureColor = ELudoFigureColor.Yellow;
                        }
                        else if (i == 4 && j == 10)
                        {
                            fieldType = EFieldType.Home;
                            fieldColor = EFieldColor.FieldYellow;
                            figureColor = ELudoFigureColor.Empty;
                        }
                        else if (i == 5 && j == 9)
                        {
                            fieldType = EFieldType.Finish;
                            fieldColor = EFieldColor.FieldYellow;
                            figureColor = ELudoFigureColor.Empty;
                        }
                        else if (i == 9 || i == 10)
                        {
                            fieldType = EFieldType.Home;
                            fieldColor = EFieldColor.FieldGreen;
                            figureColor = ELudoFigureColor.Green;
                        }
                        else
                        {
                            fieldType = EFieldType.Basic;
                            fieldColor = EFieldColor.FieldBasic;
                            figureColor = ELudoFigureColor.Empty;
                        }
                        var cell = new CellStatusViewModel(j, i, fieldType, fieldColor, figureColor);
                        Cells[j].Add(cell);
                    }
                }

            }
        }

        public MainViewModel()
        {
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