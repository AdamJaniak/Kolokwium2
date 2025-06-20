using Poprawa2.DTOs;

namespace Poprawa2.Service;

public interface IGetGallery
{
    Task<GetGalleryDto> GetGalleryByIdAsync(int id);
}