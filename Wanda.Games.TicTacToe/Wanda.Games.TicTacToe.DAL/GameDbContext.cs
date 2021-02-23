using Microsoft.EntityFrameworkCore;
using Wanda.Games.TicTacToe.DAL.Seed;
using Wanda.Games.TicTacToe.Model.DTO;

namespace Wanda.Games.TicTacToe.DAL
{
    public class GameDbContext : DbContext
    {
        public GameDbContext()
        {
        }
        public GameDbContext(DbContextOptions <GameDbContext> options) : base(options)
        {
        }
        public DbSet<Game> Game { get; set; }
        public DbSet<Move> Move { get; set; }
        public DbSet<Player> Player { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-3UCB6D0\\MSSQLSERVER2019;Database=GameDatabase;Trusted_Connection=True;")
                    .EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Id)
                .UseIdentityColumn();

                entity.Property(e => e.PlayerName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerDescription)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);


                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.Id)
                .UseIdentityColumn();

                entity.Property(e => e.GameName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

            });

            modelBuilder.Entity<Move>(entity =>
            {
                entity.Property(e => e.Id)
                .UseIdentityColumn();

                entity.Property(e => e.GameId);

                entity.Property(e => e.PlayerId);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Move)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Move_Game");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Move)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Move_Player");
            });

            modelBuilder.Seed();
        }
    }
}
