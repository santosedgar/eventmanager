using EventManager.Core.Interfaces;
using EventManager.Database;
using EventManager.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Persistence
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : IModel
                                                                        where TKey : struct
    {
        protected readonly EventManagerContext Context;

        public Repository(EventManagerContext context)
        {
            this.Context = context;
        }

        public virtual async Task<EntityEntry<TEntity>> AddAsync(TEntity entity)
        {
            return await this.Context
                .Set<TEntity>()
                .AddAsync(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await this.Context
                .Set<TEntity>()
                .ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.Context.SaveChangesAsync();
        }
    }
}
