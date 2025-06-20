using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poprawa2.Models;

public class Exhibition
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int ExhibitionId { get; set; }
    public int GalleryId { get; set; }
    [ForeignKey(nameof(GalleryId))]
    public Gallery Gallery { get; set; }
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfArtWorks { get; set; }
    public ICollection<Exhibition_Artwork> ExhibitionArtworks { get; set; }
}