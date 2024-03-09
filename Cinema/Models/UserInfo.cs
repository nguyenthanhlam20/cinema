
namespace Cinema.Models
{
    public class UserInfo
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Fullname { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int RoleNumber { get; set; }      
        public string Email { get; set; } = string.Empty;
    }
}
