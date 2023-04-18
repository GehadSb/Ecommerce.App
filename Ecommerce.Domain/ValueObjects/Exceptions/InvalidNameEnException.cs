namespace Ecommerce.Domain.ValueObjects.Exceptions
{
    [Serializable]
    public class InvalidNameEnException : Exception
    {
        public InvalidNameEnException(string nameEn) : base($"invalid {nameEn}: please re-enter a vaild English name.") { }

    }
}
