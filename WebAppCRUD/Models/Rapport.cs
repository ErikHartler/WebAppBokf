using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Rapport
    {
        public Rapport()
        {
            RapportRad = new HashSet<RapportRad>();
        }

        [Key]
        [Column("Rapport")]
        [StringLength(10)]
        public string Rapport1 { get; set; }
        [StringLength(255)]
        public string Benamning { get; set; }
        public bool OmTeckenvandning { get; set; }
        [Column("OmKol2IB")]
        public bool OmKol2Ib { get; set; }
        [StringLength(255)]
        public string Kommentar { get; set; }

        [InverseProperty("RapportNavigation")]
        public virtual ICollection<RapportRad> RapportRad { get; set; }
    }
}
