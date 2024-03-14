using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Api.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
            new Hotel
            {
                Id = 1,
                Name = "Sandal resort",
                Address = "negril",
                CountryId = 1,
                Rating = 4
            });
        }
    }
}
