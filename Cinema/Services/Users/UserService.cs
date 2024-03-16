using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.Users
{
    public class UserService : IUserService
    {
        private readonly CinemaContext _context;

        public UserService(CinemaContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalUsers()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                return users.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return 0;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return null;
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                var existed = await _context.Users.SingleOrDefaultAsync(x => x.Email == user.Email);
                if (existed != null)
                {
                    existed.Address = user.Address;
                    existed.Dob = user.Dob;
                    existed.Fullname = user.Fullname;
                    existed.Gender = user.Gender;
                    existed.Phone = user.Phone;
                    _context.Users.Update(existed);

                    if(await _context.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return false;
        }

        public async Task<bool> ChangePassword(string email, string newPassword)
        {
            try
            {
                var existed = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
                if (existed != null)
                {
                    existed.Password = newPassword;
                 
                    _context.Users.Update(existed);

                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
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
