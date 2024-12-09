using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.ViewModel
{
    internal class vmMainWindow : vmBase
    {

        public vmMainWindow()
        {

            var manageDb = new vmManager();
            var boardGame = new vmBoardgames();
            var puzzle = new vmPuzzles();
            var member = new vmMembers();

            //boardGame.CreateBoardgame(
            //    title: "Prepper",
            //    manufactor: "Ninja Print",
            //    language: "Swedish",
            //    players: "2-4",
            //    duration: "60-90 min",
            //    difficulty: 3,
            //    type: "Survival"
            //    );

            //puzzle.CreatePuzzle(
            //    title: "Santa Claus is here!",
            //    theme: "Christmas",
            //    manufactor: "Schmidt",
            //    bits: 1000,
            //    difficulty: "Medium"
            //    );

            //member.AddMember(
            //    firstName: "Malte",
            //    lastName: "Reingold",
            //    email: "malte.reingold@gmail.com",
            //    street: "Jakobsgatan",
            //    streetNumber: 4,
            //    city: "Örebro",
            //    postalCode: 74321
            //    );

            //manageDb.EnsureDeleted();
            //manageDb.EnsureCreated();


        }

    }
}
