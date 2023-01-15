using FluentValidation;
using Models.Implementation;
using Newtonsoft.Json;

namespace Validation.Validators;

public class QuestionValidator : AbstractValidator<QuestionDto>
{
    public QuestionValidator()
    {
        RuleFor(x => x.Title)
            .NotNull().WithMessage("Title can not be null")
            .NotEmpty().WithMessage("Title can not be empty");
        RuleFor(x => x.Answers)
            .NotNull().WithMessage("Answers can not be null")
            .NotEmpty().WithMessage("Answers can not be empty");
        RuleFor(x=>x.CorrectAnswer)
            .NotNull().WithMessage("CorrectAnswer can not be null")
            .NotEmpty().WithMessage("CorrectAnswer can not be empty");
    }
    
}