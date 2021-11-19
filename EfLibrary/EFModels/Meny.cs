using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Meny
    {
        public Meny()
        {
            Menyvals = new HashSet<Menyval>();
        }

        public string Meny1 { get; set; } = null!;
        public string? Beskrivning { get; set; }
        public int? Presentationsordning { get; set; }

        public virtual ICollection<Menyval> Menyvals { get; set; }
    }
}
