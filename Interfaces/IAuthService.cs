using BookingSystem.Models;

namespace BookingSystem.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(User user);
    }
}
