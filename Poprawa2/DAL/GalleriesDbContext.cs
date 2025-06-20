using Microsoft.EntityFrameworkCore;
using Poprawa2.Models;

namespace Poprawa2.DAL;

public class GalleriesDbContext:DbContext
{
    public DbSet<Artist> Artist { get; set; }
    public DbSet<Artwork> Artwork { get; set; }
    public DbSet<Exhibition> Exhibition { get; set; }
    public DbSet<Exhibition_Artwork> Exhibition_Artwork { get; set; }
    public DbSet<Gallery> Gallery { get; set; }
    
    protected GalleriesDbContext()
    {
    }

    public GalleriesDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Artist>().HasData(
            new Artist
            {
                ArtistId = 1,
                FirstName = "Daniel",
                LastName = "Danov",
                BirthDate = new DateTime(1980,1,1),
            });

        modelBuilder.Entity<Artwork>().HasData(
            new Artwork
            {
                ArtworkId = 1,
                ArtistId = 1,
                Title = "Daniel",
                YearCreated = 2000
            });
        modelBuilder.Entity<Exhibition>().HasData(
            new Exhibition
            {
                ExhibitionId = 1,
                GalleryId = 1,
                Title = "War of the Ring",
                StartDate = new DateTime(2000,6,12),
                EndDate = new DateTime(2000,6,15),
                NumberOfArtWorks = 1
            });
        modelBuilder.Entity<Gallery>().HasData(
            new Gallery
            {
                GalleryId = 1,
                Name = "Daniel",
                EstabilishedDate = new DateTime(1980, 1, 1)
            });
        modelBuilder.Entity<Exhibition_Artwork>().HasData(
            new Exhibition_Artwork
            {
                ExhibitionId = 1,
                ArtworkId = 1,
                InsuranceValue = 100.0
            });
    }
}