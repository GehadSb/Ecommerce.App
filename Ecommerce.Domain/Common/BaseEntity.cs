namespace Ecommerce.Domain.Common
{
    public abstract class BaseEntity
    {
    }
    public abstract class BaseEntity<TPrimaryKey> : BaseEntity
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public virtual TPrimaryKey Id { get; protected set; }

        /// <summary>
        /// BaseEntity constructor
        /// </summary>
        /// <param name="id"></param>
        protected BaseEntity(TPrimaryKey id)
        {
            Id = id;
        }

        /// <summary>
        /// BaseEntity constructor
        /// </summary>
        protected BaseEntity()
        {
            Id = default!;
        }

    }
}
