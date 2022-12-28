using FluentValidation;
using Models.Implementation;

namespace Validation.Validators;

public class TestAnswerValidator : AbstractValidator<AnswerTest>
{
    public TestAnswerValidator()
    {
        RuleFor(x=>x.AnswerQuestionsDto)
            .ForEach(x=>x.SetValidator(new QuestionAnswerValidator()))
            .NotEmpty().WithMessage("AnswerQuestions can not be null");
    }
}