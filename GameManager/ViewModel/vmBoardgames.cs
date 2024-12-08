using GameManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.ViewModel
{
    internal class vmBoardgames
    {

        public void CreateBoardgame(string title, string manufactor, string language, string players, string duration, int difficulty, string type)
        {
            var boardGame = new Boardgames() { Title = title, Manufactor = manufactor, Language = language, Players = players, Duration = duration, Difficulty = difficulty, Type = type };

            using var db = new ManagerContext();

            db.Boardgames.Add(boardGame);
            db.SaveChanges();

        }

    }
}
