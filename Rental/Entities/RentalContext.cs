using Microsoft.EntityFrameworkCore;

namespace Rental.Entities;

public class RentalContext : DbContext
{
    public RentalContext(DbContextOptions<RentalContext> options) : base(options)
    {
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<ItemGenre> ItemGenres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(item =>
        {
            item.UseTphMappingStrategy();
            item.Property(x => x.Name).IsRequired();
            item.Property(x => x.Localization).IsRequired();
            item.Property(x => x.AgeRestriction).IsRequired();
            item.Property(x => x.AgeRestriction).HasDefaultValue(Enums.Enums.AgeRestriction.None);

            item.Property(x => x.Localization).HasDefaultValue("Warehouse");

            item.HasMany(x => x.Rentals).WithOne(x => x.Item).HasForeignKey(x => x.ItemId);

            item.HasMany(x => x.Genres).WithMany(x => x.Affected).UsingEntity<ItemGenre>(
                x => x.HasOne(y => y.Genre).WithMany().HasForeignKey(y => y.GenreId),
                x => x.HasOne(y => y.Item).WithMany().HasForeignKey(y => y.ItemId),
                x =>
                {
                    x.HasKey(y => new { y.GenreId, y.ItemId });
                    x.Property(y => y.AddedDate).HasPrecision(0);
                    x.Property(y => y.AddedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                }
            );
        });

        modelBuilder.Entity<Game>(game =>
        {
            game.Property(x => x.Studio).IsRequired();
            game.Property(x => x.AmountOfPlayers).IsRequired();
        });

        modelBuilder.Entity<Book>(book =>
        {
            book.Property(x => x.Ean).IsRequired();
            book.Property(x => x.Author).IsRequired();
        });

        modelBuilder.Entity<Rental>(rental =>
        {
            rental.Property(x => x.RentDate).IsRequired();
            rental.Property(x => x.RentDurationDays).IsRequired();

            rental.Property(x => x.RentDate).HasPrecision(0);
            rental.Property(x => x.RentDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            rental.Property(x => x.RentDurationDays).HasDefaultValue(14);
        });

        modelBuilder.Entity<Address>(address =>
        {
            address.Property(x => x.Street).IsRequired();
            address.Property(x => x.ZipCode).IsRequired();
            address.Property(x => x.City).IsRequired();
            address.Property(x => x.Country).IsRequired();
        });

        modelBuilder.Entity<User>(user =>
        {
            user.HasOne(x => x.Address).WithOne(x => x.User).HasForeignKey<Address>(x => x.UserId);
            user.HasMany(x => x.Rentals).WithOne(x => x.Who).HasForeignKey(x => x.WhoId);
        });


        modelBuilder.Entity<Address>().HasData(
            new Address{Id = 1, Street = "First Street", ZipCode = "90-999", City = "First City", Country = "First Country", UserId = 1}
        );

    modelBuilder.Entity<User>().HasData(
            new User{Email = "tmp@tmp.com", FirstName = "First Name", LastName = "Last Name", Id = 1}
            );
    }
}