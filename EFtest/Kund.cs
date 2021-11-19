using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class Kund
    {
        public Kund()
        {
            Betalnings = new HashSet<Betalning>();
            Fakturas = new HashSet<Faktura>();
            KontaktpersonKunds = new HashSet<KontaktpersonKund>();
            Projekts = new HashSet<Projekt>();
            Verifikations = new HashSet<Verifikation>();
        }

        public int Kundnummer { get; set; }
        public string? Kundnamn { get; set; }
        public string? Box { get; set; }
        public string? Postnummer { get; set; }
        public string? Ort { get; set; }
        public string? KontPersFornamn { get; set; }
        public string? KontPersEfternamn { get; set; }
        public int? Forfallodagar { get; set; }
        public string? Telefon { get; set; }
        public string? Telefax { get; set; }
        public string? Kommentar { get; set; }
        public string? Villkor { get; set; }
        public decimal? Ibkredit { get; set; }
        public string? Landskod { get; set; }

        public virtual Landskod? LandskodNavigation { get; set; }
        public virtual ICollection<Betalning> Betalnings { get; set; }
        public virtual ICollection<Faktura> Fakturas { get; set; }
        public virtual ICollection<KontaktpersonKund> KontaktpersonKunds { get; set; }
        public virtual ICollection<Projekt> Projekts { get; set; }
        public virtual ICollection<Verifikation> Verifikations { get; set; }
    }
}
