using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Betalning
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Transdatum")]
        public DateTime? Transdatum { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Betalsätt")]
        public string Betalsatt { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.Display(Name = "Gironummer")]
        public int? Gironr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Inbetalning")]
        public decimal? Inbetalning { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Utbetalning")]
        public decimal? Utbetalning { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kundnummer")]
        public int Kundnr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kundfakturanummer")]
        public int? Kundfakturanr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Leverantörsnummer")]
        public int? Leverantorsnr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Leverantörsfakturanummer")]
        public int? Levfakturanr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Registreringsdatum")]
        public DateTime? Registreringsdatum { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Registrerad av")]
        public string RegistreradAv { get; set; }

        public virtual Betalsatt BetalsattNavigation { get; set; } = null!;
        public virtual Kund KundnrNavigation { get; set; } = null!;
        public virtual Leverantor LeverantorsnrNavigation { get; set; }
#nullable enable
        public virtual Faktura?   KundfakturanrNavigation { get; set; }
        
        public virtual LevFaktura? LevfakturanrNavigation { get; set; }
#nullable enable
    }
}
