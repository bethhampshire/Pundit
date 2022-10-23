using EFPundit.Models;
using Microsoft.EntityFrameworkCore;

namespace EFPundit
{
    public class PunditDbContext : DbContext
    {
        public DbSet<Club>? Clubs { get; set; }
        public DbSet<ClubColours>? ClubColours { get; set; }
        public DbSet<Country>? Country { get; set; }
        public DbSet<League>? Leagues { get; set; }
        public DbSet<Player>? Players { get; set; }
        public DbSet<Season>? Seasons { get; set; }
        public DbSet<PlayerStats>? PlayerStats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseNpgsql("Host=localhost;Database=Pundit;Username=postgres;Password=walsallfc");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set up <Club> Foreign Key 
            modelBuilder.Entity<Club>()
                .Property<Guid>("ClubKey");
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Club)
                .WithMany(b => b.Players)
                .HasForeignKey("ClubKey")
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<PlayerStats>()
                .HasOne(p => p.Club)
                .WithMany(b => b.PlayerStats)
                .HasForeignKey("ClubKey")
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<ClubColours>()
                .HasOne(p => p.Club)
                .WithOne(b => b.ClubColours)
                .HasForeignKey<Club>(p => p.Id)
                .OnDelete(DeleteBehavior.SetNull);

            // Set up <Country> Foreign Key
            modelBuilder.Entity<Country>()
                .Property<Guid>("CountryKey");
            modelBuilder.Entity<League>()
                .HasOne(p => p.Country)
                .WithMany(b => b.Leagues)
                .HasForeignKey("CountryKey")
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Country)
                .WithMany(b => b.Players)
                .HasForeignKey("CountryKey")
                .OnDelete(DeleteBehavior.SetNull);

            // Set up <League> Foreign Key
            modelBuilder.Entity<League>()
                .Property<Guid>("LeagueKey");
            modelBuilder.Entity<Club>()
            .HasOne(p => p.League)
            .WithMany(b => b.Clubs)
            .HasForeignKey("LeagueKey")
            .OnDelete(DeleteBehavior.SetNull);

            // Set up <Player> Foreign Key
            modelBuilder.Entity<Player>()
                .Property<Guid>("PlayerKey");
            modelBuilder.Entity<PlayerStats>()
                .HasOne(p => p.Player)
                .WithMany(b => b.PlayerStats)
                .HasForeignKey("PlayerKey")
                .OnDelete(DeleteBehavior.Cascade);

            // Set up <Season> Foreign Key
            modelBuilder.Entity<Player>()
                .Property<Guid>("SeasonKey");
            modelBuilder.Entity<PlayerStats>()
                .HasOne(p => p.Season)
                .WithOne(b => b.PlayerStats)
                .HasForeignKey<Season>(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
