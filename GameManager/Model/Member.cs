

namespace GameManager.Model;

public class Member
{

    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Street { get; set; }
    public int? StreetNumber { get; set; }
    public string? City { get; set; }
    public int? PostalCode { get; set; }
    //public virtual ICollection<Boardgame> BoardgamesOwned { get; set; }
    //public virtual ICollection<Puzzle>   PuzzlesOwned { get; set; }
    public List<TrackerSheet>? TrackerSheets { get; set; }
}

