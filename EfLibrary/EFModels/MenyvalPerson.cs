using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class MenyvalPerson
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Användare")]
        public string Anvandare { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Menyvalsnummer")]
        public int   Menyvalsnummer { get; set; }

#nullable enable

        [System.ComponentModel.DataAnnotations.Display(Name = "Användningsantal")]
        public int? AnvandAntal { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Senast använd")]
        public DateTime? AnvandSenast { get; set; }

#nullable restore

        [System.ComponentModel.DataAnnotations.Display(Name = "Skapa kommando")]
        public bool MakeCmd { get; set; }

        public virtual Personal AnvandareNavigation { get; set; }
        public virtual Menyval MenyvalsnummerNavigation { get; set; }
    }
}
