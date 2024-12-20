using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace GameManager.Model;

internal class ManagerContext : DbContext
{

    public DbSet<Member> Members { get; set; }
    public DbSet<Puzzle> Puzzles { get; set; }
    public DbSet<Boardgame> Boardgames { get; set; }
    public DbSet<TrackerSheet> TrackerSheets { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = new SqlConnectionStringBuilder()
        {
            UserID = "localhost",
            InitialCatalog = "GameManagerDB",
            TrustServerCertificate = true,
            IntegratedSecurity = true
        }.ToString();

        optionsBuilder.UseSqlServer(connectionString);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<TrackerSheet>() 
            .HasOne(ts => ts.Member) 
            .WithMany(m => m.TrackerSheets) 
            .HasForeignKey(ts => ts.MemberId); 

        modelBuilder.Entity<TrackerSheet>() 
            .HasOne(ts => ts.Puzzle) 
            .WithMany(p => p.TrackerSheets) 
            .HasForeignKey(ts => ts.PuzzleId);

        modelBuilder.Entity<TrackerSheet>() 
            .HasOne(ts => ts.Boardgame) 
            .WithMany(bg => bg.TrackerSheets) 
            .HasForeignKey(ts => ts.BoardgameId);

    }


}

