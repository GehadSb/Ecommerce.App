using System.Net;

namespace Ecommerce.Application.Exceptions
{
    public class NotFoundException : Exception, IExceptionHttpCode
    {
        public HttpStatusCode HttpStatus => HttpStatusCode.NotFound;

        public NotFoundException(string entityName)
            : base($"\"{entityName}\" was not found.")
        {

        }

    }
}
