using GameManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.ViewModel
{
    internal class vmManager
    {


        public void EnsureCreated()
        {
            using var db = new ManagerContext();
            db.Database.EnsureCreated();

        }
        public void EnsureDeleted()
        {
            using var db = new ManagerContext();
            db.Database.EnsureDeleted();

        }
    }
}
