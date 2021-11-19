using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class Personalfunktion
    {
        public Personalfunktion()
        {
            MenyvalPersFunkts = new HashSet<MenyvalPersFunkt>();
            Personals = new HashSet<Personal>();
        }

        public string Personalfunktion1 { get; set; } = null!;
        public string? Beskrivning { get; set; }

        public virtual ICollection<MenyvalPersFunkt> MenyvalPersFunkts { get; set; }
        public virtual ICollection<Personal> Personals { get; set; }
    }
}
