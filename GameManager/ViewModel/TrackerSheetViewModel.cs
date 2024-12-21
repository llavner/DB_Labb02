using GameManager.Assets.Command;
using GameManager.Assets.Event;
using GameManager.Model;
using GameManager.View;
using GameManager.View.Dialogs;
using GameManager.View.UserControl;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.ViewModel
{
    public class TrackerSheetViewModel : ObservebleObject
    {
        public ObservableCollection<Boardgame> Boardgames { get; set; }
        public ObservableCollection<Puzzle> Puzzles { get; set; }
        public ObservableCollection<Member> Members { get; set; }
        public MainWindowViewModel MainWindowViewModel { get; set; }

        private Boardgame? _selectedBoardgame;

        public Boardgame? SelectedBoardgame
        {
            get => _selectedBoardgame;

            set
            {
                _selectedBoardgame = value;
                PropertyChangedAlert();
            }
        }

        public DelegateCommand WindowPuzzleSheetCommand { get; set; }
        public DelegateCommand WindowBoardgameSheetCommand { get; set; }
        public TrackerSheetViewModel(MainWindowViewModel mainWindowViewModel)
        {

            MainWindowViewModel = mainWindowViewModel;


            WindowPuzzleSheetCommand = new DelegateCommand(WindowPuzzleSheet);
            WindowBoardgameSheetCommand = new DelegateCommand(WindowBoardgameSheet); 



        }

        

        private void WindowPuzzleSheet(object obj)
        {
            new PuzzleSheet().ShowDialog();
        }

        private void WindowBoardgameSheet(object obj)
        {
            new BoardgameSheet().ShowDialog();
        }
    }
}
