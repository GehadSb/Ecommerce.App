using FluentValidation;
using MediatR;

namespace Ecommerce.Application.Common.Behaviours
{
    public class RequestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failuers = validationResults.Where(r => r.Errors.Any()).SelectMany(result => result.Errors);

                if (failuers.Any())
                {
                    throw new Exceptions.ValidationException(failuers);
                }

            }
            return await next();
        }
    }
}
