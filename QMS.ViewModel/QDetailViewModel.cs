using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMS.ViewModel
{
    public class QDetailViewModel
    {
        [Key]
        
        public int q_id { get; set; }

        public int q_qh_id { get; set; }

        [Required]
        [StringLength(12)]
        [Display(Name="No ")]
        public string q_no { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Question")]
        public string q_question { get; set; }
    }
}
