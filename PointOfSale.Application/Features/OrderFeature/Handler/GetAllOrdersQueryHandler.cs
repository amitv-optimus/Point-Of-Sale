using AutoMapper;
using MediatR;
using PointOfSale.Application.DTOs;
using PointOfSale.Application.Features.OrderFeature.Query;
using PointOfSale.Application.Interfaces;

namespace PointOfSale.Application.Features.OrderFeature.Handler
{
    public class GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper) : IRequestHandler<GetAllOrdersQuery, List<OrderResponseDto>>
    {
        public async Task<List<OrderResponseDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await orderRepository.GetAllOrders();
            var response = mapper.Map<List<OrderResponseDto>>(orders);
            return response;
        }
    }
}
