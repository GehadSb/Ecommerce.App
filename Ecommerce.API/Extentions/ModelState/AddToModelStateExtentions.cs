using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ecommerce.API.Extentions.ModelState
{
    public static class AddToModelStateExtentions
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
