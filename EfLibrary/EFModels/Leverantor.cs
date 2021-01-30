using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Leverantor")]
    public partial class Leverantor
    {
        public Leverantor()
        {
            Betalnings = new HashSet<Betalning>();
            KontaktpersonLeverantors = new HashSet<KontaktpersonLeverantor>();
            ProjektAktivitets = new HashSet<ProjektAktivitet>();
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
        [InverseProperty(nameof(Landskod.Leverantors))]
        public virtual Landskod LandNavigation { get; set; }
        [InverseProperty(nameof(Betalning.LeverantorsnrNavigation))]
        public virtual ICollection<Betalning> Betalnings { get; set; }
        [InverseProperty(nameof(KontaktpersonLeverantor.LeverantorsnummerNavigation))]
        public virtual ICollection<KontaktpersonLeverantor> KontaktpersonLeverantors { get; set; }
        [InverseProperty(nameof(ProjektAktivitet.LeverantorsnummerNavigation))]
        public virtual ICollection<ProjektAktivitet> ProjektAktivitets { get; set; }
    }
}
