using Cinema.Models;
using Cinema.Requests;

namespace Cinema.Services.Authens
{
    public interface IAuthenService
    {
        Task<User> Login(LoginRequest request);
        Task<bool> Register(User user);
    }
}
