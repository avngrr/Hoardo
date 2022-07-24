using Application.Common.Interfaces.Repository;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Server.Contexts;
using Shared.Wrappers;

namespace Server.Repositories;

public class RepositoryAsync<T> : IRepositoryAsync<T> where T : EntityBase
{
    public ApplicationDbContext _context;
    public RepositoryAsync(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(object id) => await _context.Set<T>().FindAsync(id);

    public async Task<PagedList<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
    {
        return new PagedList<T>(await _context.Set<T>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync(), _context.Set<T>().Count(), pageNumber, pageSize);
    }

    public Task UpdateAsync(T entity)
    {
        T current = _context.Set<T>().Find(entity);
        _context.Entry(current).CurrentValues.SetValues(entity);
        return Task.CompletedTask;
    }
}
