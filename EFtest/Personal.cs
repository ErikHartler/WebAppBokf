using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class Personal
    {
        public Personal()
        {
            MenyvalPeople = new HashSet<MenyvalPerson>();
        }

        public string Signatur { get; set; } = null!;
        public string? Fornamn { get; set; }
        public string? Efternamn { get; set; }
        public string? Telefonnummer { get; set; }
        public string? Mobiltelefon { get; set; }
        public string? Personalfunktion { get; set; }
        public bool IntroViaknappar { get; set; }

        public virtual Personalfunktion? PersonalfunktionNavigation { get; set; }
        public virtual ICollection<MenyvalPerson> MenyvalPeople { get; set; }
    }
}
