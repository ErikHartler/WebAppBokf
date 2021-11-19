using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class MallTransaktioner
    {
        public int Id { get; set; }
        public string Kortkod { get; set; } = null!;
        public int? Radnr { get; set; }
        public decimal? DebetProc { get; set; }
        public decimal? KreditProc { get; set; }
        public string? Konto { get; set; }
        public string? Kostnadsbarare { get; set; }

        public virtual Konto? KontoNavigation { get; set; }
        public virtual MallVerifikat KortkodNavigation { get; set; } = null!;
        public virtual Kostnadsbarare? KostnadsbarareNavigation { get; set; }
    }
}
