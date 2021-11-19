using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class Verifikation
    {
        public Verifikation()
        {
            LevFakturas = new HashSet<LevFaktura>();
            Momsperioders = new HashSet<Momsperioder>();
            Transaktions = new HashSet<Transaktion>();
        }

        public int Verifikation1 { get; set; }
        public string? Beskrivning { get; set; }
        public DateTime? Transaktionsdatum { get; set; }
        public decimal? DebetKr { get; set; }
        public decimal? KreditKr { get; set; }
        public DateTime? Bokforingsdatum { get; set; }
        public int? Kundnummer { get; set; }
        public int? Fakturanr { get; set; }

        public virtual Faktura? FakturanrNavigation { get; set; }
        public virtual Kund? KundnummerNavigation { get; set; }
        public virtual ICollection<LevFaktura> LevFakturas { get; set; }
        public virtual ICollection<Momsperioder> Momsperioders { get; set; }
        public virtual ICollection<Transaktion> Transaktions { get; set; }
    }
}
