namespace Rental.Entities;

public class ItemGenre
{
    public Item Item { get; set; }
    public int ItemId { get; set; }
    public Genre Genre { get; set; }
    public string GenreId { get; set; }
    public DateTime AddedDate { get; set; }
}