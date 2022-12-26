using AutoMapper;
using Entities.Entity;
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
        });

        var mapper = mapperConfiguration.CreateMapper();
        services.AddSingleton(mapper);
    }
}