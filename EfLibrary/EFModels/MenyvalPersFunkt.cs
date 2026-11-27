using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class MenyvalPersFunkt
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Personalfunktion")]
        public string Personalfunktion { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.Display(Name = "Menyvalsnummer")]
        public int Menyvalsnummer { get; set; }


        public virtual Menyval MenyvalsnummerNavigation { get; set; }
        public virtual Personalfunktion PersonalfunktionNavigation { get; set; } = null!;
    }
}
