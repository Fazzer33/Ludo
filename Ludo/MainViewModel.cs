using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                if (j == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        EFieldColor fieldColor;
                        EFieldType fieldType;

                        if (i == 2)
                        {
                            fieldType = EFieldType.Home;
                            fieldColor = EFieldColor.FieldBlue;
                        }
                        else
                        {
                            fieldType = EFieldType.Basic;
                            fieldColor = EFieldColor.FieldBasic;
                        }

                        var cell = new CellStatusViewModel(j, i, fieldType, fieldColor);
                        Cells[j].Add(cell);
                    }

                }

                if (j > 0 && j < 4)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        EFieldColor fieldColor;
                        EFieldType fieldType;

                        if (i == 1)
                        {
                            fieldType = EFieldType.Finish;
                            fieldColor = EFieldColor.FieldBlue;
                        }
                        else
                        {
                            fieldType = EFieldType.Basic;
                            fieldColor = EFieldColor.FieldBasic;
                        }
                        var cell = new CellStatusViewModel(j, i, fieldType, fieldColor);
                        Cells[j].Add(cell);
                    }
                }

                if (j == 4)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        EFieldColor fieldColor;
                        EFieldType fieldType;

                        if (i == 0)
                        {
                            fieldType = EFieldType.Home;
                            fieldColor = EFieldColor.FieldRed;
                        } else if (i == 5)
                        {
                            fieldType = EFieldType.Finish;
                            fieldColor = EFieldColor.FieldBlue;
                        }
                        else
                        {
                            fieldType = EFieldType.Basic;
                            fieldColor = EFieldColor.FieldBasic;
                        }
                        var cell = new CellStatusViewModel(j, i, fieldType, fieldColor);
                        Cells[j].Add(cell);
                    }
                }

                if (j == 5)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        EFieldColor fieldColor;
                        EFieldType fieldType;

                        if (i > 0 && i < 5)
                        {
                            fieldType = EFieldType.Finish;
                            fieldColor = EFieldColor.FieldRed;
                        }
                        else if (i > 5 && i < 10)
                        {
                            fieldType = EFieldType.Finish;
                            fieldColor = EFieldColor.FieldGreen;
                        }
                        else
                        {
                            fieldType = EFieldType.Basic;
                            fieldColor = EFieldColor.FieldBasic;
                        }
                        var cell = new CellStatusViewModel(j, i, fieldType, fieldColor);
                        Cells[j].Add(cell);
                    }
                }

                if (j == 6)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        EFieldColor fieldColor;
                        EFieldType fieldType;

                        if (i == 10)
                        {
                            fieldType = EFieldType.Home;
                            fieldColor = EFieldColor.FieldGreen;
                        }
                        else if (i == 5)
                        {
                            fieldType = EFieldType.Finish;
                            fieldColor = EFieldColor.FieldYellow;
                        }
                        else
                        {
                            fieldType = EFieldType.Basic;
                            fieldColor = EFieldColor.FieldBasic;
                        }
                        var cell = new CellStatusViewModel(j, i, fieldType, fieldColor);
                        Cells[j].Add(cell);
                    }
                }

                if (j > 6 && j < 10)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        EFieldColor fieldColor;
                        EFieldType fieldType;

                        if (i == 1)
                        {
                            fieldType = EFieldType.Finish;
                            fieldColor = EFieldColor.FieldYellow;
                        }
                        else
                        {
                            fieldType = EFieldType.Basic;
                            fieldColor = EFieldColor.FieldBasic;
                        }
                        var cell = new CellStatusViewModel(j, i, fieldType, fieldColor);
                        Cells[j].Add(cell);
                    }
                }

                if (j == 10)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        EFieldColor fieldColor;
                        EFieldType fieldType;

                        if (i == 0)
                        {
                            fieldType = EFieldType.Home;
                            fieldColor = EFieldColor.FieldYellow;
                        }
                        else
                        {
                            fieldType = EFieldType.Basic;
                            fieldColor = EFieldColor.FieldBasic;
                        }
                        var cell = new CellStatusViewModel(j, i, fieldType, fieldColor);
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