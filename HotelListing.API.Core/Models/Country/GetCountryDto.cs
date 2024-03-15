﻿using HotelListing.Api.Core.Models.Country;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Api.Models.Country
{
    public class GetCountryDto:BaseCountryDto
    {
        public int Id { get; set; }
    }
}
