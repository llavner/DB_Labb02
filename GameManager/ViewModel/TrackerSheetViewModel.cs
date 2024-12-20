using GameManager.Assets.Command;
using GameManager.Assets.Event;
using GameManager.Model;
using GameManager.View;
using GameManager.View.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.ViewModel
{
    class TrackerSheetViewModel : ObservebleObject
    {

        public ObservableCollection<TrackerSheet> TrackerSheet { get; private set; }

        private TrackerSheet? _selectedTrackerSheet;
        public TrackerSheet? SelectedTrackerSheet
        {
            get => _selectedTrackerSheet;

            set
            {
                _selectedTrackerSheet = value;
                PropertyChangedAlert();
            }
        }

        public DelegateCommand WindowTrackerSheetCommand { get; set; }
        public TrackerSheetViewModel()
        {

            

            LoadTrackerSheet();

            WindowTrackerSheetCommand = new DelegateCommand(WindowEditTrackerSheet, CanEditTrackerSheet);

        }

        private bool CanEditTrackerSheet(object? arg) => SelectedTrackerSheet is not null;
        private void WindowEditTrackerSheet(object obj)
        {
            new TrackerSheetEdit().ShowDialog();
        }

        public void LoadTrackerSheet()
        {
            using var db = new ManagerContext();

            TrackerSheet = new ObservableCollection<TrackerSheet>(db.TrackerSheet.ToList());

            SelectedTrackerSheet = TrackerSheet.FirstOrDefault();

        }

    }
}
