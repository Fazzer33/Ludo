﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ludo.Model;

namespace Ludo
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            GameLogic gameLogic = new GameLogic();

            MainViewModel mvm = new MainViewModel(gameLogic);
            DataContext = mvm;
            InitializeComponent();
        }

        private void LudoGridCell_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
