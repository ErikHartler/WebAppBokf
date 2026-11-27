using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Produkt
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Produkt/tjänst")]
        public string ProduktTjanst { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.Display(Name = "Beskrivning")]
        public string Beskrivning { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Enhet")]
        public string Enhet { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.Display(Name = "Enhetspris")]
        public decimal Enhetspris { get; set; }

        public virtual Enhet EnhetNavigation { get; set; } = null!;
    }
}
