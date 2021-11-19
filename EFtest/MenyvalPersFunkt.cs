using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class MenyvalPersFunkt
    {
        public int Id { get; set; }
        public string Personalfunktion { get; set; } = null!;
        public int? Menyvalsnummer { get; set; }

        public virtual Menyval? MenyvalsnummerNavigation { get; set; }
        public virtual Personalfunktion PersonalfunktionNavigation { get; set; } = null!;
    }
}
