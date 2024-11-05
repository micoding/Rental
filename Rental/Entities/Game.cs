namespace Rental.Entities;

public class Game : Item
{
    public string Studio { get; set; }
    public int AmountOfPlayers { get; set; }
}