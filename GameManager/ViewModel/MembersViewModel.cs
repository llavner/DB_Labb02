using GameManager.Assets.Command;
using GameManager.Assets.Event;
using GameManager.Model;
using GameManager.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public DelegateCommand ShowEditMemberCommand { get; set; }
        public DelegateCommand ShowAddMemberCommand { get; set; }
        public DelegateCommand ShowDeleteMemberCommand { get; set; }


        public MembersViewModel()
        {
            
            
            LoadMembers();
            
            ShowEditMemberCommand = new DelegateCommand(EditMember, CanEditMember);
            ShowAddMemberCommand = new DelegateCommand(NewMember, CanAddMember);
            ShowDeleteMemberCommand = new DelegateCommand(DeleteMember, CanDeleteMember);

        }

        private bool CanDeleteMember(object? arg) => SelectedMember is not null;

        private void DeleteMember(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanAddMember(object? arg) => SelectedMember is not null;
        
        private void NewMember(object obj)
        {
            new AddMember().ShowDialog();
        }

        private bool CanEditMember(object? arg) => SelectedMember is not null;


        private void EditMember(object obj)
        {

            new MemberEdit(this).ShowDialog();
        }
        


        public void LoadMembers()
        {
            using var db = new ManagerContext();

            Members = new ObservableCollection<Members>(db.Members.ToList());

            SelectedMember = Members.FirstOrDefault();
        }

        public void AddMember(string firstName, string lastName, string email, string street, int streetNumber, string city, int postalCode)
        {
            var member = new Members() 
            { 
                FirstName = firstName, LastName = lastName,
                Email = email, Street = street, StreetNumber = streetNumber,
                City = city, PostalCode = postalCode 
            };

            using var db = new ManagerContext();

            db.Members.Add(member);

            db.SaveChanges();
        }
    }
}
