using Ecommerce.Domain.MovieAggregate;

namespace Ecommerce.Domain.ShoppingCartItemAggregate.Exceptions
{
    [Serializable]
    public class InvalidMovieException : Exception
    {
        public InvalidMovieException(Movie movie) : base($"Movie is {movie} is  invalid")
        {

        }
    }
}
