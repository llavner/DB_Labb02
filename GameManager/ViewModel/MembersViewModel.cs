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

namespace GameManager.ViewModel
{
    internal class MembersViewModel : ObservebleObject
    {

        public ObservableCollection<Members> Members { get; private set; }

        private Members? _selectedMember;

        public Members? SelectedMember
        {
            get =>_selectedMember;
            
            set 
            { 
                _selectedMember = value;
                PropertyChangedAlert();
                
            }
        }

        public DelegateCommand ShowEditMemberCommand { get; set; }


        public MembersViewModel()
        {
            LoadMembers();

            ShowEditMemberCommand = new DelegateCommand(EditMember, CanEditMember);

        }

        private bool CanEditMember(object? arg) => SelectedMember is not null;
        

        private void EditMember(object obj)
        {
            new MemberEdit().Show();
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
