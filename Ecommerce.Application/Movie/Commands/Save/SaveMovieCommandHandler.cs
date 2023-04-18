using Ecommerce.Domain.Common;
using Ecommerce.Domain.MovieAggregate.Enums;
using MediatR;

namespace Ecommerce.Application.Movie.Commands.Save
{
    public class SaveMovieCommandHandler : IRequestHandler<SaveMovieCommand, SaveMovieOutput>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Ecommerce.Domain.MovieAggregate.Movie, long> _movieRepository;
        public SaveMovieCommandHandler(IUnitOfWork unitOfWork, IRepository<Ecommerce.Domain.MovieAggregate.Movie, long> movieRepository)
        {
            _unitOfWork = unitOfWork;
            _movieRepository = movieRepository;
        }
        public async Task<SaveMovieOutput> Handle(SaveMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = Ecommerce.Domain.MovieAggregate.Movie.Create(request.MovieName, request.Description, request.StartDate, request.EndDate, request.Price, (MovieStatusEnum)request.MovieStatusId, (MovieCategoryEnum)request.MovieCategoryId, request.CinemaId);
            await _movieRepository.Add(movie);
            await _unitOfWork.SaveOrUpdate();

            return new SaveMovieOutput() { Id = movie.Id };

        }
    }
}
