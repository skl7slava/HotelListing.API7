using HotelListing.Api.Models;

namespace HotelListing.Api.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllSync();
        Task<PagedResult<TResult>> GetAllSync<TResult>(QueryParameters queryParameters);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);

        Task<bool> Exists(int id);
    }
}
