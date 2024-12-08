

namespace GameManager.Model;

internal class Members
{

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Street { get; set; }
    public string StreetNumber { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public List<Puzzles> Puzzles { get; set; }
    public List<Boardgames> Boardgames { get; set; }
}

