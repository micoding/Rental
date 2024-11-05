﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rental.Entities;

#nullable disable

namespace Rental.Migrations
{
    [DbContext(typeof(RentalContext))]
    partial class RentalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Rental.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "First City",
                            Country = "First Country",
                            Street = "First Street",
                            UserId = 1,
                            ZipCode = "90-999"
                        });
                });

            modelBuilder.Entity("Rental.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AffectedId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Rental.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AgeRestriction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Localization")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext")
                        .HasDefaultValue("Warehouse");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Rental.Entities.ItemGenre", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedDate")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("GenreId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemGenres");
                });

            modelBuilder.Entity("Rental.Entities.Rental", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentDate")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(0)
                        .HasColumnType("datetime(0)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("RentDurationDays")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(14);

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("WhoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("WhoId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("Rental.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("LastName")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "tmp@tmp.com",
                            FirstName = "First Name",
                            LastName = "Last Name"
                        });
                });

            modelBuilder.Entity("Rental.Entities.Book", b =>
                {
                    b.HasBaseType("Rental.Entities.Item");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ean")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("Rental.Entities.Game", b =>
                {
                    b.HasBaseType("Rental.Entities.Item");

                    b.Property<int>("AmountOfPlayers")
                        .HasColumnType("int");

                    b.Property<string>("Studio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Game");
                });

            modelBuilder.Entity("Rental.Entities.Address", b =>
                {
                    b.HasOne("Rental.Entities.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("Rental.Entities.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Rental.Entities.ItemGenre", b =>
                {
                    b.HasOne("Rental.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rental.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Rental.Entities.Rental", b =>
                {
                    b.HasOne("Rental.Entities.Item", "Item")
                        .WithMany("Rentals")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rental.Entities.User", "Who")
                        .WithMany("Rentals")
                        .HasForeignKey("WhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Who");
                });

            modelBuilder.Entity("Rental.Entities.Item", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("Rental.Entities.User", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}
