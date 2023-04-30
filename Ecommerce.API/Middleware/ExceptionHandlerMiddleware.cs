using Ecommerce.Application.Common.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace Ecommerce.API.Middleware
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public ExceptionHandlerMiddleware()
        {
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (ex)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.Failures);
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonConvert.SerializeObject(new { isValid = false, error = ex.Message });
            }

            // logging goes here


            return context.Response.WriteAsync(result);
        }
    }
}
