using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Faktura")]
    public partial class Faktura
    {
        public Faktura()
        {
            Betalnings = new HashSet<Betalning>();
            Fakturarads = new HashSet<Fakturarad>();
            Verifikations = new HashSet<Verifikation>();
        }

        [Key]
        public int Fakturanummer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Fakturadatum { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Forfallodatum { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Utskriftsdatum { get; set; }
        public int? Kundnummer { get; set; }
        [StringLength(50)]
        public string Kundnamn { get; set; }
        [StringLength(50)]
        public string Box { get; set; }
        [StringLength(20)]
        public string Postnummer { get; set; }
        [StringLength(50)]
        public string Ort { get; set; }
        [Column("Belopp Exkl moms", TypeName = "money")]
        public decimal? BeloppExklMoms { get; set; }
        [Column("Moms Kr", TypeName = "money")]
        public decimal? MomsKr { get; set; }
        [Column("Belopp Inkl Moms Kr", TypeName = "money")]
        public decimal? BeloppInklMomsKr { get; set; }
        [Column("Betalt Kr", TypeName = "money")]
        public decimal? BetaltKr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Betaldatum { get; set; }
        [StringLength(255)]
        public string VarReferens { get; set; }
        [StringLength(255)]
        public string ErRefForN { get; set; }
        [StringLength(255)]
        public string Kommentar { get; set; }
        [StringLength(255)]
        public string ErRefEfterN { get; set; }
        [StringLength(255)]
        public string Villkor { get; set; }
        public double? Momssats { get; set; }
        public double? VerNr { get; set; }
        [StringLength(255)]
        public string Paminnelse1 { get; set; }
        [StringLength(255)]
        public string Paminnelse2 { get; set; }
        [StringLength(255)]
        public string Inkasso { get; set; }
        [Column(TypeName = "money")]
        public decimal? UtestaendeFordr { get; set; }
        [Column("COAdress")]
        [StringLength(255)]
        public string Coadress { get; set; }
        [StringLength(255)]
        public string Land { get; set; }
        public bool Godkann { get; set; }
        [StringLength(5)]
        public string Projekt { get; set; }

        [ForeignKey(nameof(Kundnummer))]
        [InverseProperty(nameof(Kund.Fakturas))]
        public virtual Kund KundnummerNavigation { get; set; }
        [InverseProperty(nameof(Betalning.KundfakturanrNavigation))]
        public virtual ICollection<Betalning> Betalnings { get; set; }
        [InverseProperty(nameof(Fakturarad.FakturanummerNavigation))]
        public virtual ICollection<Fakturarad> Fakturarads { get; set; }
        [InverseProperty(nameof(Verifikation.FakturanrNavigation))]
        public virtual ICollection<Verifikation> Verifikations { get; set; }
    }
}
