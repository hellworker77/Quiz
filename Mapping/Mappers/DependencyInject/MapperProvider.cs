using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Mapping.Mappers.DependencyInject;

public static class MapperProvider
{
    public static void MappersProvide(this IServiceCollection services)
    {
        var mapperConfiguration = new MapperConfiguration(options =>
        {
            options.AddProfile(new QuestionMapper());
            options.AddProfile(new TestMapper());
            options.AddProfile(new TestResultMapper());
            options.AddProfile(new QuestionResultMapper());
            options.AddProfile(new UserMapper());
            options.AddProfile(new MediaMapper());
        });

        var mapper = mapperConfiguration.CreateMapper();
        services.AddSingleton(mapper);
    }
}