using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class MallVerifikat
    {
        public MallVerifikat()
        {
            MallTransaktioners = new HashSet<MallTransaktioner>();
        }

        [System.ComponentModel.DataAnnotations.Display(Name = "Kortkod")]
        public string Kortkod { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.Display(Name = "Konto 100 procent")]
        public string  Konto100Proc { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Debet 100 procent?")]
        public bool OmDebet100Proc { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Används")]
        public string  Anvands { get; set; }
#nullable enable
        [System.ComponentModel.DataAnnotations.Display(Name = "Frekvens")]
        public string? Frekvens { get; set; }
#nullable restore
        [System.ComponentModel.DataAnnotations.Display(Name = "Belopp 100 procent")]
        public decimal Belopp100Proc { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Specificera kundnummer?")]
        public bool OmKundnrSpec { get; set; }

        public virtual Konto Konto100ProcNavigation { get; set; }
        public virtual ICollection<MallTransaktioner> MallTransaktioners { get; set; }
    }
}
