using ISAT.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace ISAT.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string SocialName { get; set; } = string.Empty;
        public Gender? Gender { get; set; }
        public SexualOrientation? SexualOrientation { get; set; }
        public UsersType? UsersType { get; set; }
        public bool Inactive { get; set; } = false;
    }
}