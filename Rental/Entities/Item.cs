using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Rental.Entities;

public abstract class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Localization { get; set; }
    public int AgeRestriction { get; set; }
    public List<Genre> Genre { get; set; } = new List<Genre>();
    
    public List<Rental> Rentals { get; set; } = new List<Rental>();
}