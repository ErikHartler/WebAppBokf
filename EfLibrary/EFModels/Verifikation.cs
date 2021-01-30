using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Verifikation")]
    public partial class Verifikation
    {
        public Verifikation()
        {
            LevFakturas = new HashSet<LevFaktura>();
            Momsperioders = new HashSet<Momsperioder>();
            Transaktions = new HashSet<Transaktion>();
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
        [InverseProperty(nameof(Faktura.Verifikations))]
        public virtual Faktura FakturanrNavigation { get; set; }
        [ForeignKey(nameof(Kundnummer))]
        [InverseProperty(nameof(Kund.Verifikations))]
        public virtual Kund KundnummerNavigation { get; set; }
        [InverseProperty(nameof(LevFaktura.VerNrNavigation))]
        public virtual ICollection<LevFaktura> LevFakturas { get; set; }
        [InverseProperty(nameof(Momsperioder.VerifikationsnrNavigation))]
        public virtual ICollection<Momsperioder> Momsperioders { get; set; }
        [InverseProperty(nameof(Transaktion.VerifikationNavigation))]
        public virtual ICollection<Transaktion> Transaktions { get; set; }
    }
}
