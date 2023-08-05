using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAT.Shared.Models
{
    [Table("DaysOff")]
    public class DaysOff
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]           
        [Display(Name = "Interviewer")]
        public string InterviewerId { get; set; }

        [Required]
        [Display(Name = "Starts")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Ends")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        public Boolean Inactive { get; set; } = false;

        public DateTime InactiveDate { get; set; }


    }
}
