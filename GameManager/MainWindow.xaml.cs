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

            var manageDb = new vmManager();
            var newBoardgame = new vmBoardgames();
            var newPuzzle = new vmPuzzles();


            //newBoardgame.CreateBoardgame(title: "Prepper", manufactor: "Ninja Print", language: "Swedish", players: "2-4", duration: "60-90", difficulty: 3, type: "Survival");
            //newPuzzle.CreatePuzzle(title: "Santa Claus is here!", theme: "Christmas", manufactor: "Schmidt", bits: 1000, difficulty: "Medium");
            
            
            //manageDb.EnsureDeleted();
            //manageDb.EnsureCreated();
        }

    }
}

