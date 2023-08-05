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
    [Table ("Gender")]
    public class Gender
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Gender Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Gender Description")]
        public string Description { get; set; } = string.Empty;

    }
}
