using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class MenyvalPerson
    {
        public int Id { get; set; }
        public string? Anvandare { get; set; }
        public int? Menyvalsnummer { get; set; }
        public int? AnvandAntal { get; set; }
        public DateTime? AnvandSenast { get; set; }
        public bool MakeCmd { get; set; }

        public virtual Personal? AnvandareNavigation { get; set; }
        public virtual Menyval? MenyvalsnummerNavigation { get; set; }
    }
}
