using Ecommerce.Domain.Common;
using Ecommerce.Domain.MovieAggregate;
using Ecommerce.Domain.ShoppingCartItemAggregate.Exceptions;

namespace Ecommerce.Domain.ShoppingCartItemAggregate
{
    public class ShoppingCartItem : BaseEntity<long>
    {
        public virtual Movie Movie { get; private set; }
        public virtual int Amount { get; set; }
        public virtual string ShoppingCartId { get; private set; }
        protected ShoppingCartItem()
        {

        }
        public ShoppingCartItem(Movie movie, int amount, string shoppingCartId)
        {
            Movie = movie;
            Amount = amount;
            ShoppingCartId = shoppingCartId;
        }
        public static ShoppingCartItem Create(Movie movie, int amount, string shoppingCartId)
        {
            if (movie is null)
            {
                throw new InvalidMovieException(movie);
            }
            return new ShoppingCartItem(movie, amount, shoppingCartId);
        }

    }
}
