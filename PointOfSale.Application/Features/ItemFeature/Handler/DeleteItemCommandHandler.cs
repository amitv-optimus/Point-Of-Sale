using MediatR;
using PointOfSale.Application.Features.ItemFeature.Command;
using PointOfSale.Application.Interfaces;

namespace PointOfSale.Application.Features.ItemFeature.Handler
{
    public class DeleteItemCommandHandler(IItemRepository itemRepository) : IRequestHandler<DeleteItemCommand, Guid>
    {
        public async Task<Guid> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var item = await itemRepository.GetItemById(request.Id);
            if (item == null)
            {
                throw new KeyNotFoundException($"Item with ID {request.Id} not found.");
            }
            var result = await itemRepository.DeleteItem(item.Id);
            return result;
        }
    }
}
