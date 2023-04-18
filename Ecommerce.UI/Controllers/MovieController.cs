using Ecommerce.Application.Movie.Commands.Edit;
using Ecommerce.Application.Movie.Commands.Save;
using Ecommerce.Application.Movie.Services;
using Ecommerce.UI.Extentions.ModelState;
using Ecommerce.UI.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Ecommerce.UI.Controllers
{
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMediator _mediator;
        private readonly IMovieService _moviesService;
        private IValidator<SaveMovieCommand> _validator;
        private IValidator<EditMovieCommand> _editValidator;
        public MovieController(ILogger<MovieController> logger, IMediator mediator, IMovieService movieService, IValidator<SaveMovieCommand> validator, IValidator<EditMovieCommand> editValidator)
        {
            _logger = logger;
            _mediator = mediator;
            _moviesService = movieService;
            _validator = validator;
            _editValidator = editValidator;
        }
        public async Task<ActionResult> Index()
        {
            // bool value = User.Identity.IsAuthenticated;
            return View(await _mediator.Send(new Application.Movie.Queries.Get.GetMovieQuery()));
        }
        // [Authorize(Roles = "Adminstration")]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _moviesService.GetMovieByIdAsync(id);
            return View(movieDetail);
        }
        public async Task<IActionResult> Save()
        {
            var movieDropdownsData = await _moviesService.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(SaveMovieCommand command)
        {

            ValidationResult result = await _validator.ValidateAsync(command);
            if (!result.IsValid)
            {
                var movieDropdownsData = await _moviesService.GetNewMovieDropdownsValues();
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                result.AddToModelState(this.ModelState);
                return View("Save", command);
            }
            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(long id)
        {
            var movieDetails = await _moviesService.GetMovieByIdAsync(id);
            if (movieDetails == null)
            {
                return View("NotFound");

            }
            var response = new EditMovieCommand
            {
                Id = movieDetails.Id,
                MovieName = movieDetails.MovieName,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                MovieCategoryId = (int)movieDetails.MovieCategoryId,
                CinemaId = movieDetails.CinemaId,
                MovieStatusId = (int)movieDetails.MovieStatusId,
            };
            var movieDropdownsData = await _moviesService.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditMovieCommand command)
        {
            var movieDetails = await _moviesService.GetMovieByIdAsync(command.Id);
            if (movieDetails == null)
            {
                return View("NotFound");

            }
            ValidationResult result = await _editValidator.ValidateAsync(command);
            if (!result.IsValid)
            {
                var movieDropdownsData = await _moviesService.GetNewMovieDropdownsValues();
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                result.AddToModelState(this.ModelState);
                return View("Edit", command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
