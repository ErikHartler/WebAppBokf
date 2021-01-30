using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Kostnadsbarare
    {
        public Kostnadsbarare()
        {
            MallTransaktioner = new HashSet<MallTransaktioner>();
            Transaktion = new HashSet<Transaktion>();
        }

        [Key]
        [Column("Kostnadsbarare")]
        [StringLength(15)]
        public string Kostnadsbarare1 { get; set; }
        [StringLength(50)]
        public string Beskrivning { get; set; }

        [InverseProperty("KostnadsbarareNavigation")]
        public virtual ICollection<MallTransaktioner> MallTransaktioner { get; set; }
        [InverseProperty("KostnadsbarareNavigation")]
        public virtual ICollection<Transaktion> Transaktion { get; set; }
    }
}
