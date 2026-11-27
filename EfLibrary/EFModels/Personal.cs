using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Personal
    {
        public Personal()
        {
            MenyvalPeople = new HashSet<MenyvalPerson>();
        }

        [System.ComponentModel.DataAnnotations.Display(Name = "Signatur")]
        public string Signatur { get; set; } = null!;


        [System.ComponentModel.DataAnnotations.Display(Name = "Förnamn")]
        public string Fornamn { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Efternamn")]
        public string Efternamn { get; set; }

#nullable enable

        [System.ComponentModel.DataAnnotations.Display(Name = "Telefonnummer")]

        public string? Telefonnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Mobiltelefon")]
        public string? Mobiltelefon { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Personalfunktion")]
        public string? Personalfunktion { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Introduktion via knappar")]
        public bool IntroViaknappar { get; set; }


        public virtual Personalfunktion? PersonalfunktionNavigation { get; set; }
        public virtual ICollection<MenyvalPerson> MenyvalPeople { get; set; }
#nullable restore

    }
}
