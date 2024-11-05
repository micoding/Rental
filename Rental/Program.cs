using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using Rental.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RentalContext>(
    option => option.UseMySql(builder.Configuration.GetConnectionString("RentalConnectionString"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("RentalConnectionString")))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<RentalContext>();

var pendingMigrations = dbContext.Database.GetPendingMigrations();
if (pendingMigrations.Any())
{
    dbContext.Database.Migrate();
}

var users = dbContext.Users.ToList();
if (!users.Any())
{
    var user1 = new User()
    {
        Email = "admin@admin.com",
        FirstName = "Admin",
        LastName = "A",
        Address = new Address()
        {
            Street = "123 Main Street",
            City = "London",
            Country = "USA",
            ZipCode = "99-999"
        }
    };
    var user2 = new User()
    {
        Email = "abc@admin.com",
        FirstName = "abc",
        LastName = "B",
        Address = new Address()
        {
            Street = "99 Main Street",
            City = "Lonn",
            Country = "USA",
            ZipCode = "88-888"
        }
    };
    dbContext.Users.AddRange(user1, user2);
    dbContext.SaveChanges();
}

app.MapGet("data", (RentalContext db) =>
{
    var genres = db.Genres.ToList();
    
    return genres;
});

app.MapPost("update", async (RentalContext db) =>
{
    User user = await db.Users.FirstAsync(x => x.Id == 7);
    
    user.LastName = "lastname";

    await db.SaveChangesAsync();
    return user;
});

app.MapPost("create", async (RentalContext db) =>
{
    User user = new User()
    {
        FirstName = "Pan",
        LastName = "Banan",
        Email = "admin@admin.com",
    };

    await db.AddAsync(user);

    await db.SaveChangesAsync();
    return user;
});

app.Run();