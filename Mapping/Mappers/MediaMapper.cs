using AutoMapper;
using Entities.Entity;
using Entities.Entity.Abstraction;
using Models.Implementation;

namespace Mapping.Mappers;

public class MediaMapper : Profile
{
    public MediaMapper()
    {
        CreateMap<Media, MediaDto>();

        CreateMap<MediaQuestion, MediaDto>().ReverseMap().ReverseMap().ForMember(member => member.Data,
            options => options.Ignore());
        CreateMap<MediaTest, MediaDto>().ReverseMap().ReverseMap().ForMember(member => member.Data,
            options => options.Ignore());
    }
}