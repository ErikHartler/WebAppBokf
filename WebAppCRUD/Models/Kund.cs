using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Kund
    {
        public Kund()
        {
            Betalning = new HashSet<Betalning>();
            Faktura = new HashSet<Faktura>();
            KontaktpersonKund = new HashSet<KontaktpersonKund>();
            Projekt = new HashSet<Projekt>();
            Verifikation = new HashSet<Verifikation>();
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
        [StringLength(5)]
        public string Landskod { get; set; }

        [ForeignKey(nameof(Landskod))]
        [InverseProperty("Kund")]
        public virtual Landskod LandskodNavigation { get; set; }
        [InverseProperty("KundnrNavigation")]
        public virtual ICollection<Betalning> Betalning { get; set; }
        [InverseProperty("KundnummerNavigation")]
        public virtual ICollection<Faktura> Faktura { get; set; }
        [InverseProperty("KundnummerNavigation")]
        public virtual ICollection<KontaktpersonKund> KontaktpersonKund { get; set; }
        [InverseProperty("KundnrNavigation")]
        public virtual ICollection<Projekt> Projekt { get; set; }
        [InverseProperty("KundnummerNavigation")]
        public virtual ICollection<Verifikation> Verifikation { get; set; }
    }
}
