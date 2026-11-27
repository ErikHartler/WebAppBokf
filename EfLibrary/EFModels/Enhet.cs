using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EfLibrary.EFModels
{
    public partial class Enhet
    {
        public Enhet()
        {
            Fakturarads = new HashSet<Fakturarad>();
            LevFakturaRads = new HashSet<LevFakturaRad>();
            Produkts = new HashSet<Produkt>();
        }

        [Display(Name = "Kod")]
        public string Kod { get; set; } = null!;
        [Display(Name = "Beskrivning")]
        public string Beskrivning { get; set; }

        public virtual ICollection<Fakturarad> Fakturarads { get; set; }
        public virtual ICollection<LevFakturaRad> LevFakturaRads { get; set; }
        public virtual ICollection<Produkt> Produkts { get; set; }

    }
}
