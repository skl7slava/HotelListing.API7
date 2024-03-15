using AutoMapper;
using HotelListing.Api.Contracts;
using HotelListing.Api.Data;
using HotelListing.Api.Data.Users;
using HotelListing.Api.Models.Country;
using HotelListing.Api.Models.Hotel;
using HotelListing.Api.Repositories;

namespace HotelListing.Api.Configurations
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, GetCountryDto>().ReverseMap();

            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Hotel, HotelDto>().ReverseMap();

            CreateMap<Country, UpdateCountryDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();

            CreateMap<ApiUserDto,ApiUser>().ReverseMap();

         
        }
    }
}
