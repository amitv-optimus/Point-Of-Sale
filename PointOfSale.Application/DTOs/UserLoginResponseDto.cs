namespace PointOfSale.Application.DTOs
{
    public class UserLoginResponseDto
    {
        public UserResponseDto User { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
