using Microsoft.EntityFrameworkCore;
using Poprawa2.DAL;
using Poprawa2.DTOs;
using Poprawa2.Models;

namespace Poprawa2.Service;

public class AddExhibition:IAddExhibition
{
    private GalleriesDbContext _dbContext;

    public AddExhibition(GalleriesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddNewExhibitionAsync(AddExhibitionDto exhibition)
    {
        var gallery = await _dbContext.Gallery.FirstOrDefaultAsync(w => w.Name == exhibition.gallery);
        
        if (gallery == null)
        {
            throw new Exception("Character not found");
        }
        
        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            var newExhibition = new Exhibition
            {
                GalleryId = gallery.GalleryId,
                Title = exhibition.title,
                StartDate = exhibition.startDate,
                EndDate = exhibition.endDate,
                NumberOfArtWorks = exhibition.Artworks.Count
            };
            
            foreach (var val in exhibition.Artworks)
            {
                var art = await _dbContext.Artwork.FirstOrDefaultAsync(w=>w.ArtworkId == val.artworkId);
                
                if (art == null)
                {
                    throw new Exception("Artwork not found");
                }

                var exhibitionArtowrks = new Exhibition_Artwork
                {
                    ExhibitionId = newExhibition.ExhibitionId,
                    ArtworkId = val.artworkId,
                    InsuranceValue = val.insuranceValue
                };
                
                await _dbContext.Exhibition_Artwork.AddAsync(exhibitionArtowrks);
            }
            
            await _dbContext.Exhibition.AddAsync(newExhibition);
            
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch(Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}