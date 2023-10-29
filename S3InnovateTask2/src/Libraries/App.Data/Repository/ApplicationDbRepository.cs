using App.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public partial class ApplicationDbRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Properties

        private readonly IApplicationDbContext _context;
        private DbSet<TEntity>? _entity;

        #endregion

        #region Methods

        public ApplicationDbRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(nameof(predicate));

            return await EntityWithNoTracking.AnyAsync(predicate, cancellationToken);
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbSetEntity.FindAsync(id, cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(nameof(predicate));

            return await DbSetEntity.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(nameof(entity));

            await DbSetEntity.AddAsync(entity, cancellationToken);

            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(nameof(entities));

            await DbSetEntity.AddRangeAsync(entities, cancellationToken);

            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {

            ArgumentNullException.ThrowIfNull(nameof(entity));

            DbSetEntity.Update(entity);

            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(nameof(entities));

            DbSetEntity.UpdateRange(entities);

            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(nameof(entity));

            DbSetEntity.Remove(entity);

            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(nameof(entities));

            DbSetEntity.RemoveRange(entities);

            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region Properties
        public virtual IQueryable<TEntity> Entity => DbSetEntity;
        public virtual IQueryable<TEntity> EntityWithNoTracking => DbSetEntity;

        protected virtual DbSet<TEntity> DbSetEntity
        {
            get
            {
                if (_entity is null)
                    _entity = _context.Set<TEntity>();

                return _entity;
            }
        }
        #endregion
    }
}
