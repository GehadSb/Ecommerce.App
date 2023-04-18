namespace Ecommerce.Domain.OrderAggregate.Exceptions
{
    [Serializable]
    public class InvalidUserIdException : Exception
    {
        public InvalidUserIdException(string userId) : base($"UserId : {userId} is  invalid")
        {

        }
    }
}
