using Confluent.Kafka;
using Ecommerce.Application.Movie.Services;
using Ecommerce.Application.Order.Commands.Save;
using Ecommerce.UI.Helper.Cart;
using Ecommerce.UI.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace Ecommerce.UI.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly ILogger<MovieController> _logger;
        private readonly IMediator _mediator;
        private readonly IMovieService _moviesService;
        private readonly string
      bootstrapServers = "localhost:9092";
        private readonly string topic = "eticket";

        public OrdersController(ShoppingCart shoppingCart, ILogger<MovieController> logger, IMediator mediator, IMovieService movieService)
        {
            _shoppingCart = shoppingCart;
            _logger = logger;
            _mediator = mediator;
            _moviesService = movieService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }
        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _moviesService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _moviesService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            userId = "geeeggg";
            var result = await _mediator.Send(new SaveOrderCommand() { ShoppingCartItems = items, UserId = userId });

            await _shoppingCart.ClearShoppingCartAsync();
            // string message = JsonSerializer.Serialize(result.Id);
            //  await SendOrderRequest(topic, message);

            return View("OrderCompleted");
        }
        private async Task<bool> SendOrderRequest
        (string topic, string message)
        {
            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers,
                ClientId = Dns.GetHostName(),
                // EnableDeliveryReports = true,
                Debug = "msg",

                // retry settings:
                // Receive acknowledgement from all sync replicas
                //Acks = Acks.All,
                // Number of times to retry before giving up
                //  MessageSendMaxRetries = 3,
                // Duration to retry before next attempt
                //RetryBackoffMs = 1000,
                // Set to true if you don't want to reorder messages on retry
                //EnableIdempotence = true


                SecurityProtocol = SecurityProtocol.Plaintext,
                EnableDeliveryReports = false,
                QueueBufferingMaxMessages = 10000000,
                QueueBufferingMaxKbytes = 100000000,
                BatchNumMessages = 500,
                Acks = Acks.None,
                DeliveryReportFields = "none"
            };

            try
            {
                using (var producer = new ProducerBuilder
                <long, string>(config).Build())
                {
                    var result = await producer.ProduceAsync
                    (topic, new Message<long, string>
                    {
                        Key = DateTime.UtcNow.Ticks,
                        Value = message
                    });
                    Console.WriteLine($"Message sent (value: '{message}'). Delivery status: {result.Status}");
                    //   Debug.WriteLine($"Delivery Timestamp:{result.Timestamp.UtcDateTime}");
                    if (result.Status != PersistenceStatus.Persisted)
                    {
                        // delivery might have failed after retries. This message requires manual processing.
                        Console.WriteLine(
                            $"ERROR: Message not ack'd by all brokers (value: '{message}'). Delivery status: {result.Status}");
                    }
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    return await Task.FromResult(true);
                }
            }
            catch (ProduceException<long, string> ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
                // Log this message for manual processing.

                Console.WriteLine($"Permanent error: {ex.Message} for message (value: '{ex.DeliveryResult.Value}')");
                Console.WriteLine("Exiting producer...");
            }

            return await Task.FromResult(false);
        }
    }
}
