using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISAT.Shared.Models
{
    [Table("Interview")]
    public class Interview
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Place { get; set; } = string.Empty;


        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Start time")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End time")]
        public DateTime EndTime { get; set; }


        [Display(Name = "Interviewee")]
        [ForeignKey("IntervieweeId")]
        public virtual Interviewee? Interviewee { get; set; }


        public Guid? IntervieweeId { get; set; }


        [Display(Name = "Status")]
        [ForeignKey("InterviewStatusId")]
        public virtual InterviewStatus? InterviewStatus { get; set; }

        public int? InterviewStatusId { get; set; }

        [Required]
        public bool Emailed { get; set; } = false;

        public Guid EmailToken { get; set; }

        public byte[]? AudioFile { get; set; }

        public DateTime? AudioDate { get; set; }

        public bool AudioStatus { get; set; } = false;

        public string FileName { get; set; } = string.Empty;

        [Display(Name = "Observation")]
        public string Observation { get; set; } = string.Empty;

        [Display(Name = "Notes")]
        public string Notes { get; set; } = string.Empty;

        [Display(Name = "Interviewer")]
        public Guid? InterviewerId { get; set; }

    }
}
