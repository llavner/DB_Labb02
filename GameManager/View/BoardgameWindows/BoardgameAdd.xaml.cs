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
using System.Windows.Shapes;

namespace GameManager.View.BoardgameWindows;

    /// <summary>
    /// Interaction logic for BoardgameAdd.xaml
    /// </summary>
    public partial class BoardgameAdd : Window
    {
        public BoardgameAdd()
        {
            InitializeComponent();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {

            this.Close();

        }
    }

