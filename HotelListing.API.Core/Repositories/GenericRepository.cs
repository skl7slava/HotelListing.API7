﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelListing.Api.Contracts;
using HotelListing.Api.Core.Exceptions;
using HotelListing.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelListingDbContext _context;
        private readonly IMapper _mapper;

        public GenericRepository(HotelListingDbContext context,IMapper  mapper)
        {
            _context = context;
            this._mapper = mapper;
        }
        public async  Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);   
            await _context.SaveChangesAsync();  
            return entity;
        }

        public async Task<TResult> AddAsync<TSource,TResult>(TSource source)
        {
            var entity = _mapper.Map<T>(source);
          
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TResult>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity is null)
            {
                throw new NotFoundException(typeof(T).Name, id);

            }
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                .ToListAsync();
        }

        public async Task<PagedResult<TResult>> GetAllSync<TResult>(QueryParameters queryParameters)
        {
            var totalsize = await _context.Set<T>().CountAsync();
            var items = await _context.Set<T>()
                .Skip(queryParameters.StartIndex)
                .Take(queryParameters.PageSize)
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedResult<TResult>
            {
                Items = items,
                PageNumber = queryParameters.PageNumber,
                RecordNumber = queryParameters.PageSize,
                TotalCount = totalsize

            };
        }

        public async Task<List<TResult?>> GetAllAsync<TResult>()
        {
            return await _context.Set<T>()
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync(); 
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }

            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<TResult> GetAsync<TResult>(int? id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            if (result is null)
            {
                throw new NotFoundException(nameof(id),id.HasValue ?id :"no key provided");    
            }
            
            return _mapper.Map<TResult>(result);    
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync<TSource>(int id, TSource source)
        {
            var entity = await GetAsync(id);
            if (entity is null) { throw new NotFoundException(typeof(T).Name, id); }

            _mapper.Map(source,entity);
            _context.Update(entity);
            await _context.SaveChangesAsync();  
        }

   
    }
}
