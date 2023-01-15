using AutoMapper;
using Entities.Entity;
using Models.Implementation;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Mapping.Mappers;

public class QuestionMapper : Profile
{
    public QuestionMapper()
    {
        CreateMap<Question, QuestionDto>()
            .ForMember(member => member.Answers, 
                options => options
                .MapFrom(expression => JsonConvert.DeserializeObject<List<string>?>(expression.AnswersAsJson ?? "")))
            .ReverseMap()
            .ForMember(member => member.AnswersAsJson,
                options => options
                    .MapFrom(expression => JsonConvert.SerializeObject(expression.Answers)));

    }
}