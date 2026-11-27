using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Rapport
    {
        public Rapport()
        {
            RapportRads = new HashSet<RapportRad>();
        }

        [System.ComponentModel.DataAnnotations.Display(Name = "Rapport")]
        public string Rapport1 { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.Display(Name = "Benämning")]
        public string Benamning { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Teckenvändning?")]
        public bool OmTeckenvandning { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kolumn 2 ingående balans")]
        public bool OmKol2Ib { get; set; }

#nullable enable
        [System.ComponentModel.DataAnnotations.Display(Name = "Kommentar")]
        public string? Kommentar { get; set; }
#nullable restore
        public virtual ICollection<RapportRad> RapportRads { get; set; }
    }
}
