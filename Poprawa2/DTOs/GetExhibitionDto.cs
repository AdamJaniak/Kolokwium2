namespace Poprawa2.DAL;

public class GetExhibitionDto
{
    public string title { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public int numberOfArtworks { get; set; }
    public List<GetArtowrksDto> artworks { get; set; }
}