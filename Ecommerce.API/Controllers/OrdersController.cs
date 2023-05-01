using AutoMapper;
using Ecommerce.API.Helper.Cart;
using Ecommerce.API.ViewModels;
using Ecommerce.Application.Movie.Services;
using Ecommerce.Application.Order.Commands.Save;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        private readonly IMapper _mapper;

        public OrdersController(ShoppingCart shoppingCart, ILogger<MovieController> logger, IMediator mediator, IMovieService movieService, IMapper mapper)
        {
            _shoppingCart = shoppingCart;
            _logger = logger;
            _mediator = mediator;
            _moviesService = movieService;
            _mapper = mapper;
        }
        [HttpGet("list-shopping-cart")]
        public async Task<IActionResult> Get()
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
        public async Task<IActionResult> Add([FromQuery] int id)
        {
            var item = await _moviesService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return Ok("Added to cart sucessfully");
        }
        [HttpPost("remove-from-cart")]
        public async Task<IActionResult> Remove(int id)
        {
            var item = await _moviesService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return Ok("Removed from Cart sucessfully");
        }
        [HttpPost("complete-order-cart")]
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            List<ShoppingCartItemInput> shoppingCartItems = new List<ShoppingCartItemInput>();
            if (items.Count > 0 && items != null)
            {
                shoppingCartItems = new(_mapper.Map<List<ShoppingCartItemInput>>(items));
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            userId = "geeeggg";
            var result = await _mediator.Send(new SaveOrderCommand() { ShoppingCartItems = shoppingCartItems, UserId = userId });

            await _shoppingCart.ClearShoppingCartAsync();
            return Ok("OrderCompleted");
        }
    }
}
