using Microsoft.AspNetCore.Identity;

namespace Api1.Models
{
    public class AppUser : IdentityUser
    {
        public string FullNamw { get; set; } = null!;
    }
}
