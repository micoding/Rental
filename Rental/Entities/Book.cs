namespace Rental.Entities;

public class Book : Item
{
    public string Author { get; set; }
    public int Ean { get; set; }
}