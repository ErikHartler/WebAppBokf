using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class Myview
    {
        public int Verifikation { get; set; }
        public string? Beskrivning { get; set; }
        public DateTime? Transaktionsdatum { get; set; }
        public decimal? DebetKr { get; set; }
        public decimal? KreditKr { get; set; }
        public DateTime? Bokforingsdatum { get; set; }
        public int? Kundnummer { get; set; }
        public int? Fakturanr { get; set; }
    }
}
