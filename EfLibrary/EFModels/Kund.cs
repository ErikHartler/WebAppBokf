using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Kund")]
    public partial class Kund
    {
        public Kund()
        {
            Betalnings = new HashSet<Betalning>();
            Fakturas = new HashSet<Faktura>();
            KontaktpersonKunds = new HashSet<KontaktpersonKund>();
            Verifikations = new HashSet<Verifikation>();
        }

        [Key]
        public int Kundnummer { get; set; }
        [StringLength(50)]
        public string Kundnamn { get; set; }
        [StringLength(50)]
        public string Box { get; set; }
        [StringLength(20)]
        public string Postnummer { get; set; }
        [StringLength(50)]
        public string Ort { get; set; }
        [Column("Kont Pers Fornamn")]
        [StringLength(30)]
        public string KontPersFornamn { get; set; }
        [Column("Kont PersEfternamn")]
        [StringLength(30)]
        public string KontPersEfternamn { get; set; }
        public int? Forfallodagar { get; set; }
        [StringLength(255)]
        public string Telefon { get; set; }
        [StringLength(255)]
        public string Telefax { get; set; }
        [StringLength(255)]
        public string Kommentar { get; set; }
        [StringLength(255)]
        public string Villkor { get; set; }
        [Column("IBKredit", TypeName = "money")]
        public decimal? Ibkredit { get; set; }

        [InverseProperty(nameof(Betalning.KundnrNavigation))]
        public virtual ICollection<Betalning> Betalnings { get; set; }
        [InverseProperty(nameof(Faktura.KundnummerNavigation))]
        public virtual ICollection<Faktura> Fakturas { get; set; }
        [InverseProperty(nameof(KontaktpersonKund.KundnummerNavigation))]
        public virtual ICollection<KontaktpersonKund> KontaktpersonKunds { get; set; }
        [InverseProperty(nameof(Verifikation.KundnummerNavigation))]
        public virtual ICollection<Verifikation> Verifikations { get; set; }
    }
}
