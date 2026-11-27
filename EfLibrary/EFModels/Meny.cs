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

        [System.ComponentModel.DataAnnotations.Display(Name = "Meny")]
        public string Kod { get; set; } = null!;

#nullable enable
        [System.ComponentModel.DataAnnotations.Display(Name = "Beskrivning")]
        public string? Beskrivning { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Presentationsordning")]
#nullable restore
        public int? Presentationsordning { get; set; }

        public virtual ICollection<Menyval> Menyvals { get; set; }
    }
}
