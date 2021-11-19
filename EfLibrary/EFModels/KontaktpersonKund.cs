using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class KontaktpersonKund
    {
        public int Id { get; set; }
        public int? Kundnummer { get; set; }
        public int? Radnummer { get; set; }
        public string? Fornamn { get; set; }
        public string? Efternamn { get; set; }
        public string? TelefonDirekt { get; set; }
        public string? TelefonHem { get; set; }
        public string? TelefonMobil { get; set; }

        public virtual Kund? KundnummerNavigation { get; set; }
    }
}
