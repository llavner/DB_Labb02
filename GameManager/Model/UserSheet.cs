using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Model;

    
        class UserSheet
        {
            public int Id { get; set; }
            public List<Boardgames> Boardgames { get; set; }
            public List<Puzzles> Puzzles { get; set; }
            public List<Members> Members { get; set; }

        }

    

