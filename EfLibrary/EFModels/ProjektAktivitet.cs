using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class ProjektAktivitet
    {
        public int Id { get; set; }
        public int? Projektnummer { get; set; }
        public int? Aktivitetsnummer { get; set; }
        public int? Leverantorsnummer { get; set; }
        public DateTime? StartFrom { get; set; }
        public DateTime? TillOchMed { get; set; }

        public virtual Leverantor? LeverantorsnummerNavigation { get; set; }
        public virtual Projekt? ProjektnummerNavigation { get; set; }
    }
}
