using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class Transaktion
    {
        public int Id { get; set; }
        public int? Verifikation { get; set; }
        public int? Radnummer { get; set; }
        public decimal? DebetKr { get; set; }
        public string? Konto { get; set; }
        public string? Kostnadsbarare { get; set; }
        public decimal? KreditKr { get; set; }

        public virtual Konto? KontoNavigation { get; set; }
        public virtual Kostnadsbarare? KostnadsbarareNavigation { get; set; }
        public virtual Verifikation? VerifikationNavigation { get; set; }
    }
}
