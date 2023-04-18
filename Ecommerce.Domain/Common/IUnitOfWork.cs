namespace Ecommerce.Domain.Common
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Apply
        /// </summary>
        void Apply();

        /// <summary>
        /// Rollback
        /// </summary>

        void Rollback();
        /// <summary>
        /// SaveOrUpdate
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveOrUpdate();
    }
}
