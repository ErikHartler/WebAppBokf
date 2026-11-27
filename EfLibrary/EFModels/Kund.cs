using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
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

        [System.ComponentModel.DataAnnotations.Display(Name = "Kundnummer")]
        public int Kundnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kundnamn")]
        public string Kundnamn { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Box")]
#nullable enable
        public string? Box { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Postnummer")]
        public string? Postnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Ort")]
        public string? Ort { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kontaktperson förnamn")]
        public string? KontPersFornamn { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kontaktperson efternamn")]
        public string? KontPersEfternamn { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Förfallodagar")]
        public int? Forfallodagar { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Telefon")]
        public string? Telefon { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Telefax")]
        public string? Telefax { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kommentar")]
        public string? Kommentar { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Villkor")]
        public string? Villkor { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Ingående kredit")]
        public decimal? Ibkredit { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Landskod")]
        public string? Landskod { get; set; }

        public virtual Landskod? LandskodNavigation { get; set; }

#nullable restore
        public virtual ICollection<Betalning> Betalnings { get; set; }
        public virtual ICollection<Faktura> Fakturas { get; set; }
        public virtual ICollection<KontaktpersonKund> KontaktpersonKunds { get; set; }
        public virtual ICollection<Projekt> Projekts { get; set; }
        public virtual ICollection<Verifikation> Verifikations { get; set; }
    }
}
