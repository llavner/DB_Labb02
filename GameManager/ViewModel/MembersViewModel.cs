using GameManager.Assets.Command;
using GameManager.Assets.Event;
using GameManager.Model;
using GameManager.View;
using GameManager.View.Dialogs;
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
    public class MembersViewModel : ObservebleObject
    {

        public ObservableCollection<Member> Members { get; private set; }

        private Member? _selectedMember;
        public Member? SelectedMember
        {
            get => _selectedMember;

            set
            {
                _selectedMember = value;
                PropertyChangedAlert();
                WindowEditMemberCommand.RaisedCanExecuteChanged();
                DeleteMemberCommand.RaisedCanExecuteChanged();
            }
        }

        public DelegateCommand WindowEditMemberCommand { get; set; }
        public DelegateCommand WindowAddMemberCommand { get; set; }
        public DelegateCommand DeleteMemberCommand { get; set; }
        public DelegateCommand AddMemberCommand { get; set; }
        public DelegateCommand EditMemberCommand { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public int? StreetNumber { get; set; }
        public string City { get; set; }
        public int? PostalCode { get; set; }


        public MembersViewModel()
        {


            LoadMembers();

            WindowEditMemberCommand = new DelegateCommand(WindowEditMember, CanEditMember);
            EditMemberCommand = new DelegateCommand(EditMember);

            WindowAddMemberCommand = new DelegateCommand(WindowAddMember);
            AddMemberCommand = new DelegateCommand(AddMember);

            DeleteMemberCommand = new DelegateCommand(DeleteMember, CanDeleteMember);



        }

        private void WindowEditMember(object obj)
        {
            new MemberEdit(this).ShowDialog();
        }
        private void WindowAddMember(object obj)
        {
            new MemberAdd(this).ShowDialog();
        }

        public void LoadMembers()
        {
            using var db = new ManagerContext();

            Members = new ObservableCollection<Member>(db.Members.ToList());
            PropertyChangedAlert(nameof(Members));
        }

        private bool CanDeleteMember(object? arg) => SelectedMember is not null;

        private void DeleteMember(object obj)
        {

            var result = MessageBox.Show($"Are you sure to delete {SelectedMember.FirstName} {SelectedMember.LastName} (Id: {SelectedMember.Id}) ?", "Delete Member", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                using var db = new ManagerContext();
                if (SelectedMember != null)
                {
                    db.Members.Remove(SelectedMember);
                    db.SaveChanges();
                    SelectedMember = null;
                    
                }
                else
                {
                    MessageBox.Show("Attention!", "Please select a row.", MessageBoxButton.OK);

                }
            }

            LoadMembers();

        }

        

        private bool CanEditMember(object? arg) => SelectedMember is not null;
        public void EditMember(object obj)
        {

            if (SelectedMember != null)
            {
                using var db = new ManagerContext();

                var member = db.Members.SingleOrDefault(m => m.Id == SelectedMember.Id);

                member.FirstName = SelectedMember.FirstName;
                member.LastName = SelectedMember.LastName;
                member.Email = SelectedMember.Email;
                member.Street = SelectedMember.Street;
                member.StreetNumber = SelectedMember.StreetNumber;
                member.City = SelectedMember.City;
                member.PostalCode = SelectedMember.PostalCode;

                db.SaveChanges();

                LoadMembers();

            }
            else
            {
                MessageBox.Show("Attention!", "Please select a row.", MessageBoxButton.OK);
            }

        }

        public void AddMember(object obj)
        {
            var member = new Member()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Street = this.Street,
                StreetNumber = this.StreetNumber,
                City = this.City,
                PostalCode = this.PostalCode
            };

            using var db = new ManagerContext();

            db.Members.Add(member);

            db.SaveChanges();

            LoadMembers();

            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Street = string.Empty;
            StreetNumber = null;
            City = string.Empty;
            PostalCode = null;

        }


    }
}
