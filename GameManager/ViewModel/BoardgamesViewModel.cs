using GameManager.Assets.Command;
using GameManager.Assets.Event;
using GameManager.Model;
using GameManager.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.ViewModel
{
    internal class BoardgamesViewModel : ObservebleObject
    {

        public ObservableCollection<Boardgames> Boardgames { get; private set; }

        private Boardgames? _selectedBoardgame;

        public Boardgames? SelectedBoardgame
        {
            get => _selectedBoardgame;

            set
            {
                _selectedBoardgame = value;
                PropertyChangedAlert();
            }
        }
        public DelegateCommand ShowEditBoardgameCommand { get; set; }

        public BoardgamesViewModel()
        {

            LoadBoardgames();

            ShowEditBoardgameCommand = new DelegateCommand(EditBoardgame, CanEditBoardgame);
        }

        private bool CanEditBoardgame(object? arg) => SelectedBoardgame is not null;
        
        private void EditBoardgame(object obj)
        {
            new BoardgameEdit().Show();
        }

        public void LoadBoardgames()
        {
            using var db = new ManagerContext();

            Boardgames = new ObservableCollection<Boardgames>(db.Boardgames.ToList());

            SelectedBoardgame = Boardgames.FirstOrDefault();

        }

        public void CreateBoardgame(string title, string manufactor, string players, string duration, string difficulty)
        {
            var boardGame = new Boardgames() { Title = title, Manufactor = manufactor, Players = players, Duration = duration, Difficulty = difficulty};

            using var db = new ManagerContext();

            db.Boardgames.Add(boardGame);
            db.SaveChanges();

        }

    }
}
