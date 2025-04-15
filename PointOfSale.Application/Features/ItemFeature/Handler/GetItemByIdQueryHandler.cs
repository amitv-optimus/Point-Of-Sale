using AutoMapper;
using MediatR;
using PointOfSale.Application.DTOs;
using PointOfSale.Application.Features.ItemFeature.Query;
using PointOfSale.Application.Interfaces;

namespace PointOfSale.Application.Features.ItemFeature.Handler
{
    class GetItemByIdQueryHandler(IItemRepository itemRepository, IMapper mapper) : IRequestHandler<GetItemByIdQuery, ItemResponseDto>
    {
        public async Task<ItemResponseDto> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await itemRepository.GetItemById(request.Id);
            if (item == null)
            {
                throw new Exception("Item not found");
            }
            var itemResponseDto = mapper.Map<ItemResponseDto>(item);
            return itemResponseDto;
        }
    }
}
