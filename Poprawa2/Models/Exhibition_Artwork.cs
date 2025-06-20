using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Poprawa2.Models;

[PrimaryKey(nameof(ExhibitionId),nameof(ArtworkId))]
public class Exhibition_Artwork
{
    public int ExhibitionId { get; set; }
    [ForeignKey(nameof(ExhibitionId))]
    public Exhibition Exhibition { get; set; }
    public int ArtworkId { get; set; }
    [ForeignKey(nameof(ArtworkId))]
    public Artwork Artwork { get; set; }
    public double InsuranceValue { get; set; }
}