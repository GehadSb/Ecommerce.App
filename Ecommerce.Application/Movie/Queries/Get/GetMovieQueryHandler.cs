using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Common;
using MediatR;
using System.Linq.Expressions;

namespace Ecommerce.Application.Movie.Queries.Get
{
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, List<GetMoviesOutput>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly IRepository<Ecommerce.Domain.MovieAggregate.Movie, long> _movieRepository;

        public GetMovieQueryHandler(IUnitOfWork unitOfWork, IMapper mapper,
             IRepository<Ecommerce.Domain.MovieAggregate.Movie, long> movieRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public async Task<List<GetMoviesOutput>> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var includes = new Expression<Func<Ecommerce.Domain.MovieAggregate.Movie, object>>[]
            {
                 c => c.Cinema,
                 c=>c.MovieCategory,
            };
            var movies = await _movieRepository.GetAsync(null, includes);
            if (movies is null)
            {
                throw new NotFoundException("Movies");

            }
            return new(_mapper.Map<List<GetMoviesOutput>>(movies));

        }
    }
}
