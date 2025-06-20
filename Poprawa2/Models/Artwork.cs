using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poprawa2.Models;

public class Artwork
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int ArtworkId { get; set; }
    public int ArtistId { get; set; }
    [ForeignKey(nameof(ArtistId))]
    public Artist Artist { get; set; }
    public string Title { get; set; }
    public int YearCreated { get; set; }
    public ICollection<Exhibition_Artwork> Exhibition_Artworks { get; set; }
}