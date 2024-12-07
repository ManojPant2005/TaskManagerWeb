using System.ComponentModel.DataAnnotations;

namespace TM.Shared.DTOs
{
    public class RegisterDto
    {
        [Required, MaxLength(20)]
        public string Name { get; set; }

        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, StringLength(15, MinimumLength = 10)]
        public string Phone { get; set; }

        [Required, MaxLength(250)]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; } // Added Role property
    }
}
