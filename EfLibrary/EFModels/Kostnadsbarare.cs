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

        [System.ComponentModel.DataAnnotations.Display(Name = "Kostnadsbärare")]
        public string Kostnadsbarare1 { get; set; } = null!;

#nullable enable
        [System.ComponentModel.DataAnnotations.Display(Name = "Beskrivning")]
        public string? Beskrivning { get; set; }
#nullable restore
        public virtual ICollection<MallTransaktioner> MallTransaktioners { get; set; }
        public virtual ICollection<Transaktion> Transaktions { get; set; }
    }
}
