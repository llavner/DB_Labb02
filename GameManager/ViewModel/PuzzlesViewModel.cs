using GameManager.Assets.Command;
using GameManager.Assets.Event;
using GameManager.Model;
using GameManager.View.Dialogs;
using System.Collections.ObjectModel;
using System.Windows;




namespace GameManager.ViewModel
{
    public class PuzzlesViewModel : ObservebleObject
    {

        public ObservableCollection<Puzzle> Puzzles { get; private set; }

        private Puzzle? _selectedPuzzle;

        public Puzzle? SelectedPuzzle
        {
            get => _selectedPuzzle;

            set
            {
                _selectedPuzzle = value;
                PropertyChangedAlert();
                WindowEditPuzzleCommand.RaisedCanExecuteChanged();
                DeletePuzzleCommand.RaisedCanExecuteChanged();
            }
        }

        public DelegateCommand WindowEditPuzzleCommand { get; set; }
        public DelegateCommand EditPuzzleCommand { get; set; }
        public DelegateCommand WindowAddPuzzleCommand { get; set; }
        public DelegateCommand AddPuzzleCommand { get; set; }
        public DelegateCommand DeletePuzzleCommand { get; set; }

        public string Title { get; set; }
        public string Theme { get; set; }
        public string Manufactor { get; set; }
        public int? Bits { get; set; }
        public string Difficulty { get; set; }
        public MainWindowViewModel MainWindowViewModel { get; }

        public PuzzlesViewModel(MainWindowViewModel mainWindowViewModel)
        {

            MainWindowViewModel = mainWindowViewModel;

            LoadPuzzles();

            WindowEditPuzzleCommand = new DelegateCommand(WindowEditPuzzle, CanEditPuzzle);
            EditPuzzleCommand = new DelegateCommand(EditPuzzle);

            WindowAddPuzzleCommand = new DelegateCommand(WindowAddPuzzle);
            AddPuzzleCommand = new DelegateCommand(AddPuzzle);

            DeletePuzzleCommand = new DelegateCommand(DeletePuzzle, CanDeletePuzzle);
            
        }



        private void WindowEditPuzzle(object obj)
        {
            new PuzzleEdit(this).ShowDialog();
        }
        private void WindowAddPuzzle(object obj)
        {
            new PuzzleAdd(this).ShowDialog();
        }

        public void LoadPuzzles()
        {
            using var db = new ManagerContext();

            Puzzles = new ObservableCollection<Puzzle>(db.Puzzles.ToList());
            PropertyChangedAlert(nameof(Puzzles));
        }

        private bool CanDeletePuzzle(object? arg) => SelectedPuzzle is not null;

        private void DeletePuzzle(object obj)
        {

            var result = MessageBox.Show($"Are you sure to delete {SelectedPuzzle.Title} (Id: {SelectedPuzzle.Id}) ?", "Delete Boardgame?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                using var db = new ManagerContext();
                
                db.Puzzles.Remove(SelectedPuzzle);
                db.SaveChanges();
                SelectedPuzzle = null;


            }

            LoadPuzzles();

        }

        private bool CanEditPuzzle(object? arg) => SelectedPuzzle is not null;

        private void EditPuzzle(object obj)
        {

            if (SelectedPuzzle != null)
            {
                using var db = new ManagerContext();

                var puzzle = db.Puzzles.SingleOrDefault(m => m.Id == SelectedPuzzle.Id);

                puzzle.Title = SelectedPuzzle.Title;
                puzzle.Manufactor = SelectedPuzzle.Manufactor;
                puzzle.Theme = SelectedPuzzle.Theme;
                puzzle.Bits = SelectedPuzzle.Bits;
                puzzle.Difficulty = SelectedPuzzle.Difficulty;

                db.SaveChanges();

            }

                LoadPuzzles();

        }
        private void AddPuzzle(object obj)
        {

            var puzzle = new Puzzle()
            {
                Title = this.Title,
                Manufactor = this.Manufactor,
                Theme = this.Theme,
                Bits = this.Bits,
                Difficulty = this.Difficulty
            };

            using var db = new ManagerContext();

            db.Puzzles.Add(puzzle);

            db.SaveChanges();

            LoadPuzzles();

            Title = string.Empty;
            Manufactor = string.Empty;
            Theme = string.Empty;
            Bits = null;
            Difficulty = string.Empty;

        }

    }
}
