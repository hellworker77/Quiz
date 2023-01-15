using FluentValidation;
using Models.Implementation;

namespace Validation.Validators;

public class QuestionAnswerValidator : AbstractValidator<AnswerQuestion>
{
    public QuestionAnswerValidator()
    {
        RuleFor(x => x.Answers)
            .NotNull().WithMessage("Answers can not be null")
            .NotEmpty().WithMessage("Answers can not be empty");
        RuleFor(x => x.ActualAnswer)
            .NotNull().WithMessage("ActualAnswer can not be null");

    }

}