using MediatR;

namespace Ecommerce.Application.Movie.Commands.Save
{
    public class SaveMovieCommand : IRequest<SaveMovieOutput>
    {
        public string MovieName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public int MovieStatusId { get; set; }
        public int MovieCategoryId { get; set; }
        public long CinemaId { get; set; }
    }
}
