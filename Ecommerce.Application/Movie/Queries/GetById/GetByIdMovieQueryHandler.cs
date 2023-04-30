using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Common;
using MediatR;
using System.Linq.Expressions;

namespace Ecommerce.Application.Movie.Queries.GetById
{
    public class GetByIdMovieQueryHandler : IRequestHandler<GetByIdMovieQuery, GetByIdMoviesOutput>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Ecommerce.Domain.MovieAggregate.Movie, long> _movieRepository;

        public GetByIdMovieQueryHandler(IUnitOfWork unitOfWork, IMapper mapper,
             IRepository<Ecommerce.Domain.MovieAggregate.Movie, long> movieRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public async Task<GetByIdMoviesOutput> Handle(GetByIdMovieQuery request, CancellationToken cancellationToken)
        {
            var includes = new Expression<Func<Ecommerce.Domain.MovieAggregate.Movie, object>>[]
               {
                 c => c.Cinema,
                 c=>c.MovieCategory,
               };
            var movie = await _movieRepository.FindAsync(request.Id, includes);
            if (movie is null)
            {
                throw new NotFoundException("Movie");
            }

            return _mapper.Map<GetByIdMoviesOutput>(movie);
        }
    }
}