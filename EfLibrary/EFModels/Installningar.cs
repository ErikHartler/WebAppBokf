using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfLibrary.EFModels
{
    public partial class Installningar
    {
        [Display(Name = "Id")]
        public int Id { get; set; }


        [Display(Name = "Bokföringår fr o m")]
        public DateTime? BokforingsarFrom { get; set; }
        [Display(Name = "Bokföringår t o m")]
        public DateTime? BokforingsarTom { get; set; }
        [Display(Name = "Bolagsnamn")]
        public string Bolagsnamn { get; set; }
        [Display(Name = "Organisationsnummer")]
        public string Organisationsnr { get; set; }
        [Display(Name = "Ingående moms-konto")]
#nullable enable
        public string? KontoIngMoms { get; set; }
        [Display(Name = "Utgående moms-konto")]
        public string? KontoUtgMoms { get; set; }
        [Display(Name = "Momsavstämning-konto")]
        public string? KontoMomsAvstamning { get; set; }
        [Display(Name = "Intakter-konto fr o m")]
        public string? KontoIntakterFrom { get; set; }
        [Display(Name = "Intakter-konto t o m")]
        public string? KontoIntakterTom { get; set; }
        [Display(Name = "Intakter-konto kund")]
        public string?   KontoIntakterKund { get; set; }
        [Display(Name = "Fordran-konto fr o m")]
        public string? KontoFordranFrom { get; set; }
        [Display(Name = "Fordran-konto t o m")]
        public string? KontoFordranTom { get; set; }
        [Display(Name = "Fordran-konto kund")]
        public string? KontoFordranKund { get; set; }

        public virtual Konto? KontoFordranFromNavigation { get; set; }
        public virtual Konto? KontoFordranKundNavigation { get; set; }
        public virtual Konto? KontoFordranTomNavigation { get; set; }
        public virtual Konto? KontoIngMomsNavigation { get; set; }
        public virtual Konto? KontoIntakterFromNavigation { get; set; }
        public virtual Konto? KontoIntakterKundNavigation { get; set; }
        public virtual Konto? KontoIntakterTomNavigation { get; set; }
        public virtual Konto? KontoMomsAvstamningNavigation { get; set; }
        public virtual Konto? KontoUtgMomsNavigation { get; set; }
#nullable restore

    }
}
