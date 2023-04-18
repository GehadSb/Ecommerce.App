using Ecommerce.Domain.Common;
using Ecommerce.Domain.OrderAggregate.Entity;
using Ecommerce.Domain.OrderAggregate.Exceptions;
using Ecommerce.Domain.ShoppingCartItemAggregate;

namespace Ecommerce.Domain.OrderAggregate
{
    public class Order : BaseEntity<long>
    {
        public virtual string UserId { get; private set; }
        public virtual List<OrderItem> OrderItems { get; set; }
        protected Order()
        {
            OrderItems = new();
        }
        public Order(string userId, List<OrderItem> orderItems)
        {
            UserId = userId;
            OrderItems = orderItems;
        }
        public static Order Create(string userId, List<ShoppingCartItem> shoppingCartItems)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new InvalidUserIdException(userId);
            }
            List<OrderItem> orderItems = new();
            if (shoppingCartItems is not null || shoppingCartItems.Count() > 0)
            {
                foreach (var item in shoppingCartItems)
                {
                    var orderItem = OrderItem.Create(item.Amount, item.Movie.Price, item.Movie.Id);
                    orderItems.Add(orderItem);
                }
            }
            return new Order(userId, orderItems);
        }
    }
}
