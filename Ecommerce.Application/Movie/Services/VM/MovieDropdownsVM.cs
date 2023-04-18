using Ecommerce.Domain.MovieAggregate.Entity;

namespace Ecommerce.Application.Movie.Services.VM
{
    public class MovieDropdownsVM
    {
        public MovieDropdownsVM()
        {
            Cinemas = new List<Cinema>();
        }

        public IReadOnlyList<Cinema> Cinemas { get; set; }

    }
}

