using Ecommerce.Application.Common.Dtos;
using Ecommerce.Application.Movie.Dtos;
using Ecommerce.Domain.MovieAggregate.Enums;

namespace Ecommerce.Application.Movie.Queries.Get
{
    public class GetMoviesOutput
    {
        public long Id { get; set; }
        public string MovieName { get; set; } = null!;
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public int MovieStatusId { get; set; }
        public int MovieCategoryId { get; set; }
        public LookupDto<MovieCategoryEnum> MovieCategory { get; set; }
        public int CinemaId { get; private set; }
        public CinemaDto Cinema { get; private set; }
    }
}
