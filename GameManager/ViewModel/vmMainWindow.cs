using GameManager.Assets.Command;
using GameManager.Assets.Event;
using GameManager.Model;
using System.Collections.ObjectModel;
using System.Windows;


namespace GameManager.ViewModel
{
    internal class vmMainWindow : ObservebleObject
    {

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                PropertyChangedAlert();
            }
        }

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand MemberViewCommand { get; set; }
        public RelayCommand PuzzleViewCommand { get; set; }
        public RelayCommand BoardgameViewCommand { get; set; }

        public vmHomeView HomeView { get; set; }
        public vmMembers MemberView { get; set; }
        public vmPuzzles PuzzleView { get; set; }
        public vmBoardgames BoardgameView { get; set; }

        public vmMainWindow()
        {
            var boardGame = new vmBoardgames();
            var puzzle = new vmPuzzles();
            var member = new vmMembers();

            HomeView = new vmHomeView();
            MemberView = new vmMembers();
            PuzzleView = new vmPuzzles();
            BoardgameView = new vmBoardgames();

            CurrentView = HomeView;

            HomeViewCommand = new RelayCommand(o => { CurrentView = HomeView; });

            MemberViewCommand = new RelayCommand(o => { CurrentView = MemberView; });

            PuzzleViewCommand = new RelayCommand(o => { CurrentView = PuzzleView; });

            BoardgameViewCommand = new RelayCommand(o => { CurrentView = BoardgameView; });


        }



        //public void EnsureCreated()
        //{
        //    using var db = new ManagerContext();
        //    db.Database.EnsureCreated();

        //}
        //public void EnsureDeleted()
        //{
        //    using var db = new ManagerContext();
        //    db.Database.EnsureDeleted();

        //}
    }
}
