using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class MallTransaktioner
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kortkod")]
        public string Kortkod { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.Display(Name = "Radnummer")]
        public int? Radnr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Debet procent")]
        public decimal? DebetProc { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kredit procent")]
        public decimal? KreditProc { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Konto")]
        public string Konto { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kostnadsbärare")]
#nullable enable
        public string? Kostnadsbarare { get; set; }
#nullable restore
        public virtual Konto KontoNavigation { get; set; }
        public virtual MallVerifikat KortkodNavigation { get; set; } = null!;
#nullable enable
        public virtual Kostnadsbarare? KostnadsbarareNavigation { get; set; }
#nullable restore
    }
}
