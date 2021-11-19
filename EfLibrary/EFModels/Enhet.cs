using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

        public string Enhet1 { get; set; } = null!;
        public string? Beskrivning { get; set; }

        public virtual ICollection<Fakturarad> Fakturarads { get; set; }
        public virtual ICollection<LevFakturaRad> LevFakturaRads { get; set; }
        public virtual ICollection<Produkt> Produkts { get; set; }

    }
}
