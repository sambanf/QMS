using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMS.ViewModel
{
    public class QHeadViewModel
    {
        public int q_id { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name ="Code")]
        public string q_code { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string q_name { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Type")]
        public string q_type { get; set; }

        public List<QDetailViewModel> questiondetail { get; set; }
    }
}
