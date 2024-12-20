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
    class UserSheetViewModel : ObservebleObject
    {

        public ObservableCollection<UserSheet> UserSheet { get; private set; }

        private UserSheet? _selectedUserSheet;
        public UserSheet? SelectedUserSheet
        {
            get => _selectedUserSheet;

            set
            {
                _selectedUserSheet = value;
                PropertyChangedAlert();
            }
        }

        public DelegateCommand ShowEditUserSheetCommand { get; set; }
        public UserSheetViewModel()
        {

            LoadUserSheet();

            ShowEditUserSheetCommand = new DelegateCommand(EditUserSheet, CanEditUserSheet);

        }

        private bool CanEditUserSheet(object? arg) => SelectedUserSheet is not null;
        private void EditUserSheet(object obj)
        {
            new UserSheetEdit().ShowDialog();
        }

        public void LoadUserSheet()
        {
            using var db = new ManagerContext();

            UserSheet = new ObservableCollection<UserSheet>(db.UserSheet.ToList());

            SelectedUserSheet = UserSheet.FirstOrDefault();

        }

    }
}
