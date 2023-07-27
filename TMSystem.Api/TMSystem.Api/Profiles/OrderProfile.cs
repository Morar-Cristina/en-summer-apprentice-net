using TMSystem.Api.Models.Dto;
using TMSystem.Api.Models;
using AutoMapper;

namespace TMSystem.Api.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderPatchDto>().ReverseMap();
        }
    }
}
