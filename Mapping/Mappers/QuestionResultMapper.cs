using AutoMapper;
using Entities.Entity;
using Models.Implementation;
using Newtonsoft.Json;

namespace Mapping.Mappers;

public class QuestionResultMapper : Profile
{
    public QuestionResultMapper()
    {
        CreateMap<QuestionResult, QuestionResultDto>()
            .ForMember(member => member.Answers,
                options => options
                    .MapFrom(expression => JsonConvert.DeserializeObject<List<string>?>(expression.AnswersAsJson ?? "")))
            .ReverseMap()
            .ForMember(member => member.AnswersAsJson,
                options => options
                    .MapFrom(expression => JsonConvert.SerializeObject(expression.Answers)));
    }
}