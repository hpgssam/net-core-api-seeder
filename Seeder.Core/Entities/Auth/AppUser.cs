using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Seeder.Core.Entities.Auth
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
