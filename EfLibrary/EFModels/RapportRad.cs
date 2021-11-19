using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class RapportRad
    {
        public int Id { get; set; }
        public string Rapport { get; set; } = null!;
        public double? Radnr { get; set; }
        public string? KontoFrom { get; set; }
        public string? KontoTom { get; set; }
        public string? RadFromTom { get; set; }
        public string? Radbenamning { get; set; }
        public bool OmAdderaIb { get; set; }

        public virtual Rapport RapportNavigation { get; set; } = null!;
    }
}
