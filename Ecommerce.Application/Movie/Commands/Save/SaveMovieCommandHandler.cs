using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.MovieAggregate.Enums;
using MediatR;

namespace Ecommerce.Application.Movie.Commands.Save
{
    public class SaveMovieCommandHandler : IRequestHandler<SaveMovieCommand, SaveMovieOutput>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Ecommerce.Domain.MovieAggregate.Movie, long> _movieRepository;
        private readonly IRepository<Ecommerce.Domain.MovieAggregate.Entity.MovieStatus, MovieStatusEnum> _movieStatusRepository;
        private readonly IRepository<Ecommerce.Domain.MovieAggregate.Entity.MovieCategory, MovieCategoryEnum> _movieCategoryRepository;
        private readonly IRepository<Ecommerce.Domain.MovieAggregate.Entity.Cinema, long> _cinemaRepository;
        public SaveMovieCommandHandler(IUnitOfWork unitOfWork, IRepository<Ecommerce.Domain.MovieAggregate.Movie, long> movieRepository,
            IRepository<Ecommerce.Domain.MovieAggregate.Entity.MovieStatus, MovieStatusEnum> movieStatusRepository,
            IRepository<Ecommerce.Domain.MovieAggregate.Entity.MovieCategory, MovieCategoryEnum> movieCategoryRepository,
            IRepository<Ecommerce.Domain.MovieAggregate.Entity.Cinema, long> cinemaRepository
            )
        {
            _unitOfWork = unitOfWork;
            _movieRepository = movieRepository;
            _movieStatusRepository = movieStatusRepository;
            _movieCategoryRepository = movieCategoryRepository;
            _cinemaRepository = cinemaRepository;

        }
        public async Task<SaveMovieOutput> Handle(SaveMovieCommand request, CancellationToken cancellationToken)
        {
            var movieStatusId = await _movieStatusRepository.FindAsync((MovieStatusEnum)request.MovieStatusId);
            if (movieStatusId == null)
            {
                throw new NotFoundException("Movie Status ");
            }

            var movieCategory = await _movieCategoryRepository.FindAsync((MovieCategoryEnum)request.MovieCategoryId);
            if (movieCategory == null)
            {
                throw new NotFoundException("Movie Category ");
            }

            var cinema = await _cinemaRepository.FindAsync(request.CinemaId);
            if (cinema == null)
            {
                throw new NotFoundException("Cinema");
            }

            var movie = Ecommerce.Domain.MovieAggregate.Movie.Create(request.MovieName, request.Description, request.StartDate, request.EndDate, request.Price, (MovieStatusEnum)request.MovieStatusId, (MovieCategoryEnum)request.MovieCategoryId, request.CinemaId);
            await _movieRepository.Add(movie);
            await _unitOfWork.SaveOrUpdate();

            return new SaveMovieOutput() { Id = movie.Id };

        }
    }
}
