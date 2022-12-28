using FluentValidation;
using Models.Implementation;

namespace Validation.Validators;

public class QuestionAnswerValidator : AbstractValidator<AnswerQuestion>
{
    public QuestionAnswerValidator()
    {
        RuleFor(x => x.AnswersAsJson)
            .NotNull().WithMessage("Answers can not be null")
            .NotEmpty().WithMessage("Answers can not be empty")
            .Must(x => x?.ValidateJsonString<List<string>>() ?? false);
        RuleFor(x => x.ActualAnswer)
            .NotNull().WithMessage("ActualAnswer can not be null");

    }

}