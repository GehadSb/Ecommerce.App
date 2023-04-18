using Ecommerce.Domain.Common;
using Ecommerce.Domain.MovieAggregate;

namespace Ecommerce.Domain.OrderAggregate.Entity
{
    public class OrderItem : BaseEntity<long>
    {
        public virtual int Amount { get; private set; }
        public virtual decimal Price { get; private set; }
        public virtual long MovieId { get; private set; }
        public virtual Movie Movie { get; private set; }
        public virtual long OrderId { get; private set; }
        public virtual Order Order { get; private set; }

        protected OrderItem()
        {

        }
        public OrderItem(int amount, decimal price, long movieId)
        {
            Amount = amount;
            Price = price;
            MovieId = movieId;
        }
        public static OrderItem Create(int amount, decimal price, long movieId)
        {
            return new OrderItem(amount, price, movieId);
        }
    }
}
