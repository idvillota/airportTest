using AirportTest.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportTest.Entities
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set properties configuration
            modelBuilder.Entity<Airport>().Property(a => a.Country).
                HasMaxLength(150);
            modelBuilder.Entity<Airport>().Property(a => a.CityIata)
                .HasMaxLength(5)
                .IsRequired();
            modelBuilder.Entity<Airport>().Property(a => a.Iata)
                .HasMaxLength(5)
                .IsRequired();
            modelBuilder.Entity<Airport>().Property(a => a.City)
                .HasMaxLength(60);
            modelBuilder.Entity<Airport>().Property(a => a.TimeZoneRegionName)
                .HasMaxLength(60);
            modelBuilder.Entity<Airport>().Property(a => a.CountryIata)
                .HasMaxLength(5)
                .IsRequired();            
            modelBuilder.Entity<Airport>().Property(a => a.Name)
                .HasMaxLength(60)
                .IsRequired();

            modelBuilder.Entity<Location>().Property(l => l.Lon)
                .HasMaxLength(15)
                .IsRequired();
            modelBuilder.Entity<Location>().Property(l => l.Lat)
                .HasMaxLength(15)
                .IsRequired();

            ////Set relationships
            //modelBuilder.Entity<Airport>()                
            //    .HasOne(a => a.Location)
            //    .WithOne(l => l.Airport)
            //    .HasForeignKey<Location>(l => l.AirportRef)
            //    .IsRequired();                
        }
    }
}
