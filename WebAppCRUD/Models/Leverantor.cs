using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Leverantor
    {
        public Leverantor()
        {
            Betalning = new HashSet<Betalning>();
            KontaktpersonLeverantor = new HashSet<KontaktpersonLeverantor>();
            ProjektAktivitet = new HashSet<ProjektAktivitet>();
        }

        [Key]
        public int Leverantorsnummer { get; set; }
        [StringLength(40)]
        public string Namn { get; set; }
        [StringLength(40)]
        public string Adress { get; set; }
        [StringLength(10)]
        public string Postnummer { get; set; }
        [StringLength(40)]
        public string Ort { get; set; }
        [StringLength(5)]
        public string Land { get; set; }
        [StringLength(20)]
        public string Telefonnummer { get; set; }
        [StringLength(20)]
        public string Telefax { get; set; }

        [ForeignKey(nameof(Land))]
        [InverseProperty(nameof(Landskod.Leverantor))]
        public virtual Landskod LandNavigation { get; set; }
        [InverseProperty("LeverantorsnrNavigation")]
        public virtual ICollection<Betalning> Betalning { get; set; }
        [InverseProperty("LeverantorsnummerNavigation")]
        public virtual ICollection<KontaktpersonLeverantor> KontaktpersonLeverantor { get; set; }
        [InverseProperty("LeverantorsnummerNavigation")]
        public virtual ICollection<ProjektAktivitet> ProjektAktivitet { get; set; }
    }
}
