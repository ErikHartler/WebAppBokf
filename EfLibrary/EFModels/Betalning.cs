using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Betalning
    {
        public int Id { get; set; }
        public DateTime? Transdatum { get; set; }
        public string Betalsatt { get; set; } = null!;
        public int? Gironr { get; set; }
        public decimal? Inbetalning { get; set; }
        public decimal? Utbetalning { get; set; }
        public int Kundnr { get; set; }
        public int? Kundfakturanr { get; set; }
        public int? Leverantorsnr { get; set; }
        public int? Levfakturanr { get; set; }
        public DateTime? Registreringsdatum { get; set; }
        public string? RegistreradAv { get; set; }

        public virtual Betalsatt BetalsattNavigation { get; set; } = null!;
        public virtual Faktura? KundfakturanrNavigation { get; set; }
        public virtual Kund KundnrNavigation { get; set; } = null!;
        public virtual Leverantor? LeverantorsnrNavigation { get; set; }
        public virtual LevFaktura? LevfakturanrNavigation { get; set; }
    }
}
