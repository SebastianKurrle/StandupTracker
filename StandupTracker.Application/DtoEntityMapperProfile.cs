using AutoMapper;
using StandupTracker.Application.Dtos;
using StandupTracker.Database.Entities;

namespace StandupTracker.Application;

public class DtoEntityMapperProfile : Profile
{
    public DtoEntityMapperProfile()
    {
        CreateMap<UserCreate, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
