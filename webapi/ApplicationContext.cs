using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using webapi.Controllers;
using webapi.Models;

namespace webapi
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Musician> Musicians { get; set; } = null!;
        public DbSet<Band> Bands { get; set; } = null!;
        public DbSet<MusicianBand> MusicianBands { get; set; } = null!;
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<BandConcert> BandConcerts { get; set; } = null!;
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne<Musician>(s => s.Musician)
            .WithOne(ad => ad.User)
            .HasForeignKey<Musician>(ad => ad.UserId).IsRequired(false);

            modelBuilder
            .Entity<Band>()
            .HasMany(c => c.MusicianList)
            .WithMany(s => s.Bands)
            .UsingEntity<MusicianBand>(
               j => j
                .HasOne(pt => pt.MusicianWrap)
                .WithMany(t => t.MusicianWrapper)
                .HasForeignKey(pt => pt.MusicianId),
            j => j
                .HasOne(pt => pt.BandWrap)
                .WithMany(p => p.MusicianBandList)
                .HasForeignKey(pt => pt.BandID),
            j =>
            {
                j.Property(pt => pt.Id);
                j.HasKey(t => new { t.BandID, t.MusicianId });
                j.ToTable("MusicianBand");
            });
            modelBuilder.Entity<Musician>().HasMany<Band>(m=>m.FoundedBands).WithOne(b=>b.Founder).HasForeignKey(band => band.FounderId).IsRequired(false);
        }
    }
}
