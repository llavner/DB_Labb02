

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

    public ICollection<MemberPuzzle> MemberPuzzles { get; set; }
    public ICollection<MemberBoardgame> MemberBoardgames { get; set; }

}

