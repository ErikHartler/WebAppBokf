using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Projekt
    {
        public Projekt()
        {
            Fakturas = new HashSet<Faktura>();
            ProjektAktivitets = new HashSet<ProjektAktivitet>();
        }

        [System.ComponentModel.DataAnnotations.Display(Name = "Projektnummer")]
        public int Projektnr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kundnummer")]
        public int? Kundnr { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Vår referens")]
        public string VarReferens { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Er referens")]
        public int? ErReferens { get; set; }

#nullable enable
        [System.ComponentModel.DataAnnotations.Display(Name = "Startdatum")]
        public DateTime? StartFrom { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Kod")]
        public string? Kod { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Beskrivning")]
        public string? Beskrivning { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Projektledare")]
        public string? Projektledare { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Slutdatum")]
        public DateTime? TillOchMed { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Timpris")]
        public decimal? Timpris { get; set; }
#nullable enable
        public virtual Kund KundnrNavigation { get; set; }
        public virtual ICollection<Faktura> Fakturas { get; set; }
        public virtual ICollection<ProjektAktivitet> ProjektAktivitets { get; set; }
    }
}
