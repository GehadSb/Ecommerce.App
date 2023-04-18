using System.Net;

namespace Ecommerce.Application.Exceptions
{
    public interface IExceptionHttpCode
    {
        HttpStatusCode HttpStatus { get; }
    }
}
