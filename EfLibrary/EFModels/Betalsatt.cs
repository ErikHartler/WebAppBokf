using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfLibrary.EFModels
{
    public partial class Betalsatt
    {
        public Betalsatt()
        {
            Betalnings = new HashSet<Betalning>();
        }
        [Display(Name = "Kod")]
        public string Kod { get; set; } = null!;
        [Display(Name = "Beskrivning")]
        public string Beskrivning { get; set; }

        public virtual ICollection<Betalning> Betalnings { get; set; }
    }
}
