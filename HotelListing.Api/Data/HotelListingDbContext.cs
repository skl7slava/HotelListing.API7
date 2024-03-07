using HotelListing.Api.Data;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
//using Microsoft.EntityFrameworkCore;

public class HotelListingDbContext : DbContext
{
    public HotelListingDbContext(DbContextOptions options):base(options)
    {

    }
    public DbSet<Hotel> Hotels { get; set; }    
    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Country>().HasData(
            new Country
            {
                Id = 1,
                Name = "Jamaica",
                ShortName = "JM"
            },
            new Country
            {
                Id = 2,
                Name = "Bahamas",
                ShortName = "BS"
            }
            );

        modelBuilder.Entity<Hotel>().HasData(
            new Hotel { Id = 1,
            Name="Sandal resort", Address="negril", CountryId=1, Rating =4});
    }
}