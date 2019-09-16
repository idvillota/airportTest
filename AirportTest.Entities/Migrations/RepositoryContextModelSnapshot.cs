﻿// <auto-generated />
using System;
using AirportTest.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirportTest.Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirportTest.Entities.Models.Airport", b =>
                {
                    b.Property<Guid>("AirportId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasMaxLength(60);

                    b.Property<string>("CityIata")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("Country")
                        .HasMaxLength(150);

                    b.Property<string>("CountryIata")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<int>("Hubs");

                    b.Property<string>("Iata")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<int>("Rating");

                    b.Property<string>("TimeZoneRegionName")
                        .HasMaxLength(60);

                    b.Property<int>("Type");

                    b.HasKey("AirportId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("AirportTest.Entities.Models.Location", b =>
                {
                    b.Property<Guid>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AirportId");

                    b.Property<string>("Lat")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Lon")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("LocationId");

                    b.HasIndex("AirportId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("AirportTest.Entities.Models.Location", b =>
                {
                    b.HasOne("AirportTest.Entities.Models.Airport", "Airport")
                        .WithMany()
                        .HasForeignKey("AirportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
