namespace Ecommerce.Application.Order.Commands.Save
{
    public class ShoppingCartItemInput
    {
        public MovieInput Movie { get; private set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; private set; }
    }
}
