using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Kostnadsbarare
    {
        public Kostnadsbarare()
        {
            MallTransaktioners = new HashSet<MallTransaktioner>();
            Transaktions = new HashSet<Transaktion>();
        }

        public string Kostnadsbarare1 { get; set; } = null!;
        public string? Beskrivning { get; set; }

        public virtual ICollection<MallTransaktioner> MallTransaktioners { get; set; }
        public virtual ICollection<Transaktion> Transaktions { get; set; }
    }
}
