using AutoMapper;
using Ecommerce.Application.Movie.Services.VM;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.MovieAggregate.Enums;
using System.Linq.Expressions;

namespace Ecommerce.Application.Movie.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Ecommerce.Domain.MovieAggregate.Movie, long> _movieRepository;
        private readonly IRepository<Ecommerce.Domain.MovieAggregate.Entity.Cinema, long> _cinemaepository;
        private readonly IRepository<Ecommerce.Domain.MovieAggregate.Entity.MovieCategory, MovieCategoryEnum> _moviecCtegoryRepository;
        private readonly IRepository<Ecommerce.Domain.MovieAggregate.Entity.MovieStatus, MovieStatusEnum> _movieStatusRepository;

        public MovieService(IMapper mapper, IRepository<Ecommerce.Domain.MovieAggregate.Movie, long> movieRepository,
            IRepository<Ecommerce.Domain.MovieAggregate.Entity.MovieStatus, MovieStatusEnum> movieStatusRepository,
            IRepository<Ecommerce.Domain.MovieAggregate.Entity.MovieCategory, MovieCategoryEnum> moviecCtegoryRepository,
            IRepository<Ecommerce.Domain.MovieAggregate.Entity.Cinema, long> cinemaepository
            )
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _movieStatusRepository = movieStatusRepository;
            _moviecCtegoryRepository = moviecCtegoryRepository;
            _cinemaepository = cinemaepository;
        }
        public async Task<Ecommerce.Domain.MovieAggregate.Movie> GetMovieByIdAsync(long id)
        {
            var includes = new Expression<Func<Ecommerce.Domain.MovieAggregate.Movie, object>>[]
           {
                 c => c.Cinema,
                 c=>c.MovieCategory,
           };
            var movie = await _movieRepository.FindAsync(id, includes);
            if (movie is null)
            {
                return null;

            }
            return movie;
        }
        public async Task<MovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new MovieDropdownsVM()
            {
                Cinemas = await _cinemaepository.GetAsync(),
            };

            return response;
        }
    }

}
