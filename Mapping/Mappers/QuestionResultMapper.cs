using AutoMapper;
using Entities.Entity;
using Models.Implementation;

namespace Mapping.Mappers;

public class QuestionResultMapper : Profile
{
    public QuestionResultMapper()
    {
        CreateMap<QuestionResult, QuestionResultDto>().ReverseMap();
    }
}