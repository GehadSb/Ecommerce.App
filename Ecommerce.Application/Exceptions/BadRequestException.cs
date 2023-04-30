using System.Net;

namespace Ecommerce.Application.Exceptions
{
    public class BadRequestException : Exception, IExceptionHttpCode
    {
        public HttpStatusCode HttpStatus => HttpStatusCode.NotFound;

        public BadRequestException(string message)
           : base(message)
        {

        }
    }
}
