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

        public int Leverantorsnummer { get; set; }
        public string? Namn { get; set; }
        public string? Adress { get; set; }
        public string? Postnummer { get; set; }
        public string? Ort { get; set; }
        public string? Land { get; set; }
        public string? Telefonnummer { get; set; }
        public string? Telefax { get; set; }

        public virtual Landskod? LandNavigation { get; set; }
        public virtual ICollection<Betalning> Betalnings { get; set; }
        public virtual ICollection<KontaktpersonLeverantor> KontaktpersonLeverantors { get; set; }
        public virtual ICollection<ProjektAktivitet> ProjektAktivitets { get; set; }
    }
}
