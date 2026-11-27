using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Verifikation
    {
        public Verifikation()
        {
            LevFakturas = new HashSet<LevFaktura>();
            Momsperioders = new HashSet<Momsperioder>();
            Transaktions = new HashSet<Transaktion>();
        }

        [System.ComponentModel.DataAnnotations.Display(Name = "Verifikationsnummer")]
        public int Verifikation1 { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Beskrivning")]
        public string Beskrivning { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Transaktionsdatum")]

        public DateTime  Transaktionsdatum { get; set; }


#nullable enable
        [System.ComponentModel.DataAnnotations.Display(Name = "Debet kr")]
        public decimal? DebetKr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kredit kr")]

        public decimal? KreditKr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Bokföringsdatum")]
        public DateTime? Bokforingsdatum { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kundnummer")]
        public int? Kundnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Fakturanummer")]
        public int? Fakturanr { get; set; }

        

        public virtual Faktura? FakturanrNavigation { get; set; }
        public virtual Kund? KundnummerNavigation { get; set; }

#nullable enable
        public virtual ICollection<LevFaktura> LevFakturas { get; set; }
        public virtual ICollection<Momsperioder> Momsperioders { get; set; }
        public virtual ICollection<Transaktion> Transaktions { get; set; }
    }
}
