using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Menyval
    {
        public Menyval()
        {
            MenyvalPeople = new HashSet<MenyvalPerson>();
            MenyvalPersFunkts = new HashSet<MenyvalPersFunkt>();
        }

        [System.ComponentModel.DataAnnotations.Display(Name = "Menyvalsnr")]
        public int Menyvalsnr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Menyval")]
        public string Menyval1 { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Meny")]
        public string Meny { get; set; }

#nullable enable
        [System.ComponentModel.DataAnnotations.Display(Name = "Beskrivning")]
        public string? Beskrivning { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Formulär")]
        public string? Form { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Rapport")]
        public string? Report { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Fråga")]
        public string? Query { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Shell-funktion")]
        public string? ShellFunction { get; set; }

        public virtual Meny? MenyNavigation { get; set; }
#nullable restore
        public virtual ICollection<MenyvalPerson> MenyvalPeople { get; set; }
        public virtual ICollection<MenyvalPersFunkt> MenyvalPersFunkts { get; set; }
    }
}
