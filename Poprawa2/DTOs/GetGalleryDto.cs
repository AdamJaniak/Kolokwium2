using Poprawa2.DAL;

namespace Poprawa2.DTOs;

public class GetGalleryDto
{
    public int galleryId { get; set; }
    public string name { get; set; }
    public DateTime estabilishedDate { get; set; }
    public List<GetExhibitionDto> exhibitions { get; set; }
}