using FluentValidation;
using SPCalculator.Entity.Entities;

namespace SPCalculator.Service.FluentValidations
{
    public class FunctionValidator : AbstractValidator<Function>
    {
        public FunctionValidator()
        {
            RuleFor(x => x.FunctionName).NotEmpty().WithMessage("Function name cannot be empty");
        }
    }
}
