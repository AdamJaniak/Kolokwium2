using Poprawa2.DTOs;

namespace Poprawa2.Service;

public interface IAddExhibition
{
    Task AddNewExhibitionAsync(AddExhibitionDto exhibition);
}