using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poprawa2.Models;

public class Gallery
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int GalleryId { get; set; }
    public string Name { get; set; }
    public DateTime EstabilishedDate { get; set; }
    public ICollection<Exhibition> Exhibitions { get; set; }
}