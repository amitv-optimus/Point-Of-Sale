using AutoMapper;
using MediatR;
using PointOfSale.Application.Features.ItemFeature.Command;
using PointOfSale.Domain.Entities;
using PointOfSale.Application.Interfaces;

namespace PointOfSale.Application.Features.ItemFeature.Handler
{
    class AddItemCommandHandler(IItemRepository itemRepository, IMapper mapper) : IRequestHandler<AddItemCommand, Item>
    { 
        public async Task<Item> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var itemDto = request.ItemDto;
            var item = mapper.Map<Item>(itemDto);
            item.Id = Guid.NewGuid();
            item.CreatedAt = DateTime.UtcNow;
            item.UpdatedAt = DateTime.UtcNow;
            var result = await itemRepository.AddItem(item); //The value of result depends on the return type of AddItem method in the repository
            return result;
        }
    } 
    }

