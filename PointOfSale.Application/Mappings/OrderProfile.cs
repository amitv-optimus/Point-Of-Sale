using AutoMapper;
using PointOfSale.Application.DTOs;
using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderCreateDto, Order>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.Stage, opt => opt.Ignore())
                .ForMember(dest => dest.ItemsOrdered, opt => opt.Ignore());
            CreateMap<Order, OrderResponseDto>()
                .ForMember(dest => dest.ItemsOrdered, opt => opt.MapFrom(src => src.ItemsOrdered));
        }
    }
}
