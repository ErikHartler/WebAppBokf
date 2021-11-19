using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class Projekt
    {
        public Projekt()
        {
            Fakturas = new HashSet<Faktura>();
            ProjektAktivitets = new HashSet<ProjektAktivitet>();
        }

        public int Projektnr { get; set; }
        public int? Kundnr { get; set; }
        public DateTime? StartFrom { get; set; }
        public string? Kod { get; set; }
        public string? Beskrivning { get; set; }
        public string? Projektledare { get; set; }
        public DateTime? TillOchMed { get; set; }
        public decimal? Timpris { get; set; }
        public string? VarReferens { get; set; }
        public int? ErReferens { get; set; }

        public virtual Kund? KundnrNavigation { get; set; }
        public virtual ICollection<Faktura> Fakturas { get; set; }
        public virtual ICollection<ProjektAktivitet> ProjektAktivitets { get; set; }
    }
}
