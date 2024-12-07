using System.ComponentModel.DataAnnotations;

namespace TM.Shared.DTOs
{
    public class LoginDto
    {
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required]  
        public string Password { get; set; }
    }
}
