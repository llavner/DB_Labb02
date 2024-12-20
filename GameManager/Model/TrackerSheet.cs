using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Model;


public class TrackerSheet
{
        public int Id { get; set; }
        public bool InUse { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public DateOnly ReturnDate { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int BoardgameId { get; set; }
        public Boardgame Boardgame { get; set; }
        public int PuzzleId { get; set; }
        public Puzzle Puzzle { get; set; }


}



