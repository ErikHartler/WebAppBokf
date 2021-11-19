using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Fakturarad
    {
        public int Id { get; set; }
        public int? Fakturanummer { get; set; }
        public int? Radnummer { get; set; }
        public string? ProduktTjanst { get; set; }
        public decimal? Enhetspris { get; set; }
        public string? Enhet { get; set; }
        public decimal? SummaKr { get; set; }
        public double? Antal { get; set; }

        public virtual Enhet? EnhetNavigation { get; set; }
        public virtual Faktura? FakturanummerNavigation { get; set; }
    }
}
