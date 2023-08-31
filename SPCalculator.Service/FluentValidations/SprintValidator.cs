using FluentValidation;
using SPCalculator.Entity.Entities;

namespace SPCalculator.Service.FluentValidations
{
    public class SprintValidator : AbstractValidator<Sprint> // Sprint'i baz alarak bir validator oluşturduk ve daha sonra bunu mapleyerek ekleme ve güncelleme işlemlerine de uygulamış olacağız
    {
                public SprintValidator()
        {
            RuleFor(x => x.SprintName).NotEmpty().WithMessage("Sprint name cannot be empty");
            RuleFor(x => x.VersionInfo).NotEmpty().WithMessage("Version Info cannot be empty");
            RuleFor(x => x.ItemNo).NotEmpty().WithMessage("Item No cannot be empty");
            RuleFor(x => x.FunctionId).NotEmpty().WithMessage("Function cannot be empty");
            RuleFor(x => x.ParameterId).NotEmpty().WithMessage("Parameter cannot be empty");
        }
    }
    
}
