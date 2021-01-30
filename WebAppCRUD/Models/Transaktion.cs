using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Transaktion
    {
        public int? Verifikation { get; set; }
        public int? Radnummer { get; set; }
        [Column(TypeName = "money")]
        public decimal? DebetKr { get; set; }
        [StringLength(10)]
        public string Konto { get; set; }
        [StringLength(15)]
        public string Kostnadsbarare { get; set; }
        [Column(TypeName = "money")]
        public decimal? KreditKr { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Konto))]
        [InverseProperty("Transaktion")]
        public virtual Konto KontoNavigation { get; set; }
        [ForeignKey(nameof(Kostnadsbarare))]
        [InverseProperty("Transaktion")]
        public virtual Kostnadsbarare KostnadsbarareNavigation { get; set; }
        [ForeignKey(nameof(Verifikation))]
        [InverseProperty("Transaktion")]
        public virtual Verifikation VerifikationNavigation { get; set; }
    }
}
