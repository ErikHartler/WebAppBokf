using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class MallVerifikat
    {
        public MallVerifikat()
        {
            MallTransaktioner = new HashSet<MallTransaktioner>();
        }

        [Key]
        [StringLength(15)]
        public string Kortkod { get; set; }
        [StringLength(10)]
        public string Konto100Proc { get; set; }
        public bool OmDebet100Proc { get; set; }
        [StringLength(255)]
        public string Anvands { get; set; }
        [StringLength(255)]
        public string Frekvens { get; set; }
        [Column(TypeName = "money")]
        public decimal? Belopp100Proc { get; set; }
        public bool OmKundnrSpec { get; set; }

        [ForeignKey(nameof(Konto100Proc))]
        [InverseProperty(nameof(Konto.MallVerifikat))]
        public virtual Konto Konto100ProcNavigation { get; set; }
        [InverseProperty("KortkodNavigation")]
        public virtual ICollection<MallTransaktioner> MallTransaktioner { get; set; }
    }
}
