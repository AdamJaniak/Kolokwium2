using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poprawa2.Models;

public class Artist
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int ArtistId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public ICollection<Artwork> Artworks { get; set; }
}