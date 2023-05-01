using MediatR;

namespace Ecommerce.Application.Order.Commands.Save
{
    public class SaveOrderCommand : IRequest<SaveOrderOutput>
    {
        public string UserId { get; set; }
        public List<ShoppingCartItemInput> ShoppingCartItems { get; set; }
    }
}
