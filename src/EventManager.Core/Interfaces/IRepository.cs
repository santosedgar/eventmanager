using EventManager.Models.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Core.Interfaces
{
    public interface IRepository<TEntity, in TKey> where TEntity : IModel
                                                   where TKey : struct
    {
        Task<EntityEntry<TEntity>> AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> ListAsync();

        Task<int> SaveChangesAsync();
    }
}
