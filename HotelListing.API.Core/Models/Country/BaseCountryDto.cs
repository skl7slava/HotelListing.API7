﻿using System.ComponentModel.DataAnnotations;

namespace HotelListing.Api.Core.Models.Country
{
    public abstract class BaseCountryDto
    {        
        [Required]
        public string Name { get; set; }
        public string Shortname { get; set; }
        
    }
}
