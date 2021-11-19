using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class KontaktpersonLeverantor
    {
        public int Id { get; set; }
        public int? Leverantorsnummer { get; set; }
        public int? Radnummer { get; set; }
        public string? Fornamn { get; set; }
        public string? Efternamn { get; set; }
        public string? TelefonDirekt { get; set; }
        public string? TelefonHem { get; set; }
        public string? TelefonMobil { get; set; }

        public virtual Leverantor? LeverantorsnummerNavigation { get; set; }
    }
}
