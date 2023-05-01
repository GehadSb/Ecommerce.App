using Ecommerce.Application.Movie.Commands.Edit;
using Ecommerce.Application.Movie.Commands.Save;
using Ecommerce.Application.Movie.Queries.GetById;
using Ecommerce.Application.Movie.Services;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMovieService _moviesService;
        private IValidator<SaveMovieCommand> _validator;
        private IValidator<EditMovieCommand> _editValidator;
        public MovieController(IMediator mediator, IMovieService movieService, IValidator<SaveMovieCommand> validator, IValidator<EditMovieCommand> editValidator)
        {
            _mediator = mediator;
            _moviesService = movieService;
            _validator = validator;
            _editValidator = editValidator;
        }
        [HttpGet("all-movies")]
        public async Task<ActionResult> Get()
        {
            return Ok(await _mediator.Send(new Application.Movie.Queries.Get.GetMovieQuery()));
        }
        [HttpGet("movie-details")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdMovieQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost("create-movie")]
        public async Task<IActionResult> Save(SaveMovieCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("edit-movie")]
        public async Task<IActionResult> Edit(EditMovieCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
