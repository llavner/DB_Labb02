using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace GameManager.Model;

internal class ManagerContext : DbContext
{

    public DbSet<Members> Members { get; set; }
    public DbSet<Puzzles> Puzzles { get; set; }
    public DbSet<Boardgames> Boardgames { get; set; }
    //public DbSet<UserSheet> UserSheet { get; set; }


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
        base.OnModelCreating(modelBuilder);
    }


    public static void EnsureCreated()
    {
        using var db = new ManagerContext();
        db.Database.EnsureCreated();

    }
    public static void EnsureDeleted()
    {
        using var db = new ManagerContext();
        db.Database.EnsureDeleted();

    }

}

