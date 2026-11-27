using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class KontaktpersonLeverantor
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Leverantörsnummer")]
        public int Leverantorsnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Radnummer")]
        public int Radnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Förnamn")]

#nullable enable
        public string? Fornamn { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Efternamn")]
        public string? Efternamn { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Direkttelefon")]
        public string? TelefonDirekt { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Hemtelefon")]
        public string? TelefonHem { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Mobiltelefon")]
        public string? TelefonMobil { get; set; }

        public virtual Leverantor? LeverantorsnummerNavigation { get; set; }
#nullable restore
    }
}
