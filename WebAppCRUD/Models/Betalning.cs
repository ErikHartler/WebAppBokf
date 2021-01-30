using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Betalning
    {
        [Column(TypeName = "datetime")]
        public DateTime? Transdatum { get; set; }
        [Required]
        [StringLength(10)]
        public string Betalsatt { get; set; }
        public int? Gironr { get; set; }
        [Column(TypeName = "money")]
        public decimal? Inbetalning { get; set; }
        [Column(TypeName = "money")]
        public decimal? Utbetalning { get; set; }
        public int Kundnr { get; set; }
        public int? Kundfakturanr { get; set; }
        public int? Leverantorsnr { get; set; }
        public int? Levfakturanr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Registreringsdatum { get; set; }
        [StringLength(10)]
        public string RegistreradAv { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Betalsatt))]
        [InverseProperty("Betalning")]
        public virtual Betalsatt BetalsattNavigation { get; set; }
        [ForeignKey(nameof(Kundfakturanr))]
        [InverseProperty(nameof(Faktura.Betalning))]
        public virtual Faktura KundfakturanrNavigation { get; set; }
        [ForeignKey(nameof(Kundnr))]
        [InverseProperty(nameof(Kund.Betalning))]
        public virtual Kund KundnrNavigation { get; set; }
        [ForeignKey(nameof(Leverantorsnr))]
        [InverseProperty(nameof(Leverantor.Betalning))]
        public virtual Leverantor LeverantorsnrNavigation { get; set; }
        [ForeignKey(nameof(Levfakturanr))]
        [InverseProperty(nameof(LevFaktura.Betalning))]
        public virtual LevFaktura LevfakturanrNavigation { get; set; }
    }
}
