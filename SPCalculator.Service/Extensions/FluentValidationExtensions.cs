using Microsoft.AspNetCore.Mvc.ModelBinding;
using FluentValidation.Results;

namespace SPCalculator.Service.Extensions
{
    public static class FluentValidationExtensions
    {
        public static void AddToModelState(this ValidationResult validationResult, ModelStateDictionary modelStateDictionary)
        {
            foreach (var error in validationResult.Errors)
            {
                modelStateDictionary.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
