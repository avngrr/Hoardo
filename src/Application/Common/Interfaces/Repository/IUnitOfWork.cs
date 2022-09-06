using Domain.Contracts;

namespace Application.Common.Interfaces.Repository;
public interface IUnitOfWork : IDisposable
{
    IRepositoryAsync<T> Repository<T>() where T : EntityBase;
    Task CreateTransaction();
    Task Commit();
    Task Rollback();
    Task<int> Save(CancellationToken cancellationToken);
}
