using Domain.Contracts;

namespace Application.Common.Interfaces.Repository;
public interface IRepositoryAsync<T, TId> where T : EntityBase<TId>
{
    Task<T> GetByIdAsync(object id);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
