using Domain.Contracts;

namespace Application.Common.Interfaces.Repository;
public interface IRepositoryAsync<T> where T : EntityBase
{
    Task<T> GetByIdAsync(object id);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
