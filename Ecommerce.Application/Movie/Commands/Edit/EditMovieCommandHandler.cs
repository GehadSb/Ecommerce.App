using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.MovieAggregate.Enums;
using MediatR;

namespace Ecommerce.Application.Movie.Commands.Edit
{
    public class EditMovieCommandHandler : IRequestHandler<EditMovieCommand, EditMovieOutput>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Ecommerce.Domain.MovieAggregate.Movie, long> _movieRepository;
        private readonly IRepository<Ecommerce.Domain.MovieAggregate.Entity.MovieStatus, MovieStatusEnum> _movieStatusRepository;
        private readonly IRepository<Ecommerce.Domain.MovieAggregate.Entity.MovieCategory, MovieCategoryEnum> _movieCategoryRepository;
        private readonly IRepository<Ecommerce.Domain.MovieAggregate.Entity.Cinema, long> _cinemaRepository;
        public EditMovieCommandHandler(IUnitOfWork unitOfWork, IRepository<Ecommerce.Domain.MovieAggregate.Movie, long> movieRepository,
            IRepository<Ecommerce.Domain.MovieAggregate.Entity.MovieStatus, MovieStatusEnum> movieStatusRepository,
            IRepository<Ecommerce.Domain.MovieAggregate.Entity.MovieCategory, MovieCategoryEnum> movieCategoryRepository,
            IRepository<Ecommerce.Domain.MovieAggregate.Entity.Cinema, long> cinemaRepository
            )
        {
            _unitOfWork = unitOfWork;
            _movieRepository = movieRepository;
            _movieStatusRepository = movieStatusRepository;
            _cinemaRepository = cinemaRepository;
            _movieCategoryRepository = movieCategoryRepository;
        }
        public async Task<EditMovieOutput> Handle(EditMovieCommand request, CancellationToken cancellationToken)
        {
            var movieEdit = await _movieRepository.FindAsync(request.Id);
            if (movieEdit == null)
            {
                throw new NotFoundException("Movie ");
            }
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

            var movie = movieEdit.Update(request.MovieName, request.Description, request.StartDate, request.EndDate, request.Price, (MovieStatusEnum)request.MovieStatusId, (MovieCategoryEnum)request.MovieCategoryId, request.CinemaId);
            _movieRepository.Update(movie);

            await _unitOfWork.SaveOrUpdate();

            return new EditMovieOutput() { Id = request.Id };

        }
    }
}
