using AutoMapper;
using HotelListing.Api.Contracts;
using HotelListing.Api.Data;

namespace HotelListing.Api.Repositories
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        private readonly IMapper mapper;

        public HotelsRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.mapper = mapper;
        }
    }
}
