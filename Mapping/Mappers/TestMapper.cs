using AutoMapper;
using Entities.Entity;
using Models.Implementation;

namespace Mapping.Mappers;

public class TestMapper : Profile
{
    public TestMapper()
    {
        CreateMap<Test, TestDto>()
            .ForMember(member=> member.QuestionsDto,
            options=> options
            .MapFrom(expression=> expression.Questions))
            .ReverseMap()
            .ForMember(member => member.Questions,
                options => options
                    .MapFrom(expression => expression.QuestionsDto));
    }
}