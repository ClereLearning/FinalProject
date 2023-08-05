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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]

        [Display(Name = "Social Name")]
        public string SocialName { get; set; } = string.Empty;

        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;
        public bool Inactive { get; set; } = false;

        
        [Required]
        [Display(Name = "Gender")]
        [NotMapped]
        public virtual Gender Gender { get; set; }

        [ForeignKey("GenderId")]
        [Display(Name = "Gender")]
        public Guid? GenderId { get; set; }


        [Required]
        [Display(Name = "Sexual Orientation")]
        [NotMapped]
        public virtual SexualOrientation SexualOrientation { get; set; }

        [ForeignKey("SexualOrientationId")]
        [Display(Name = "Sexual Orientation")]
        public Guid? SexualOrientationId { get; set; }


        [Display(Name = "Observation")]
        public string Observation { get; set; } = string.Empty;

    }
}
