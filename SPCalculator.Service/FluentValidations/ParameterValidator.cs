using FluentValidation;
using SPCalculator.Entity.Entities;

namespace SPCalculator.Service.FluentValidations
{
    public class ParameterValidator : AbstractValidator<Parameter>
    {
        public ParameterValidator()
        {
            RuleFor(x => x.ParameterName).NotEmpty().WithMessage("Parameter name cannot be empty");
            RuleFor(x => x.ParameterDesc).NotEmpty().WithMessage("Parameter description cannot be empty");
            RuleFor(x => x.ParameterPoint).NotEmpty().WithMessage("Parameter point cannot be empty");
        }
    }
}
