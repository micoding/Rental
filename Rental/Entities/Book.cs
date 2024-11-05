namespace Rental.Entities;

public class Book : Item
{
    public string Author { get; set; }
    public string Ean { get; set; }
}