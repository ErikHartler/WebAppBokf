using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Personalfunktion
    {
        public Personalfunktion()
        {
            MenyvalPersFunkts = new HashSet<MenyvalPersFunkt>();
            Personals = new HashSet<Personal>();
        }

        [System.ComponentModel.DataAnnotations.Display(Name = "Funktion")]
        public string Funktion { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.Display(Name = "Beskrivning")]
        public string Beskrivning { get; set; }

        public virtual ICollection<MenyvalPersFunkt> MenyvalPersFunkts { get; set; }
        public virtual ICollection<Personal> Personals { get; set; }
    }
}
