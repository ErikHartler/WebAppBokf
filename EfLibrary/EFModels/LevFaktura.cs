using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("LevFaktura")]
    public partial class LevFaktura
    {
        public LevFaktura()
        {
            LevFakturaRads = new HashSet<LevFakturaRad>();
        }

        [Key]
        public int LevFakturanummer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Fakturadatum { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Forfallodatum { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Utskriftsdatum { get; set; }
        public int? Leverantörsnummer { get; set; }
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
        public int? VerNr { get; set; }
        public bool Godkann { get; set; }

        [ForeignKey(nameof(VerNr))]
        [InverseProperty(nameof(Verifikation.LevFakturas))]
        public virtual Verifikation VerNrNavigation { get; set; }
        [InverseProperty(nameof(LevFakturaRad.LevFakturanummerNavigation))]
        public virtual ICollection<LevFakturaRad> LevFakturaRads { get; set; }
    }
}
