using Ecommerce.Application.Movie.Dtos;
using MediatR;

namespace Ecommerce.Application.Movie.Queries.Get
{
    public class GetMovieQuery : IRequest<List<GetMoviesOutput>>
    {
    }
}
