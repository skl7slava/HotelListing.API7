using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelListing.Api.Contracts;
using HotelListing.Api.Core.Exceptions;
using HotelListing.Api.Data;
using HotelListing.Api.Models.Country;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Repositories
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository

    {
        private readonly HotelListingDbContext _context;
        private readonly IMapper _mapper;

        public CountriesRepository(HotelListingDbContext context,IMapper mapper) : base(context,mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<CountryDto> GetDetails(int Id)
        {
           var country= await _context.Countries.Include(q => q.Hotels)
                .ProjectTo<CountryDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == Id);
            if (country == null)
            {
                throw new NotFoundException(nameof(GetDetails), Id);
            }
            return country;
        }
    }
}
