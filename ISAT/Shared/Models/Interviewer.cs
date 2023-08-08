using System.ComponentModel.DataAnnotations.Schema;

namespace ISAT.Shared.Models
{
        
    public class Interviewer
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string SocialName { get; set; } = string.Empty;
        public Gender? Gender { get; set; }
        public SexualOrientation? SexualOrientation { get; set; }
        public UsersType? UsersType { get; set; }
        public bool Inactive { get; set; } = false;
    }
}
