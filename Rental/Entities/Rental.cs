namespace Rental.Entities;

public class Rental
{
    public Guid Id { get; set; }
    public Item Item { get; set; }
    public int ItemId { get; set; }
    public User Who { get; set; }
    public int WhoId { get; set; }
    public DateTime RentDate { get; set; }
    public int RentDurationDays { get; set; }
    public DateTime ReturnDate { get; set; }
}