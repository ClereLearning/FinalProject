using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ISAT.Shared.Models
{
    [Table("Interview")]
    public class Interview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        [Required]
        public int Id { get; set; }

        [Required]
        public string Place { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime Hour { get; set; }

        [Required]
        public Interviewee Interviewee { get; set; }

        [Required]
        public InterviewStatus InterviewStatus { get; set; }

        [Required]
        public bool Emailed { get; set; } = false;

        public Guid EmailToken { get; set; }

        public byte[]? AudioFile { get; set; }

        public DateTime AudioDate { get; set; }

        public bool AudioStatus { get; set; } = false;

        public string FileName { get; set; } = string.Empty;

    }
}
