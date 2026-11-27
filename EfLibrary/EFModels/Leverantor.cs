using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Leverantor
    {
        public Leverantor()
        {
            Betalnings = new HashSet<Betalning>();
            KontaktpersonLeverantors = new HashSet<KontaktpersonLeverantor>();
            ProjektAktivitets = new HashSet<ProjektAktivitet>();
        }

        [System.ComponentModel.DataAnnotations.Display(Name = "Leverantörsnummer")]
        public int Leverantorsnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Namn")]
        public string Namn { get; set; }

#nullable enable
        [System.ComponentModel.DataAnnotations.Display(Name = "Adress")]
        public string? Adress { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Postnummer")]
        public string? Postnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Ort")]
        public string? Ort { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Land")]
        public string? Land { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Telefonnummer")]
        public string? Telefonnummer { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Telefax")]
        public string? Telefax { get; set; }

        public virtual Landskod? LandNavigation { get; set; }
#nullable restore
        public virtual ICollection<Betalning> Betalnings { get; set; }
        public virtual ICollection<KontaktpersonLeverantor> KontaktpersonLeverantors { get; set; }
        public virtual ICollection<ProjektAktivitet> ProjektAktivitets { get; set; }
    }
}
