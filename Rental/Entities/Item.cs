namespace Rental.Entities;

public abstract class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Localization { get; set; }
    public Enums.Enums.AgeRestriction AgeRestriction { get; set; }
    public List<Genre> Genres { get; set; } = new List<Genre>();
    public List<Rental> Rentals { get; set; } = new List<Rental>();
}