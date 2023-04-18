using Ecommerce.Application.Movie.Queries.Get;
using Ecommerce.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;

namespace Ecommerce.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        //public async Task<ActionResult> Index()
        //{
        //    return View(await _mediator.Send(new Application.Movie.Queries.Get.GetMovieQuery()));
        //}
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> Privacy([FromQuery, BindRequired] GetMovieQuery query)
        {
            //  var gg = (await _mediator.Send(query));
            return View(await _mediator.Send(query));
        }




        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}