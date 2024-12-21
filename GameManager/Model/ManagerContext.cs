using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace GameManager.Model;

internal class ManagerContext : DbContext
{

    public DbSet<Member> Members { get; set; }
    public DbSet<Puzzle> Puzzles { get; set; }
    public DbSet<Boardgame> Boardgames { get; set; }
    public DbSet<MemberPuzzle> MemberPuzzles { get; set; }
    public DbSet<MemberBoardgame> MemberBoardgames { get; set; }



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

        modelBuilder.Entity<MemberPuzzle>()
            .HasKey(mp => new { mp.MemberId, mp.PuzzleId });

        modelBuilder.Entity<MemberPuzzle>()
            .HasOne(mp => mp.Member)
            .WithMany(m => m.MemberPuzzles)
            .HasForeignKey(mp => mp.MemberId);

        modelBuilder.Entity<MemberPuzzle>()
            .HasOne(mp => mp.Puzzle)
            .WithMany(p => p.MemberPuzzles)
            .HasForeignKey(mp => mp.PuzzleId);

        modelBuilder.Entity<MemberBoardgame>()
            .HasKey(mb => new { mb.MemberId, mb.BoardgameId });

        modelBuilder.Entity<MemberBoardgame>()
            .HasOne(mb => mb.Member)
            .WithMany(m => m.MemberBoardgames)
            .HasForeignKey(mb => mb.MemberId);

        modelBuilder.Entity<MemberBoardgame>()
            .HasOne(mb => mb.Boardgame)
            .WithMany(b => b.MemberBoardgames)
            .HasForeignKey(mb => mb.BoardgameId);

    }

}








