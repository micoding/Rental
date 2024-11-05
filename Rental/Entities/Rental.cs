namespace Rental.Entities;

public class Rental
{
    public Guid Id { get; init; }
    public Item Item { get; init; }
    public int ItemId { get; init; }
    
    public User Who { get; set; }
    public int WhoId { get; init; }
    public DateTime RentDate { get; set; }
    public int RentDurationDays { get; set; }
    public DateTime ReturnDate { get; set; }
}