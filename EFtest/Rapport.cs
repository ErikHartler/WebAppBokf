using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class Rapport
    {
        public Rapport()
        {
            RapportRads = new HashSet<RapportRad>();
        }

        public string Rapport1 { get; set; } = null!;
        public string? Benamning { get; set; }
        public bool OmTeckenvandning { get; set; }
        public bool OmKol2Ib { get; set; }
        public string? Kommentar { get; set; }

        public virtual ICollection<RapportRad> RapportRads { get; set; }
    }
}
