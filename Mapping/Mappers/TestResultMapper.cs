using AutoMapper;
using Entities.Entity;
using Models.Implementation;

namespace Mapping.Mappers;

public class TestResultMapper : Profile
{
    public TestResultMapper()
    {
        CreateMap<TestResult, TestResultDto>().ReverseMap();
    }
}