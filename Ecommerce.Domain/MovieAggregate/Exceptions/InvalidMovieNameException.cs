namespace Ecommerce.Domain.MovieAggregate.Exceptions
{
    [Serializable]
    public class InvalidMovieNameException : Exception
    {
        public InvalidMovieNameException(string name) : base($"Movie Name : {name} is  invalid")
        {

        }
    }
}
