using GameManager.Assets.Command;
using GameManager.Assets.Event;
using GameManager.Model;
using GameManager.View;
using GameManager.View.BoardgameWindows;
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

        public ObservableCollection<Members> Members { get; private set; }

        private Members? _selectedMember;

        public Members? SelectedMember
        {
            get => _selectedMember;
            
            set 
            { 
                _selectedMember = value;
                PropertyChangedAlert();
                
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
        public int StreetNumber { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }




        public MembersViewModel()
        {
            
            
            LoadMembers();
            
            WindowEditMemberCommand = new DelegateCommand(EditMemberWindow, CanEditMember);

            WindowAddMemberCommand = new DelegateCommand(AddMemberWindow, CanAddMember);

            DeleteMemberCommand = new DelegateCommand(DeleteMember, CanDeleteMember);

            AddMemberCommand = new DelegateCommand(AddMember);

        }

        private bool CanDeleteMember(object? arg) => SelectedMember is not null;

        private void DeleteMember(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanAddMember(object? arg) => SelectedMember is not null;
        
        private void AddMemberWindow(object obj)
        {
            new AddMember(this).ShowDialog();
        }

        private bool CanEditMember(object? arg) => SelectedMember is not null;


        private void EditMemberWindow(object obj)
        {

            new MemberEdit(this).ShowDialog();
        }
        


        public void LoadMembers()
        {
            using var db = new ManagerContext();

            Members = new ObservableCollection<Members>(db.Members.ToList());

            SelectedMember = Members.FirstOrDefault();
        }

        public void AddMember(object obj)
        {
            var member = new Members()
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

            
        }
    }
}
