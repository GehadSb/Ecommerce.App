using Ecommerce.Domain.Common;
using Ecommerce.Domain.MovieAggregate.Entity;
using Ecommerce.Domain.MovieAggregate.Enums;
using Ecommerce.Domain.MovieAggregate.Exceptions;

namespace Ecommerce.Domain.MovieAggregate
{
    public class Movie : BaseEntity<long>
    {
        public virtual string MovieName { get; private set; } = null!;
        public virtual string Description { get; private set; }
        public virtual DateTime StartDate { get; private set; }
        public virtual DateTime EndDate { get; private set; }
        public virtual decimal Price { get; private set; }
        public virtual MovieStatusEnum MovieStatusId { get; set; }
        public virtual MovieCategoryEnum MovieCategoryId { get; private set; }
        public virtual MovieCategory MovieCategory { get; private set; }

        public virtual long CinemaId { get; private set; }
        public virtual Cinema Cinema { get; private set; }

        protected Movie()
        {

        }
        public Movie(string movieName, string description, DateTime startDate, DateTime endDate,
            decimal price, MovieStatusEnum status, MovieCategoryEnum movieCategoryId, long cinemaId)
        {
            MovieName = movieName;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
            MovieStatusId = status;
            MovieCategoryId = movieCategoryId;
            CinemaId = cinemaId;
        }

        public static Movie Create(string movieName, string description, DateTime startDate, DateTime endDate,
            decimal price, MovieStatusEnum status, MovieCategoryEnum movieCategoryId, long cinemaId)
        {
            if (string.IsNullOrEmpty(movieName))
            {
                throw new InvalidMovieNameException(movieName);
            }
            return new Movie(movieName, description, startDate, endDate, price, status, movieCategoryId, cinemaId);
        }
        public Movie Update(string movieName, string description, DateTime startDate, DateTime endDate,
        decimal price, MovieStatusEnum status, MovieCategoryEnum movieCategoryId, long cinemaId)
        {
            if (string.IsNullOrEmpty(movieName))
            {
                throw new InvalidMovieNameException(movieName);
            }
            MovieName = movieName;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
            MovieStatusId = status;
            MovieCategoryId = movieCategoryId;
            CinemaId = cinemaId;

            return this;
        }
    }
}
