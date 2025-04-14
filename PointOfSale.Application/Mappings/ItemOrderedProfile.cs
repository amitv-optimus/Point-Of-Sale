using AutoMapper;
using PointOfSale.Application.DTOs;
using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.Mappings
{
    public class ItemOrderedProfile : Profile
    {
        public ItemOrderedProfile()
        {
            CreateMap<ItemOrderDto, ItemsOrdered>();
            CreateMap<ItemsOrdered, ItemOrderResponseDto>();
        }
    }

}
