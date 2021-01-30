using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Verifikation
    {
        public Verifikation()
        {
            LevFaktura = new HashSet<LevFaktura>();
            Momsperioder = new HashSet<Momsperioder>();
            Transaktion = new HashSet<Transaktion>();
        }

        [Key]
        [Column("Verifikation")]
        public int Verifikation1 { get; set; }
        [StringLength(200)]
        public string Beskrivning { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Transaktionsdatum { get; set; }
        [Column(TypeName = "money")]
        public decimal? DebetKr { get; set; }
        [Column(TypeName = "money")]
        public decimal? KreditKr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Bokforingsdatum { get; set; }
        public int? Kundnummer { get; set; }
        public int? Fakturanr { get; set; }

        [ForeignKey(nameof(Fakturanr))]
        [InverseProperty(nameof(Faktura.Verifikation))]
        public virtual Faktura FakturanrNavigation { get; set; }
        [ForeignKey(nameof(Kundnummer))]
        [InverseProperty(nameof(Kund.Verifikation))]
        public virtual Kund KundnummerNavigation { get; set; }
        [InverseProperty("VerNrNavigation")]
        public virtual ICollection<LevFaktura> LevFaktura { get; set; }
        [InverseProperty("VerifikationsnrNavigation")]
        public virtual ICollection<Momsperioder> Momsperioder { get; set; }
        [InverseProperty("VerifikationNavigation")]
        public virtual ICollection<Transaktion> Transaktion { get; set; }
    }
}
