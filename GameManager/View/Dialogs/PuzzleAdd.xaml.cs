using GameManager.ViewModel;
using System;
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

namespace GameManager.View.Dialogs;

public partial class PuzzleAdd : Window
{
    public PuzzleAdd(PuzzlesViewModel puzzlesViewModel)
    {
        InitializeComponent();

        DataContext = puzzlesViewModel;
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

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}

