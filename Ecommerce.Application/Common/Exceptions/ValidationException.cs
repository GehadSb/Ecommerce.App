using FluentValidation.Results;

namespace Ecommerce.Application.Common.Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Failures { get; }

        public ValidationException() : base("One or more validtion failuers have occurred.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            var propertiesNames = failures.Select(p => p.PropertyName).Distinct();

            foreach (var propertyName in propertiesNames)
            {
                var propertyFailuers = failures.Where(f => f.PropertyName == propertyName).Select(f => f.ErrorMessage).ToArray();
                Failures.Add(propertyName, propertyFailuers);
            }
        }
    }
}
