using AutoMapper;
using Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Models.Implementation;

namespace Mapping.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>()
            .ReverseMap()
            .ForMember(member => member.Email,
                options => options
                    .MapFrom(expression => expression.Email))
            .ForMember(member => member.NormalizedEmail,
                options => options
                    .MapFrom(expression => expression.Email))
            .ForMember(member => member.UserName,
                options => options
                    .MapFrom(expression => expression.UserName))
            .ForMember(member => member.NormalizedEmail,
                options => options
                    .MapFrom(expression => expression.UserName))
            .ForMember(member => member.PasswordHash,
                options => options.Ignore());
    }
}