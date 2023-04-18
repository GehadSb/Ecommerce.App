using System.Globalization;

namespace Ecommerce.Domain.Exceptions
{
    [Serializable]
    public class UniqueConstraintException : Exception
    {
        public UniqueConstraintException() : base() { }

        public UniqueConstraintException(string message) : base(message) { }

        public UniqueConstraintException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }

    }
}
