using Microsoft.EntityFrameworkCore;
using Poprawa2.DAL;
using Poprawa2.DTOs;
using Poprawa2.Models;

namespace Poprawa2.Service;

public class GetGallery:IGetGallery
{
    GalleriesDbContext _dbContext;

    public GetGallery(GalleriesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetGalleryDto> GetGalleryByIdAsync(int id)
    {
        var data = await _dbContext.Gallery
            .Include(g => g.Exhibitions)
            .ThenInclude(e => e.ExhibitionArtworks)
            .ThenInclude(ea => ea.Artwork)
            .ThenInclude(a => a.Artist)
            .Where(w => w.GalleryId == id)
            .FirstOrDefaultAsync();

        var dto = new GetGalleryDto
        {
            galleryId = data.GalleryId,
            name = data.Name,
            estabilishedDate = data.EstabilishedDate,
            exhibitions = data.Exhibitions.Select(e => new GetExhibitionDto
            {
                title = e.Title,
                startDate = e.StartDate,
                endDate = e.EndDate,
                numberOfArtworks = e.NumberOfArtWorks,
                artworks = e.ExhibitionArtworks.Select(ea => new GetArtowrksDto()
                {
                    title = ea.Artwork.Title,
                    yearCreated = ea.Artwork.YearCreated,
                    insuranceValue = ea.InsuranceValue,
                    artist = new GetArtistDto
                    {
                        firstName = ea.Artwork.Artist.FirstName,
                        lastName = ea.Artwork.Artist.LastName,
                        birthDate = ea.Artwork.Artist.BirthDate
                    }
                }).ToList()
            }).ToList()
        };
            

        return dto;
    }
}