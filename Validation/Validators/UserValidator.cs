using FluentValidation;
using Models.Implementation;

namespace Validation.Validators;

public class UserValidator : AbstractValidator<UserDto>
{
    public UserValidator()
    {
        RuleFor(x => x.UserName)
            .NotNull().WithMessage("UserName can not be null")
            .NotEmpty().WithMessage("UserName can not be empty")
            .Must(x => x?.Length > 5).WithMessage("Your username is too short");
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Your email is not like default email pattern");
        RuleFor(x => x)
            .Must(x => CheckPasswordsEquals(x.Password, x.RepeatPassword)).WithMessage("Passwords not equals");
    }


    private bool CheckPasswordsEquals(string? password, string? repeatPassword)
    {
        var notNull = password != null;

        return password?.Equals(repeatPassword) ?? false || !notNull;
    }
}