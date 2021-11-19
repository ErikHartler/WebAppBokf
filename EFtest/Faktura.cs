using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class Faktura
    {
        public Faktura()
        {
            Betalnings = new HashSet<Betalning>();
            Fakturarads = new HashSet<Fakturarad>();
            Verifikations = new HashSet<Verifikation>();
        }

        public int Fakturanummer { get; set; }
        public DateTime? Fakturadatum { get; set; }
        public DateTime? Forfallodatum { get; set; }
        public DateTime? Utskriftsdatum { get; set; }
        public int? Kundnummer { get; set; }
        public string? Kundnamn { get; set; }
        public string? Box { get; set; }
        public string? Postnummer { get; set; }
        public string? Ort { get; set; }
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
        public double? VerNr { get; set; }
        public string? Paminnelse1 { get; set; }
        public string? Paminnelse2 { get; set; }
        public string? Inkasso { get; set; }
        public decimal? UtestaendeFordr { get; set; }
        public string? Coadress { get; set; }
        public string? Land { get; set; }
        public bool Godkann { get; set; }
        public string? Projekt { get; set; }
        public int? ProjektId { get; set; }

        public virtual Kund? KundnummerNavigation { get; set; }
        public virtual Landskod? LandNavigation { get; set; }
        public virtual Projekt? ProjektNavigation { get; set; }
        public virtual ICollection<Betalning> Betalnings { get; set; }
        public virtual ICollection<Fakturarad> Fakturarads { get; set; }
        public virtual ICollection<Verifikation> Verifikations { get; set; }
    }
}
