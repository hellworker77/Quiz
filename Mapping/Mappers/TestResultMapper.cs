using AutoMapper;
using Entities.Entity;
using Models.Implementation;

namespace Mapping.Mappers;

public class TestResultMapper : Profile
{
    public TestResultMapper()
    {
        CreateMap<TestResult, TestResultDto>()
            .ForMember(member=>member.QuestionResultsDto, 
                options => options
                    .MapFrom(expression => expression.QuestionResults))
            .ReverseMap()
            .ForMember(member => member.QuestionResults,
                options => options
                    .MapFrom(expression => expression.QuestionResultsDto));
    }
}