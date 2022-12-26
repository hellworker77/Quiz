using DataAccessLayer.Abstraction.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.Repository.DependencyInject;

public static class RepositoryProvider
{
    public static void RepositoriesProvide(this IServiceCollection services)
    {
        services.AddTransient<IQuestionRepository, QuestionRepository>();
        services.AddTransient<ITestRepository, TestRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ITestResultRepository, TestResultRepository>();
        services.AddTransient<IQuestionResultRepository, QuestionResultRepository>();
    }
}