using System.Linq.Expressions;

namespace Ecommerce.Domain.Common
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>
    {
        /// <summary>
        /// GetAsync where
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>>[]? predicate = default,
         Expression<Func<TEntity, object>>[]? includes = default);


        /// <summary>
        /// FindAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> FindAsync(TPrimaryKey id, Expression<Func<TEntity, object>>[]? includes = default);

        /// <summary>
        /// FindAsync with predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>>[]? includes = default);
        /// <summary>
        /// CountAsync
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        Task Add(TEntity entity);
        void Update(TEntity entity);

    }
}
