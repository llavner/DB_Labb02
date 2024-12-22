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
        public ObservableCollection<Boardgame> TrackerBoardgames { get; set; }
        public ObservableCollection<Puzzle> TrackerPuzzles { get; set; }
        public ObservableCollection<Member> TrackerMembers { get; set; }
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
        private Puzzle? _selectedPuzzle;
        public Puzzle? SelectedPuzzle
        {
            get => _selectedPuzzle;

            set
            {
                _selectedPuzzle = value;
                PropertyChangedAlert();
                
            }
        }

        public DelegateCommand WindowPuzzleSheetCommand { get; set; }
        public DelegateCommand WindowBoardgameSheetCommand { get; set; }
        public TrackerSheetViewModel(MainWindowViewModel mainWindowViewModel)
        {

            MainWindowViewModel = mainWindowViewModel;

            LoadTrackerData();

        }

        private void LoadTrackerData()
        {
            using var db = new ManagerContext();

            TrackerPuzzles = new ObservableCollection<Puzzle>(db.Puzzles.ToList());
            TrackerBoardgames = new ObservableCollection<Boardgame>(db.Boardgames.ToList());
            TrackerMembers = new ObservableCollection<Member>(db.Members.ToList());

            PropertyChangedAlert(nameof(TrackerPuzzles));
            PropertyChangedAlert(nameof(TrackerBoardgames));
            PropertyChangedAlert(nameof(TrackerMembers));
        }

    }
}
