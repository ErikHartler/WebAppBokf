using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class LevFakturaRad
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Leverantörsfakturanummer")]
        public int? LevFakturanummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Radnummer")]
        public int? Radnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Produkt/tjänst")]
        public string ProduktTjanst { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Enhetspris")]
        public decimal Enhetspris { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Enhet")]
        public string Enhet { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Summa kr")]
        public decimal SummaKr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Antal")]
        public int Antal { get; set; }

        public virtual Enhet EnhetNavigation { get; set; }
        public virtual LevFaktura LevFakturanummerNavigation { get; set; }
    }
}
