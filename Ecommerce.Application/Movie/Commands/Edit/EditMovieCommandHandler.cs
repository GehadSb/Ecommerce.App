using Ecommerce.Domain.Common;
using Ecommerce.Domain.MovieAggregate.Enums;
using MediatR;

namespace Ecommerce.Application.Movie.Commands.Edit
{
    public class EditMovieCommandHandler : IRequestHandler<EditMovieCommand, EditMovieOutput>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Ecommerce.Domain.MovieAggregate.Movie, long> _movieRepository;
        public EditMovieCommandHandler(IUnitOfWork unitOfWork, IRepository<Ecommerce.Domain.MovieAggregate.Movie, long> movieRepository)
        {
            _unitOfWork = unitOfWork;
            _movieRepository = movieRepository;
        }
        public async Task<EditMovieOutput> Handle(EditMovieCommand request, CancellationToken cancellationToken)
        {
            var movieEdit = await _movieRepository.FindAsync(request.Id);
            if (movieEdit != null)
            {
                var movie = movieEdit.Update(request.MovieName, request.Description, request.StartDate, request.EndDate, request.Price, (MovieStatusEnum)request.MovieStatusId, (MovieCategoryEnum)request.MovieCategoryId, request.CinemaId);
                _movieRepository.Update(movie);
            }
            await _unitOfWork.SaveOrUpdate();

            return new EditMovieOutput() { Id = request.Id };

        }
    }
}
