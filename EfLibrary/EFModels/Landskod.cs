using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Landskod
    {
        public Landskod()
        {
            Fakturas = new HashSet<Faktura>();
            Kunds = new HashSet<Kund>();
            Leverantors = new HashSet<Leverantor>();
        }

        [System.ComponentModel.DataAnnotations.Display(Name = "Kod")]
        public string Kod { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.Display(Name = "Land")]
        public string Land { get; set; }

        public virtual ICollection<Faktura> Fakturas { get; set; }
        public virtual ICollection<Kund> Kunds { get; set; }
        public virtual ICollection<Leverantor> Leverantors { get; set; }
    }
}
