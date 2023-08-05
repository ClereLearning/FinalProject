using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAT.Shared.Models
{
    [Table("Availability")]
    public class Availability
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Start time")]
        public TimeOnly StartTime { get; set; }

        [Required]
        [Display(Name = "End time")]
        public TimeOnly EndTime { get; set; }

        [Required]
        [Display(Name = "Day of Week")]
        public DayWeek DayWeek { get; set; }

        [Required]
        [Display(Name = "Interviewer")]
        public string InterviewerId { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        public DateTime RegisterDate { get; set; }
        
        public Boolean Inactive { get; set; } = false;

        public DateTime InactiveDate { get; set; }        

    }
}
