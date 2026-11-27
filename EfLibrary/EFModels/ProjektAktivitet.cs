using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class ProjektAktivitet
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Projektnummer")]
        public int? Projektnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Aktivitetsnummer")]
        public int? Aktivitetsnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Leverantörsnummer")]
        public int? Leverantorsnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Startdatum")]
        public DateTime? StartFrom { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Slutdatum")]
        public DateTime? TillOchMed { get; set; }

        public virtual Leverantor LeverantorsnummerNavigation { get; set; }
        public virtual Projekt ProjektnummerNavigation { get; set; }
    }
}
