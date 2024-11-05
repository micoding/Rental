using Microsoft.EntityFrameworkCore;
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

app.Run();