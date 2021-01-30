using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class MallTransaktioner
    {
        [Required]
        [StringLength(15)]
        public string Kortkod { get; set; }
        public int? Radnr { get; set; }
        [Column(TypeName = "money")]
        public decimal? DebetProc { get; set; }
        [Column(TypeName = "money")]
        public decimal? KreditProc { get; set; }
        [StringLength(10)]
        public string Konto { get; set; }
        [StringLength(15)]
        public string Kostnadsbarare { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Konto))]
        [InverseProperty("MallTransaktioner")]
        public virtual Konto KontoNavigation { get; set; }
        [ForeignKey(nameof(Kortkod))]
        [InverseProperty(nameof(MallVerifikat.MallTransaktioner))]
        public virtual MallVerifikat KortkodNavigation { get; set; }
        [ForeignKey(nameof(Kostnadsbarare))]
        [InverseProperty("MallTransaktioner")]
        public virtual Kostnadsbarare KostnadsbarareNavigation { get; set; }
    }
}
