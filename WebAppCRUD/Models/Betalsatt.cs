using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Betalsatt
    {
        public Betalsatt()
        {
            Betalning = new HashSet<Betalning>();
        }

        [Key]
        [Column("Betalsatt")]
        [StringLength(10)]
        public string Betalsatt1 { get; set; }
        [StringLength(50)]
        public string Beskrivning { get; set; }

        [InverseProperty("BetalsattNavigation")]
        public virtual ICollection<Betalning> Betalning { get; set; }
    }
}
