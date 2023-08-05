using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAT.Shared.Models
{
    [Table("InterviewStatus")]
    public class InterviewStatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]  
        public string Status { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public bool Inactive { get; set; } = false;



    }
}
