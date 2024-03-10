using Cinema.Enums;
using Cinema.Models;
using Cinema.Requests;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.Authens
{
    public class AuthenService : IAuthenService
    {
        private readonly CinemaContext _context;

        public AuthenService(CinemaContext context)
        {
            _context = context;
        }

        public async Task<User> Login(LoginRequest request)
        {
            try
            {
                var user = await _context.Users
                    .SingleOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return null;
        }

        public async Task<bool> Register(User user)
        {
            try
            {
                var existed = await _context.Users.SingleOrDefaultAsync(x => x.Email == user.Email);

                if (existed != null)
                {
                    return false;
                }
                user.Role = (int)Role.User;
                _context.Users.Add(user);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return false;
        }
    }
}
