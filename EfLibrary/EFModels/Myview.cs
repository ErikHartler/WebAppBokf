using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Myview
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Verifikation")]
        public int Verifikation { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Beskrivning")]
        public string Beskrivning { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Transaktionsdatum")]
        public DateTime? Transaktionsdatum { get; set; }
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
    }
}
