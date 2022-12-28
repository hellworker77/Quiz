using FluentValidation;
using Models.Implementation;

namespace Validation.Validators;

public class TestValidator : AbstractValidator<TestDto>
{
    public TestValidator()
    {
        RuleFor(x => x.Description)
            .NotNull().WithMessage("Description can not be null");
        RuleFor(x=>x.Name)
            .NotNull().WithMessage("Name can not be null")
            .NotEmpty().WithMessage("Name can not be empty");
        RuleFor(x => x.QuestionsDto)
            .NotNull().WithMessage("Questions can not be null")
            .Must(x => x?.Count > 0).WithMessage("Questions can not be empty")
            .ForEach(x => x.SetValidator(new QuestionValidator()));
    }
}