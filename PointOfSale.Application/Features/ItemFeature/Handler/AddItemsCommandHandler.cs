using AutoMapper;
using MediatR;
using PointOfSale.Application.Features.ItemFeature.Command;
using PointOfSale.Application.Interfaces;
using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.Features.ItemFeature.Handler
{
    public class AddItemsCommandHandler(IMapper mapper, IItemRepository itemRepository) : IRequestHandler<AddItemsCommand, ICollection<Item>>
    {
        public async Task<ICollection<Item>> Handle(AddItemsCommand request, CancellationToken cancellationToken)
        {
            var Items = new List<Item>();
            foreach(var itemDto in request.ItemsDto)
            {
                var item = mapper.Map<Item>(itemDto);
                item.Id = Guid.NewGuid();
                item.CreatedAt = DateTime.UtcNow;
                item.UpdatedAt = DateTime.UtcNow;
                Items.Add(item);
            }
            return await itemRepository.AddItems(Items);
        }
    }
}
