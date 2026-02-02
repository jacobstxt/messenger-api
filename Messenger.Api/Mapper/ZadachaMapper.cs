using AutoMapper;
using Messenger.Api.Entities;
using Messenger.Api.Models.Zadachi;

namespace Messenger.Api.Mapper;

public class ZadachaMapper : Profile
{
    public ZadachaMapper()
    {
        CreateMap<ZadachaItemModel, ZadachaEntity>().ReverseMap();
        CreateMap<ZadachaCreateModel, ZadachaEntity>()
            .ForMember(dest => dest.Image, opt => opt.Ignore());
        CreateMap<ZadachaUpdateModel, ZadachaEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Image, opt => opt.Ignore());
    }
}
