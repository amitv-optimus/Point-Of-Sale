using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
