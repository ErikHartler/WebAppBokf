using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class Produkt
    {
        public string ProduktTjanst { get; set; } = null!;
        public string? Beskrivning { get; set; }
        public string Enhet { get; set; } = null!;
        public decimal? Enhetspris { get; set; }

        public virtual Enhet EnhetNavigation { get; set; } = null!;
    }
}
