using Ecommerce.API.Helper.Cart;
using Ecommerce.API.ViewModels;
using Ecommerce.Application.Movie.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly ILogger<MovieController> _logger;
        private readonly IMediator _mediator;
        private readonly IMovieService _moviesService;
        public OrdersController(ShoppingCart shoppingCart, ILogger<MovieController> logger, IMediator mediator, IMovieService movieService)
        {
            _shoppingCart = shoppingCart;
            _logger = logger;
            _mediator = mediator;
            _moviesService = movieService;
        }
        [HttpGet("list-shopping-cart")]
        public async Task<IActionResult> ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            var shopCartOutPut = new ShopCartOutPut
            {
                ShoppingCartItems = response.ShoppingCart.ShoppingCartItems,
                ShoppingCartTotal = response.ShoppingCartTotal

            };
            return Ok(shopCartOutPut);
        }
        [HttpPost("add-to-cart")]
        public async Task<IActionResult> AddItemToShoppingCart([FromQuery] int id)
        {
            var item = await _moviesService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return Ok("Added to cart sucessfully");
        }
        [HttpPost("remove-from-cart")]
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _moviesService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return Ok("Removed from Cart sucessfully");
        }
    }
}
