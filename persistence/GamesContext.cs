using Microsoft.EntityFrameworkCore;
using models;

namespace persistence
{
    public class GamesContext : DbContext
    {
        public DbSet<GameConsole> GameConsoles { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameCopy> GameCopies { get; set; }
        public DbSet<GameCopyTag> GameCopyTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public GamesContext(DbContextOptions<GamesContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GameConsole>()
                .ToTable("GameConsoles");

            modelBuilder.Entity<Title>()
                .ToTable("Titles");

            modelBuilder.Entity<Game>()
                .ToTable("Games")
                .Property(p => p.Id)
                .HasDefaultValueSql("newid()");

            modelBuilder.Entity<Tag>()
                .ToTable("Tags")
                .Property(p => p.Id)
                .HasDefaultValueSql("newid()");

            modelBuilder.Entity<GameCopy>()
                .Property(p => p.PricePaid).HasColumnType("decimal(8,2)");
        }
    }
}
