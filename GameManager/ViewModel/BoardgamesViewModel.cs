using GameManager.Assets.Command;
using GameManager.Assets.Event;
using GameManager.Model;
using GameManager.View;
using GameManager.View.Dialogs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameManager.ViewModel
{
    public class BoardgamesViewModel : ObservebleObject
    {

        public Member? SelectedMember
        {
            get => MainWindowViewModel.MemberView.SelectedMember;
            set
            {
                MainWindowViewModel.MemberView.SelectedMember = value;
                FullName = SelectedMember.FullName;
                PropertyChangedAlert(nameof(FullName));
                PropertyChangedAlert();
            }
        }
        public ObservableCollection<Member> Members => MainWindowViewModel.MemberView.Members;
        public ObservableCollection<Boardgame> Boardgames { get; private set; }

        private Boardgame? _selectedBoardgame;

        public Boardgame? SelectedBoardgame
        {
            get => _selectedBoardgame;

            set
            {
                _selectedBoardgame = value;
                PropertyChangedAlert();
                WindowEditBoardgameCommand.RaisedCanExecuteChanged();
                DeleteBoardgameCommand.RaisedCanExecuteChanged();

            }
        }
        public DelegateCommand WindowEditBoardgameCommand { get; set; }
        public DelegateCommand EditBoardgameCommand { get; set; }
        public DelegateCommand WindowAddBoardgameCommand { get; set; }
        public DelegateCommand AddBoardgameCommand { get; set; }
        public DelegateCommand DeleteBoardgameCommand { get; set; }
        public DelegateCommand WindowBoardgameSheetCommand { get; set; }

        public string FullName { get; set; }
        public string Title { get; set; }
        public string Manufactor { get; set; }
        public string Players { get; set; }
        public string Duration { get; set; }
        public string Difficulty { get; set; }
        public MainWindowViewModel MainWindowViewModel { get; }

        public BoardgamesViewModel(MainWindowViewModel mainWindowViewModel)
        {

            MainWindowViewModel = mainWindowViewModel;

            LoadBoardgames();

            WindowEditBoardgameCommand = new DelegateCommand(WindowEditBoardgame, CanEditBoardgame);
            EditBoardgameCommand = new DelegateCommand(EditBoardgame);

            WindowAddBoardgameCommand = new DelegateCommand(WindowAddBoardgame);
            AddBoardgameCommand = new DelegateCommand(AddBoardgame);

            DeleteBoardgameCommand = new DelegateCommand(DeleteBoardgame, CanDeleteBoardgame);

            WindowBoardgameSheetCommand = new DelegateCommand(WindowBoardgameSheet);

        }

        private void WindowBoardgameSheet(object obj)
        {
            new BoardgameSheet(this).ShowDialog();
        }
        private void WindowEditBoardgame(object obj)
        {
            new BoardgameEdit(this).ShowDialog();
        }

        private void WindowAddBoardgame(object obj)
        {
            new BoardgameAdd(this).ShowDialog();
        }

        public void LoadBoardgames()
        {
            using var db = new ManagerContext();

            Boardgames = new ObservableCollection<Boardgame>(db.Boardgames.Include(m => m.MemberBoardgames).ThenInclude(m => m.Member).ToList());
            PropertyChangedAlert(nameof(Boardgames));
        }

        private bool CanDeleteBoardgame(object? arg) => SelectedBoardgame is not null;

        private void DeleteBoardgame(object obj)
        {

            var result = MessageBox.Show($"Are you sure to delete {SelectedBoardgame.Title} (Id: {SelectedBoardgame.Id}) ?", "Delete Boardgame?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {

                using var db = new ManagerContext();



                db.Boardgames.Remove(SelectedBoardgame);
                db.SaveChanges();
                SelectedBoardgame = null;


            }

            LoadBoardgames();

        }

        private bool CanEditBoardgame(object? arg) => SelectedBoardgame is not null;

        private void EditBoardgame(object obj)
        {

            if (SelectedBoardgame != null)
            {
                using var db = new ManagerContext();

                var boardgame = db.Boardgames.SingleOrDefault(m => m.Id == SelectedBoardgame.Id);

                boardgame.Title = SelectedBoardgame.Title;
                boardgame.Manufactor = SelectedBoardgame.Manufactor;
                boardgame.Players = SelectedBoardgame.Players;
                boardgame.Duration = SelectedBoardgame.Duration;
                boardgame.Difficulty = SelectedBoardgame.Difficulty;

                db.SaveChanges();

                LoadBoardgames();

            }

        }

        private void AddBoardgame(object obj)
        {

            var boardgame = new Boardgame()
            {
                Title = this.Title,
                Manufactor = this.Manufactor,
                Players = this.Players,
                Duration = this.Duration,
                Difficulty = this.Difficulty
            };

            using var db = new ManagerContext();

            db.Boardgames.Add(boardgame);

            db.SaveChanges();

            LoadBoardgames();

            Title = string.Empty;
            Manufactor = string.Empty;
            Players = string.Empty;
            Duration = string.Empty;
            Difficulty = string.Empty;


        }


    }
}
