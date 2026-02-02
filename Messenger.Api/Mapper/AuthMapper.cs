using AutoMapper;
using Messenger.Api.Entities.Identity;
using Messenger.Api.Models.Auth;
using Messenger.Api.Models.Seeder;

namespace Messenger.Api.Mapper;

public class AuthMapper : Profile
{
    public AuthMapper()
    {
        CreateMap<RegisterModel, UserEntity>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email));
        CreateMap<SeederUserModel, UserEntity>()
            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email));
    }
}
