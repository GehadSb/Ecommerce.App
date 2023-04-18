using Ecommerce.Application.Movie.Services.VM;

namespace Ecommerce.Application.Movie.Services
{
    public interface IMovieService
    {
        Task<Ecommerce.Domain.MovieAggregate.Movie> GetMovieByIdAsync(long id);
        Task<MovieDropdownsVM> GetNewMovieDropdownsValues();
    }
}
