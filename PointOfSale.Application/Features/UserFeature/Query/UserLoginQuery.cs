using MediatR;
using PointOfSale.Application.DTOs;


namespace PointOfSale.Application.Features.UserFeature.Query
{
    public record UserLoginQuery(UserLoginDto UserLoginDto) : IRequest<UserLoginResponseDto>;
}