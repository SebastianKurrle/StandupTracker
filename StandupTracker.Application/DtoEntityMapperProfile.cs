using AutoMapper;
using StandupTracker.Applications.Dtos;
using StandupTracker.Database;
using StandupTracker.Database.Entities;

namespace StandupTracker.Applications;

public class DtoEntityMapperProfile : Profile
{
    public DtoEntityMapperProfile()
    {
        CreateMap<UserCreate, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => 
            Hash.Hash_SHA256(src.Password)));
    }
}
