

using System.ComponentModel.DataAnnotations.Schema;

namespace GameManager.Model;

public class Puzzle
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Theme { get; set; }
    public string? Manufactor { get; set; }
    public int? Bits { get; set; }
    public string? Difficulty { get; set; }
  
    //public ICollection<Member> PuzzleHolders { get; set; }
    public ICollection<MemberPuzzle> MemberPuzzles { get; set; }


    public override string ToString()
    {
        return $"{Title}";
    }

}

