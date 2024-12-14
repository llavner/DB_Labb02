using GameManager.Assets.Command;
using GameManager.Assets.Event;
using GameManager.Model;
using System.Collections.ObjectModel;
using System.Windows;


namespace GameManager.ViewModel
{
    internal class MainWindowViewModel : ObservebleObject
    {

        private object? _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                PropertyChangedAlert();
            }
        }

        public DelegateCommand HomeViewCommand { get; set; }
        public DelegateCommand MemberViewCommand { get; set; }
        public DelegateCommand PuzzleViewCommand { get; set; }
        public DelegateCommand UserSheetViewCommand { get; set; }
        public DelegateCommand BoardgameViewCommand { get; set; }
        

        public HomeViewModel HomeView { get; set; }
        public MembersViewModel MemberView { get; set; }
        public UserSheetViewModel UserSheetView { get; set; }
        public PuzzlesViewModel PuzzleView { get; set; }
        public BoardgamesViewModel BoardgameView { get; set; }

        public MainWindowViewModel()
        {
            var boardGame = new BoardgamesViewModel();
            var puzzle = new PuzzlesViewModel();
            var member = new MembersViewModel();
            var userSheet = new UserSheetViewModel();

            HomeView = new HomeViewModel();
            MemberView = new MembersViewModel();
            UserSheetView = new UserSheetViewModel();
            PuzzleView = new PuzzlesViewModel();
            BoardgameView = new BoardgamesViewModel();

            CurrentView = HomeView;

            HomeViewCommand = new DelegateCommand(o => { CurrentView = HomeView; });

            MemberViewCommand = new DelegateCommand(o => { CurrentView = MemberView; });

            PuzzleViewCommand = new DelegateCommand(o => { CurrentView = PuzzleView; });

            BoardgameViewCommand = new DelegateCommand(o => { CurrentView = BoardgameView; });

            UserSheetViewCommand = new DelegateCommand(o => { CurrentView = UserSheetView; });

            


        }


    }
}
