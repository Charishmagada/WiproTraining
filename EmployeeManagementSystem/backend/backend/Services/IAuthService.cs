using backend.Models;

namespace backend.Services
{
    public interface IAuthService
    {
        Task<(string? Token, User? User)> Authenticate(string username, string password);
    }
}
