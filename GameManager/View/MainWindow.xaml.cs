using GameManager.Assets.Command;
using GameManager.Model;
using GameManager.ViewModel;
using System.Reflection.Metadata.Ecma335;
using System.Windows;
using System.Windows.Input;


namespace GameManager
{

    public partial class MainWindow : Window
    {
        
        public MainWindow()
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

        public void Button_Exit(object sender, RoutedEventArgs e)
        {

            var result = MessageBox.Show("Are you sure?", "Exit Program.", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }

        private void RadioButton_Exit(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Exit Program.", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }
    }
}

