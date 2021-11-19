using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class Landskod
    {
        public Landskod()
        {
            Fakturas = new HashSet<Faktura>();
            Kunds = new HashSet<Kund>();
            Leverantors = new HashSet<Leverantor>();
        }

        public string Landskod1 { get; set; } = null!;
        public string? Land { get; set; }

        public virtual ICollection<Faktura> Fakturas { get; set; }
        public virtual ICollection<Kund> Kunds { get; set; }
        public virtual ICollection<Leverantor> Leverantors { get; set; }
    }
}
