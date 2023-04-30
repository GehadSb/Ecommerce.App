using Ecommerce.Domain.ShoppingCartItemAggregate;

namespace Ecommerce.API.ViewModels
{
    public class ShopCartOutPut
    {
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}
