using System.ComponentModel.DataAnnotations;

namespace Rental.Entities;

public class User
{
    public int Id { get; init; }
    [MaxLength(20)]
    public string FirstName { get; set; }
    [MaxLength(200)]
    public string LastName { get; set; }

    [MaxLength(200)]
    [Required]
    public string Email { get; set; }
    public Address Address { get; set; }
    
    public List<Rental> Rentals { get; set; }
}