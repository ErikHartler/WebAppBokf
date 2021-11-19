using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class LevFaktura
    {
        public LevFaktura()
        {
            Betalnings = new HashSet<Betalning>();
            LevFakturaRads = new HashSet<LevFakturaRad>();
        }

        public int LevFakturanummer { get; set; }
        public DateTime? Fakturadatum { get; set; }
        public DateTime? Forfallodatum { get; set; }
        public DateTime? Utskriftsdatum { get; set; }
        public int? Leverantörsnummer { get; set; }
        public decimal? BeloppExklMoms { get; set; }
        public decimal? MomsKr { get; set; }
        public decimal? BeloppInklMomsKr { get; set; }
        public decimal? BetaltKr { get; set; }
        public DateTime? Betaldatum { get; set; }
        public string? VarReferens { get; set; }
        public string? ErRefForN { get; set; }
        public string? Kommentar { get; set; }
        public string? ErRefEfterN { get; set; }
        public string? Villkor { get; set; }
        public double? Momssats { get; set; }
        public int? VerNr { get; set; }
        public bool Godkann { get; set; }

        public virtual Verifikation? VerNrNavigation { get; set; }
        public virtual ICollection<Betalning> Betalnings { get; set; }
        public virtual ICollection<LevFakturaRad> LevFakturaRads { get; set; }
    }
}
