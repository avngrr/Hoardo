using System.Collections;
using Application.Common.Interfaces.Repository;
using Domain.Contracts;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore.Storage;
using Server.Contexts;
namespace Server.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IServiceProvider _provider;
    private Hashtable _repositories;
    private bool disposed;
    private IDbContextTransaction _transaction;

    public UnitOfWork(ApplicationDbContext context, IServiceProvider provider)
    {
        _context = context;
        _provider = provider;
    }

    public Task CreateTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
        return Task.CompletedTask;
    }

    public Task Commit()
    {
        _transaction.Commit();
        return Task.CompletedTask;
    }
    public Task Rollback()
    {
        _transaction.Rollback();
        _transaction.Dispose();
        return Task.CompletedTask;
    }
    public async Task<int> Save(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
    public IRepositoryAsync<T> Repository<T>() where T : EntityBase
    {
        if (_repositories == null) _repositories = new Hashtable();
        var type = typeof(T).Name;
        if (!_repositories.ContainsKey(type))
        {
            IRepositoryAsync<T> repository = (IRepositoryAsync<T>)_provider.GetService(typeof(IRepositoryAsync<T>));
            _repositories.Add(type, repository);
        }
        return _repositories[type] as IRepositoryAsync<T>;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                //dispose managed resources
                _context.Dispose();
            }
        }
        //dispose unmanaged resources
        disposed = true;
    }
}
