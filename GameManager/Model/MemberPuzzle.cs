using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Model
{
    public class MemberPuzzle
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int PuzzleId { get; set; }
        public Puzzle Puzzle { get; set; }

    }
}
