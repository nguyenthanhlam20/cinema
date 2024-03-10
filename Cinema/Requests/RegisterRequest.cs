using System.ComponentModel.DataAnnotations;

namespace Cinema.Requests
{
    public class RegisterRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]

        public string Password { get; set; }
        [Required]

        public string ConfirmPassword { get; set; }
        [Required]

        public string Phone { get; set; }
        [Required]

        public string Fullname { get; set; }
        [Required]

        public string Address { get; set; }
        public bool Gender { get; set; }
        public DateTime Dob { get; set; }

    }
}
