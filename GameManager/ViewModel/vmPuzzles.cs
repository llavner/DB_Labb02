using GameManager.Model;
using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.ViewModel
{
    internal class vmPuzzles
    {

        public void CreatePuzzle(string title, string theme, string manufactor, int bits, string difficulty)
        {
            var puzzle = new Puzzles() { Title = title, Theme = theme, Manufactor = manufactor, Bits = bits, Difficulty = difficulty };

            using var db = new ManagerContext();

            db.Puzzles.Add(puzzle);
            db.SaveChanges();

        }
    }
}
