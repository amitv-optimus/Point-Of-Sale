using AutoMapper;
using MediatR;
using PointOfSale.Application.DTOs;
using PointOfSale.Application.Features.UserFeature.Query;
using PointOfSale.Application.Interfaces;

namespace PointOfSale.Application.Features.UserFeature.Handler
{
    public class GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<GetAllUsersQuery, List<UserResponseDto>>
    {
        public async Task<List<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAllUsers();
            if (users == null || users.Count == 0)
            {
                throw new Exception("No users found");
            }
            return mapper.Map<List<UserResponseDto>>(users);
        }
    }

}
