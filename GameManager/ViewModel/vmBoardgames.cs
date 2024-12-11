using GameManager.Assets.Event;
using GameManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.ViewModel
{
    internal class vmBoardgames : ObservebleObject
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


        public vmBoardgames()
        {

            LoadBoardgames();
        }

        public void LoadBoardgames()
        {
            using var db = new ManagerContext();

            Boardgames = new ObservableCollection<Boardgames>(db.Boardgames.ToList());

            SelectedBoardgame = Boardgames.FirstOrDefault();

        }

        public void CreateBoardgame(string title, string manufactor, string language, string players, string duration, string difficulty, string type)
        {
            var boardGame = new Boardgames() { Title = title, Manufactor = manufactor, Language = language, Players = players, Duration = duration, Difficulty = difficulty, Type = type };

            using var db = new ManagerContext();

            db.Boardgames.Add(boardGame);
            db.SaveChanges();

        }

    }
}
