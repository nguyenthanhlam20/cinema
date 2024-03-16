
namespace Cinema.Models
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Fullname { get; set; } = string.Empty;
        public int Role { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
