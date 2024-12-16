using GameManager.Assets.Command;
using GameManager.Assets.Event;
using GameManager.Model;
using GameManager.View;
using GameManager.View.PuzzleWindows;
using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.ViewModel
{
    public class PuzzlesViewModel : ObservebleObject
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

        public DelegateCommand ShowEditPuzzleCommand { get; set; }
        public PuzzlesViewModel()
        {

            LoadPuzzles();

            ShowEditPuzzleCommand = new DelegateCommand(EditPuzzle, CanEditPuzzle);

        }

        private bool CanEditPuzzle(object? arg) => SelectedPuzzle is not null;
        private void EditPuzzle(object obj)
        {
            new PuzzleEdit(this).ShowDialog();
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
