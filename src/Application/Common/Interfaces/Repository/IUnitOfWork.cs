﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;

namespace Application.Common.Interfaces.Repository;
public interface IUnitOfWork<TId> : IDisposable
{
    IRepositoryAsync<T, TId> Repository<T>() where T : EntityBase<TId>;
    Task CreateTransaction();
    Task Commit();
    Task Rollback();
    Task<int> Save(CancellationToken cancellationToken);
}
