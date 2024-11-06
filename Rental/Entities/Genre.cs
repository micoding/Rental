using System.ComponentModel.DataAnnotations;

namespace Rental.Entities;

public class Genre
{
    [Key]
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }
    public List<Item> Affected { get; set; } =  new List<Item>();
    public int AffectedId { get; set; }
}