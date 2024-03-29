﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.Api.Data;
using HotelListing.Api.Models.Country;
using AutoMapper;
using HotelListing.Api.Contracts;
using Microsoft.AspNetCore.Authorization;

using HotelListing.Api.Models;
using Microsoft.AspNetCore.OData.Query;
using HotelListing.Api.Core.Exceptions;

namespace HotelListing.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CountriesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICountriesRepository _countriesRepository;

    public CountriesController(IMapper mapper, ICountriesRepository countriesRepository)
    {
        _mapper = mapper;
        _countriesRepository = countriesRepository;
    }

    // GET: api/Countries/?StartIndex=0&pagesize=25&PageNumber=1
    [HttpGet]
    public async Task<ActionResult<PagedResult<GetCountryDto>>> GetPagedCountries([FromQuery] QueryParameters queryParameters)
    {
       
        var pagedCountriesResult = await _countriesRepository.GetAllSync<GetCountryDto>(queryParameters);

        
        return Ok(pagedCountriesResult);
    }
    // GET: api/Countries
    [HttpGet("GetAll")]
    [EnableQuery]
    [Authorize]
    public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
    {            
        var countries = await _countriesRepository.GetAllAsync<GetCountryDto>();
        return Ok(countries);
    }

    // GET: api/Countries/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CountryDto>> GetCountry(int id)
    {
        
        var country = await _countriesRepository.GetAsync(id);
                    
        return Ok(country);
    }

    // PUT: api/Countries/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    [Authorize(Roles ="Administrator")]
    public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
    {
        if (id != updateCountryDto.Id)
        {
            return BadRequest();
        }
   
        try
        {
            await _countriesRepository.UpdateAsync(id,updateCountryDto);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await CountryExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Countries
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize(Roles = "Administrator,User")]
    public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountryDto)
    {        
        var country = _countriesRepository.AddAsync<CreateCountryDto,GetCountryDto>(createCountryDto);

        return CreatedAtAction("GetCountry", new { id = country.Id }, country);
    }

    // DELETE: api/Countries/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteCountry(int id)
    { 
        await _countriesRepository.DeleteAsync(id);      

        return NoContent();
    }

    private async Task<bool> CountryExists(int id)
    {
        return (await _countriesRepository.Exists( id));
    }
}
