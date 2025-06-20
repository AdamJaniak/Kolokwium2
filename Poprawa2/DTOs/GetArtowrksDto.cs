namespace Poprawa2.DAL;

public class GetArtowrksDto
{
    public string title { get; set; }
    public int yearCreated { get; set; }
    public double insuranceValue { get; set; }
    public GetArtistDto artist { get; set; }
}

public class GetArtistDto
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public DateTime birthDate { get; set; }
}