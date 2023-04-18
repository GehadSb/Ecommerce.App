using Ecommerce.Domain.Common;
using Ecommerce.Infrastructure.Persistence.context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Infrastructure.Persistence.Repositories
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<TEntity> _entities;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<TEntity>();
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>>[] predicate,
            Expression<Func<TEntity, object>>[] includes)
        {
            return await GetQuery(predicate, includes).ToListAsync();
        }

        private IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>>[] predicates,
            Expression<Func<TEntity, object>>[] includes)
        {
            var query = _entities.AsQueryable();

            if (predicates != null)
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate);
                }
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        public Task<TEntity> FindAsync(TId id, Expression<Func<TEntity, object>>[]? includes = default)
        {
            var query = _entities.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>>[]? includes = default)
        {
            var query = _entities.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("entity argument object is null");
            }

            return query.FirstOrDefaultAsync(predicate);
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.CountAsync(predicate);
        }

        public async Task Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity argument object is null");
            }

            await _entities.AddAsync(entity);
            //await _dbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity argument object is null");
            }

            _entities.Update(entity);
            //_dbContext.Entry(entity).State = EntityState.Modified;
        }

    }
}
