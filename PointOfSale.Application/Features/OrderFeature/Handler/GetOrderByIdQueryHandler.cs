using AutoMapper;
using MediatR;
using PointOfSale.Application.DTOs;
using PointOfSale.Application.Features.OrderFeature.Query;
using PointOfSale.Application.Interfaces;

namespace PointOfSale.Application.Features.OrderFeature.Handler
{
    public class GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper) : IRequestHandler<GetOrderByIdQuery, OrderResponseDto>
    {
        public async Task<OrderResponseDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.GetOrderById(request.Id);
            if (order == null)
            {
                throw new ArgumentException($"Order with ID {request.Id} does not exist", nameof(request.Id));
            }
            var response = mapper.Map<OrderResponseDto>(order);
            return response;
        }
    }
}
