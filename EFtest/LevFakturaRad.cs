using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class LevFakturaRad
    {
        public int Id { get; set; }
        public int? LevFakturanummer { get; set; }
        public int? Radnummer { get; set; }
        public string? ProduktTjanst { get; set; }
        public decimal? Enhetspris { get; set; }
        public string? Enhet { get; set; }
        public decimal? SummaKr { get; set; }
        public int? Antal { get; set; }

        public virtual Enhet? EnhetNavigation { get; set; }
        public virtual LevFaktura? LevFakturanummerNavigation { get; set; }
    }
}
