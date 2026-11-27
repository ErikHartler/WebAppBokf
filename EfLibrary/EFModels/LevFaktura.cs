using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class LevFaktura
    {
        public LevFaktura()
        {
            Betalnings = new HashSet<Betalning>();
            LevFakturaRads = new HashSet<LevFakturaRad>();
        }

        [System.ComponentModel.DataAnnotations.Display(Name = "Leverantörsfakturanummer")]
        public int LevFakturanummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Fakturadatum")]
        public DateTime? Fakturadatum { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Förfallodatum")]
        public DateTime? Forfallodatum { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Utskriftsdatum")]
        public DateTime? Utskriftsdatum { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Leverantörsnummer")]
        public int? Leverantörsnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Belopp exkl. moms")]
        public decimal? BeloppExklMoms { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Moms kr")]
        public decimal? MomsKr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Belopp inkl. moms kr")]
        public decimal? BeloppInklMomsKr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Betalt kr")]
        public decimal? BetaltKr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Betaldatum")]
        public DateTime? Betaldatum { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Vår referens")]

#nullable enable
        public string? VarReferens { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Er referens före namn")]
        public string? ErRefForN { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kommentar")]
        public string? Kommentar { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Er referens efter namn")]
        public string? ErRefEfterN { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Villkor")]
        public string? Villkor { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Momssats")]
        public double? Momssats { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Verifikationsnummer")]
        public int? VerNr { get; set; }
#nullable restore
        [System.ComponentModel.DataAnnotations.Display(Name = "Godkänd?")]
        public bool Godkann { get; set; }

#nullable enable
        public virtual Verifikation? VerNrNavigation { get; set; }
#nullable restore
        public virtual ICollection<Betalning> Betalnings { get; set; }
        public virtual ICollection<LevFakturaRad> LevFakturaRads { get; set; }
    }
}
