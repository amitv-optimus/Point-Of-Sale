using AutoMapper;
using MediatR;
using PointOfSale.Application.DTOs;
using PointOfSale.Application.Features.ItemFeature.Query;
using PointOfSale.Application.Interfaces;

namespace PointOfSale.Application.Features.ItemFeature.Handler
{
    public class GetAllItemsQueryHandler(IItemRepository itemRepository, IMapper mapper) : IRequestHandler<GetAllItemsQuery, List<ItemDto>>
    {
        public async Task<List<ItemDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await itemRepository.GetAllItems();
            return mapper.Map<List<ItemDto>>(items);
        }
    }
}
