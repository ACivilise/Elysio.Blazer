using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Elysio.Blazor.Data.Repositories
{
    public class Repository<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        public Repository(TContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Contexte EF
        /// </summary>
        protected TContext Context { get; }
        /// <summary>
        /// DbSet de l'entité <typeparamref name="TEntity"/>
        /// </summary>
        protected virtual DbSet<TEntity> Set => Context.Set<TEntity>();
        /// <summary>
        /// Accès aux entités déjà chargées dans le contexte EF
        /// </summary>
        protected IEnumerable<TEntity> Local => Context.ChangeTracker.Entries<TEntity>().Select(entry => entry.Entity);


        /// <inheritdoc />
        public virtual void Add(TEntity entity)
        {
            Set.Add(entity);
        }
        /// <inheritdoc />
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            Set.AddRange(entities);
        }

        /// <inheritdoc />
        public virtual void Update(TEntity entity)
        {
            Set.Update(entity);
        }
        /// <inheritdoc />
        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            Set.UpdateRange(entities);
        }

        /// <inheritdoc />
        public virtual void Delete(TEntity entity)
        {
            Set.Remove(entity);
        }
        /// <inheritdoc />
        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            Set.RemoveRange(entities);
        }

        /// <inheritdoc />
        public async virtual Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
