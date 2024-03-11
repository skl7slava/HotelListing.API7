using HotelListing.Api.Contracts;
using HotelListing.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Repositories
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository

    {
        private readonly HotelListingDbContext _context;

        public CountriesRepository(HotelListingDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Country> GetDetails(int Id)
        {
           return await _context.Countries.Include(q => q.Hotels)
                .FirstOrDefaultAsync(q => q.Id == Id);
        }
    }
}
