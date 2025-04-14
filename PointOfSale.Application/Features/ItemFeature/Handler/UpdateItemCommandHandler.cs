using AutoMapper;
using MediatR;
using PointOfSale.Application.Features.ItemFeature.Command;
using PointOfSale.Application.Interfaces;

namespace PointOfSale.Application.Features.ItemFeature.Handler
{
    public class UpdateItemCommandHandler(IItemRepository itemRepository, IMapper mapper) : IRequestHandler<UpdateItemCommand, Guid>
    {
        public async Task<Guid> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = await itemRepository.GetItemById(request.Id);
            if (item == null)
            {
                throw new KeyNotFoundException($"Item with ID {request.Id} not found.");
            }
            item = mapper.Map(request.UpdateItemDto, item);
            item.UpdatedAt = DateTime.UtcNow;
            return await itemRepository.UpdateItem(item);
        }
    }
}
