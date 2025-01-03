﻿using GameManager.Assets.Command;
using GameManager.Assets.Event;
using GameManager.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.Windows;


namespace GameManager.ViewModel
{
    public class MainWindowViewModel : ObservebleObject
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
        public DelegateCommand BoardgameViewCommand { get; set; }


        public HomeViewModel HomeView { get; set; }
        public MembersViewModel MemberView { get; set; }
        public PuzzlesViewModel PuzzleView { get; set; }
        public BoardgamesViewModel BoardgameView { get; set; }

        public MainWindowViewModel()
        {
            //EnsureDeleted();
            //EnsureCreated();

            HomeView = new HomeViewModel();
            MemberView = new MembersViewModel(this);
            PuzzleView = new PuzzlesViewModel(this);
            BoardgameView = new BoardgamesViewModel(this);


            CurrentView = HomeView;

            HomeViewCommand = new DelegateCommand(o =>
            {
                CurrentView = HomeView;
                ClearSelected();
            });

            MemberViewCommand = new DelegateCommand(o =>
            {
                CurrentView = MemberView;
                ClearSelected();
            });

            PuzzleViewCommand = new DelegateCommand(o =>
            {
                CurrentView = PuzzleView;
                ClearSelected();
            });

            BoardgameViewCommand = new DelegateCommand(o =>
            {
                CurrentView = BoardgameView;
                ClearSelected();
            });

        }

        public void ClearSelected()
        {

            MemberView.SelectedMember = null;
            BoardgameView.SelectedBoardgame = null;
            PuzzleView.SelectedPuzzle = null;

        }
        public static void EnsureCreated()
        {
            using var db = new ManagerContext();
            db.Database.EnsureCreated();

        }
        public static void EnsureDeleted()
        {
            using var db = new ManagerContext();
            db.Database.EnsureDeleted();

        }


    }
}
