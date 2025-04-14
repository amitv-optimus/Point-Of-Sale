using AutoMapper;
using MediatR;
using PointOfSale.Application.Features.OrderFeature.Command;
using PointOfSale.Application.Interfaces;
using PointOfSale.Domain.Constants;
using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.Features.OrderFeature.Handler
{
    public class CreateOrderCommandHandler(IOrderRepository orderRepository, IItemsOrderedRepository itemsOrderedRepository, IItemRepository itemRepository, IMapper mapper) : IRequestHandler<CreateOrderCommand, Guid>
    {
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;
            var orderCreateDto = request.OrderCreateDto;
            if (orderCreateDto == null)
            {
                throw new ArgumentNullException(nameof(orderCreateDto), "OrderCreateDto cannot be null");
            }
            var order = mapper.Map<Order>(orderCreateDto);
            order.Id = Guid.NewGuid();
            order.UserId = userId;
            order.Created = DateTime.UtcNow;
            var items = orderCreateDto.ItemsOrdered;
            if (items == null || items.Count == 0)
            {
                throw new ArgumentException("ItemsOrdered cannot be null or empty", nameof(orderCreateDto.ItemsOrdered));
            }
            string status = OrderStages.Confirmed;
            var Items = new List<ItemsOrdered>();
            foreach (var item in items)
            {
                var Item = mapper.Map<ItemsOrdered>(item);
                Item.Id = Guid.NewGuid();
                Item.OrderID = order.Id;
                var existingItem = await itemRepository.GetItemById(item.ItemID);
                if (existingItem == null)
                {
                    throw new ArgumentException($"Item with ID {item.ItemID} does not exist", nameof(item.ItemID));
                }
                Item.Price = existingItem.Price;
                if(existingItem.Stock < item.Quantity)
                {
                    status = OrderStages.Pending;
                }
                else
                {
                    existingItem.Stock -= item.Quantity;
                    await itemRepository.UpdateItem(existingItem);
                }
                Item.Order = order;
                Items.Add(Item);
            }
            order.Stage = status;
            order.ItemsOrdered = Items;
            return await orderRepository.CreateOrder(order);
        }
    }
}
