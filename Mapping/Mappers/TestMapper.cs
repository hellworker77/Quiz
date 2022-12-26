using AutoMapper;
using Entities.Entity;
using Models.Implementation;

namespace Mapping.Mappers;

public class TestMapper : Profile
{
    public TestMapper()
    {
        CreateMap<Test, TestDto>().ReverseMap();
    }
}