﻿using GameManager.Assets.Event;
using GameManager.Model;
using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.ViewModel
{
    internal class vmPuzzles : ObservebleObject
    {

        public ObservableCollection<Puzzles> Puzzles { get; private set; }

        private Puzzles? _selectedPuzzle;

        public Puzzles? SelectedPuzzle
        {
            get => _selectedPuzzle;

            set
            {
                _selectedPuzzle = value;
                PropertyChangedAlert();
            }
        }


        public vmPuzzles()
        {

            LoadPuzzles();

        }

        public void LoadPuzzles()
        {
            using var db = new ManagerContext();

            Puzzles = new ObservableCollection<Puzzles>(db.Puzzles.ToList());

            SelectedPuzzle = Puzzles.FirstOrDefault();

        }

        public void CreatePuzzle(string title, string theme, string manufactor, int bits, string difficulty)
        {
            var puzzle = new Puzzles() { Title = title, Theme = theme, Manufactor = manufactor, Bits = bits, Difficulty = difficulty };

            using var db = new ManagerContext();

            db.Puzzles.Add(puzzle);
            db.SaveChanges();

        }
    }
}
