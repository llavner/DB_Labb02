

namespace GameManager.Model;

public class Boardgame
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Manufactor { get; set; }
    public string Players { get; set; }
    public string Duration { get; set; }
    public string Difficulty { get; set; }
    public List<TrackerSheet> TrackerSheets { get; set; }



}

