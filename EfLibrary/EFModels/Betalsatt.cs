using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Betalsatt
    {
        public Betalsatt()
        {
            Betalnings = new HashSet<Betalning>();
        }

        public string Betalsatt1 { get; set; } = null!;
        public string? Beskrivning { get; set; }

        public virtual ICollection<Betalning> Betalnings { get; set; }
    }
}
