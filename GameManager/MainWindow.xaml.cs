using GameManager.Model;
using GameManager.ViewModel;
using System.Windows;


namespace GameManager
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new vmMainWindow();
        }

    }
}

