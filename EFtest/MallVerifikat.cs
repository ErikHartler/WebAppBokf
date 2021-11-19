using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class MallVerifikat
    {
        public MallVerifikat()
        {
            MallTransaktioners = new HashSet<MallTransaktioner>();
        }

        public string Kortkod { get; set; } = null!;
        public string? Konto100Proc { get; set; }
        public bool OmDebet100Proc { get; set; }
        public string? Anvands { get; set; }
        public string? Frekvens { get; set; }
        public decimal? Belopp100Proc { get; set; }
        public bool OmKundnrSpec { get; set; }

        public virtual Konto? Konto100ProcNavigation { get; set; }
        public virtual ICollection<MallTransaktioner> MallTransaktioners { get; set; }
    }
}
