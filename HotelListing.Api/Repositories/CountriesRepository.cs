using AutoMapper;
using HotelListing.Api.Contracts;
using HotelListing.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Repositories
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository

    {
        private readonly HotelListingDbContext _context;
        private readonly IMapper mapper;

        public CountriesRepository(HotelListingDbContext context,IMapper mapper) : base(context,mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }

        public async Task<Country> GetDetails(int Id)
        {
           return await _context.Countries.Include(q => q.Hotels)
                .FirstOrDefaultAsync(q => q.Id == Id);
        }
    }
}
