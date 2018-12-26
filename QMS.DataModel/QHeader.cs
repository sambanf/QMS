namespace QMS.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QHeader")]
    public partial class QHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QHeader()
        {
            QDetails = new HashSet<QDetail>();
        }

        [Key]
        public int q_id { get; set; }

        [Required]
        [StringLength(10)]
        public string q_code { get; set; }

        [Required]
        [StringLength(50)]
        public string q_name { get; set; }

        [Required]
        [StringLength(20)]
        public string q_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QDetail> QDetails { get; set; }
    }
}
