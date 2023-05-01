using Ecommerce.Domain.MovieAggregate.Enums;

namespace Ecommerce.Application.Order.Commands.Save
{
    public class MovieInput
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string MovieName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public MovieStatusEnum MovieStatusId { get; set; }
        public MovieCategoryEnum MovieCategoryId { get; set; }
        public long CinemaId { get; set; }
    }
}
