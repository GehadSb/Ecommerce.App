using MediatR;

namespace Ecommerce.Application.Movie.Queries.GetById
{
    public class GetByIdMovieQuery : IRequest<GetByIdMoviesOutput>
    {
        public long Id { get; set; }
    }
}
