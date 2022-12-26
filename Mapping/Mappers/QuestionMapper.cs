using AutoMapper;
using Entities.Entity;
using Models.Implementation;

namespace Mapping.Mappers;

public class QuestionMapper : Profile
{
    public QuestionMapper()
    {
        CreateMap<Question, QuestionDto>().ReverseMap();
    }
}