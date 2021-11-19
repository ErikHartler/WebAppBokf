using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
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
