using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BeeWave.Models
{
    public class ApplicationUser : IdentityUser
    {
        public static int nextId = 0;

        [Required]
        public int UserID = nextId++;

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        ApplicationUser() { }

    }
}
