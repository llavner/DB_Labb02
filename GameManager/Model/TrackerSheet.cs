using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Model;


class TrackerSheet
{
    public int Id { get; set; }
    public bool InUse { get; set; }
    public DateOnly CheckOutDate { get; set; }
    public DateOnly ReturnDate { get; set; }
    public List<Boardgame> Boardgames { get; set; }
    public List<Puzzle> Puzzles { get; set; }
    public List<Member> Members { get; set; }

}



