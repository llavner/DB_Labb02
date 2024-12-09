using GameManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.ViewModel
{
    internal class vmMembers
    {

        public void AddMember(string firstName, string lastName, string email, string street, int streetNumber, string city, int postalCode)
        {
            var member = new Members() { FirstName = firstName, LastName = lastName, Email = email, Street = street, StreetNumber = streetNumber, City = city, PostalCode = postalCode };

            using var db = new ManagerContext();

            db.Members.Add(member);

            db.SaveChanges();
        }
    }
}
