using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISAT.Shared.Models
{
    [Table("Interviewee")]
    public class Interviewee
    {
        [Key]               
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string SocialName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;               
        public string PhoneNumber { get; set; } = string.Empty;
        public Gender? Gender { get; set; }
        public SexualOrientation? SexualOrientation { get; set; }
        public bool Inactive { get; set; } = false;
    }
}
