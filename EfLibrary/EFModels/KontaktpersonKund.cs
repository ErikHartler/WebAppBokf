using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class KontaktpersonKund
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kundnummer")]
#nullable enable
        public int? Kundnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Radnummer")]
        public int? Radnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Förnamn")]

        public string? Fornamn { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Efternamn")]
        public string? Efternamn { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Direkttelefon")]
        public string? TelefonDirekt { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Hemtelefon")]
        public string? TelefonHem { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Mobiltelefon")]
        public string? TelefonMobil { get; set; }

        public virtual Kund? KundnummerNavigation { get; set; }
#nullable restore
    }
}
