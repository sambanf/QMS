namespace QMS.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QDetail")]
    public partial class QDetail
    {
        [Key]
        public int q_id { get; set; }

        public int q_qh_id { get; set; }

        [Required]
        [StringLength(12)]
        public string q_no { get; set; }

        [Required]
        [StringLength(100)]
        public string q_question { get; set; }

        public virtual QHeader QHeader { get; set; }
    }
}
