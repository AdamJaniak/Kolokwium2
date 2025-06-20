namespace Poprawa2.DTOs;

public class AddExhibitionDto
{
    public string title { get; set; }
    public string gallery { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public List<AddArtworkDto> Artworks { get; set; }
}