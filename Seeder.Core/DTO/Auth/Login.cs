using System.ComponentModel.DataAnnotations;

namespace Seeder.Core.DTO.Auth
{
    public class Login
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
