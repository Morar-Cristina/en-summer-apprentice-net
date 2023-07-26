using AutoMapper;
using TMSystem.Api.Models;
using TMSystem.Api.Models.Dto;

namespace TMSystem.Api.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, EventPatchDto>().ReverseMap();
        }
    }
}
