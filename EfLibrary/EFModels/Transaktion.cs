using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Transaktion
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Verifikation")]
        public int? Verifikation { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Radnummer")]
        public int Radnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Debet kr")]

        public string Konto { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kostnadsbärare")]

#nullable enable
        public decimal? DebetKr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Konto")]
       
        public string? Kostnadsbarare { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kredit kr")]
        public decimal? KreditKr { get; set; }
#nullable restore
        public virtual Konto KontoNavigation { get; set; }

#nullable enable
        public virtual Kostnadsbarare? KostnadsbarareNavigation { get; set; }
#nullable restore
        public virtual Verifikation VerifikationNavigation { get; set; }
    }
}
