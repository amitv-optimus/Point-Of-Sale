using AutoMapper;
using MediatR;
using PointOfSale.Application.DTOs;
using PointOfSale.Application.Features.OrderFeature.Query;
using PointOfSale.Application.Interfaces;
using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.Features.OrderFeature.Handler
{
    public class GetOrdersByUserIdQueryHandler(IOrderRepository orderRepository, IMapper mapper) : IRequestHandler<GetOrdersByUserIdQuery, List<OrderResponseDto>>
    {
        public async Task<List<OrderResponseDto>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await orderRepository.GetOrdersByUserId(request.UserId);
            if (orders == null || orders.Count==0)
            {
                throw new ArgumentException($"No orders found for user with ID {request.UserId}", nameof(request.UserId));
            }
            var response = mapper.Map<List<OrderResponseDto>>(orders);
            return response;
        }
    }
}
