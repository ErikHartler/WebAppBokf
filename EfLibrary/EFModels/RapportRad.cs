using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class RapportRad
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Rapport")]
        public string Rapport { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.Display(Name = "Radnummer")]
        public double Radnr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Konto från")]
#nullable enable
        public string? KontoFrom { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Konto till")]
        public string? KontoTom { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Rad från/till")]
        public string? RadFromTom { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Radbenämning")]
        public string? Radbenamning { get; set; }

#nullable restore
        [System.ComponentModel.DataAnnotations.Display(Name = "Addera ingående balans?")]
        public bool OmAdderaIb { get; set; }

        public virtual Rapport RapportNavigation { get; set; } = null!;
    }
}
