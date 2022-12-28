using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Models.Implementation;
using Validation.Validators;

namespace Validation.DependencyInject;

public static class ValidatorsProvider 
{
    public static void ValidatorsProvide(this IServiceCollection services)
    {
        services.AddScoped<IValidator<AnswerQuestion>, QuestionAnswerValidator>();
        services.AddScoped<IValidator<AnswerTest>, TestAnswerValidator>();
        services.AddScoped<IValidator<QuestionDto>, QuestionValidator>();
        services.AddScoped<IValidator<TestDto>, TestValidator>();
    }
}