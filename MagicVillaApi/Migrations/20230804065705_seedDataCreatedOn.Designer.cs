﻿// <auto-generated />
using System;
using MagicVillaApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVillaApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230804065705_seedDataCreatedOn")]
    partial class seedDataCreatedOn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVillaApi.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("sqfet")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "Amenity1",
                            CreatedDate = new DateTime(2023, 8, 4, 9, 57, 5, 13, DateTimeKind.Local).AddTicks(8638),
                            Details = "Deatils1",
                            ImageUrl = "img1",
                            LastUpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Villa1",
                            Occupancy = 1,
                            Rate = 1.0,
                            sqfet = 1
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "Amenity2",
                            CreatedDate = new DateTime(2023, 8, 4, 9, 57, 5, 13, DateTimeKind.Local).AddTicks(8645),
                            Details = "Deatils2",
                            ImageUrl = "img2",
                            LastUpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Villa2",
                            Occupancy = 2,
                            Rate = 2.0,
                            sqfet = 2
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "Amenity3",
                            CreatedDate = new DateTime(2023, 8, 4, 9, 57, 5, 13, DateTimeKind.Local).AddTicks(8652),
                            Details = "Deatils3",
                            ImageUrl = "img3",
                            LastUpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Villa3",
                            Occupancy = 3,
                            Rate = 3.0,
                            sqfet = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
