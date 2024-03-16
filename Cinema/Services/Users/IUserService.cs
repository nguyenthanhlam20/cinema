using Cinema.Models;

namespace Cinema.Services.Users
{
    public interface IUserService
    {
        Task<int> GetTotalUsers();
        Task<User> GetUserByEmail(string email);
        Task<bool> UpdateUser(User user);
        Task<bool> ChangePassword(string email, string newPassword);
    }
}
