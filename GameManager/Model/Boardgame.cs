

using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameManager.Model;

public class Boardgame
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Manufactor { get; set; }
    public string? Players { get; set; }
    public string? Duration { get; set; }
    public string? Difficulty { get; set; }

   //public ICollection<Member> BoardgameHolders { get; set; }
    public ICollection<MemberBoardgame> MemberBoardgames { get; set; }

}

