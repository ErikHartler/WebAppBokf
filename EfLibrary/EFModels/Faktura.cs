using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfLibrary.EFModels
{
    public partial class Faktura
    {
        public Faktura()
        {
            Betalnings = new HashSet<Betalning>();
            Fakturarads = new HashSet<Fakturarad>();
            Verifikations = new HashSet<Verifikation>();
        }
        [Display(Name = "Fakturanummer")]
        public int Fakturanummer { get; set; }
        [Display(Name = "Fakturadatum")]
        public DateTime? Fakturadatum { get; set; }
        [Display(Name = "Förfallodatum")]
        public DateTime? Forfallodatum { get; set; }
        [Display(Name = "Utskriftsdatum")]
        public DateTime? Utskriftsdatum { get; set; }
        [Display(Name = "Kundnummer")]
        public int? Kundnummer { get; set; }
        [Display(Name = "Kundnamn")]
        public string Kundnamn { get; set; }
        [Display(Name = "Box")]
        public string Box { get; set; }
        [Display(Name = "Postnummer")]
        public string Postnummer { get; set; }
        [Display(Name = "Ort")]
        public string Ort { get; set; }
        [Display(Name = "Belopp exkl. moms")]
        public decimal? BeloppExklMoms { get; set; }
        [Display(Name = "Moms kr")]
        public decimal? MomsKr { get; set; }
        [Display(Name = "Belopp inkl. moms kr")]
        public decimal? BeloppInklMomsKr { get; set; }
        [Display(Name = "Betalt kr")]
        public decimal? BetaltKr { get; set; }
        [Display(Name = "Betaldatum")]
        public DateTime? Betaldatum { get; set; }
        [Display(Name = "Vår referens")]
        public string    VarReferens { get; set; }
        [Display(Name = "Er referens före namn")]
        public string    ErRefForN { get; set; }
        [Display(Name = "Kommentar")]
        public string Kommentar { get; set; }
        [Display(Name = "Er referens efter namn")]
        public string ErRefEfterN { get; set; }
        [Display(Name = "Villkor")]
        public string Villkor { get; set; }
        [Display(Name = "Momssats")]
        public double? Momssats { get; set; }
        [Display(Name = "Verifikationsnummer")]
        public double? VerNr { get; set; }
        [Display(Name = "Påminnelse 1")]
        public string Paminnelse1 { get; set; }
        [Display(Name = "Påminnelse 2")]
        public string Paminnelse2 { get; set; }
        [Display(Name = "Inkasso")]
        public string Inkasso { get; set; }
        [Display(Name = "Utestående fordran")]
        public decimal? UtestaendeFordr { get; set; }
        [Display(Name = "C/o-adress")]
        public string Coadress { get; set; }
        [Display(Name = "Land")]
        public string Land { get; set; }
        [Display(Name = "Godkänd")]
        public bool Godkann { get; set; }

        [Display(Name = "Projekt")]
        public string Projekt { get; set; }
        [Display(Name = "Projekt-id")]
        public int? ProjektId { get; set; }

#nullable enable
        public virtual Kund? KundnummerNavigation { get; set; }
#nullable restore
        public virtual Landskod LandNavigation { get; set; }
#nullable enable
        public virtual Projekt? ProjektNavigation { get; set; }
#nullable restore
        public virtual ICollection<Betalning> Betalnings { get; set; }
        public virtual ICollection<Fakturarad> Fakturarads { get; set; }
        public virtual ICollection<Verifikation> Verifikations { get; set; }
    }
}
