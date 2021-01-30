using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Projekt
    {
        public Projekt()
        {
            Faktura = new HashSet<Faktura>();
            ProjektAktivitet = new HashSet<ProjektAktivitet>();
        }

        public int? Kundnr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartFrom { get; set; }
        [StringLength(5)]
        public string Kod { get; set; }
        [Key]
        public int Projektnr { get; set; }
        [StringLength(50)]
        public string Beskrivning { get; set; }
        [StringLength(10)]
        public string Projektledare { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TillOchMed { get; set; }
        [Column(TypeName = "money")]
        public decimal? Timpris { get; set; }
        [StringLength(10)]
        public string VarReferens { get; set; }
        public int? ErReferens { get; set; }

        [ForeignKey(nameof(Kundnr))]
        [InverseProperty(nameof(Kund.Projekt))]
        public virtual Kund KundnrNavigation { get; set; }
        [InverseProperty("ProjektNavigation")]
        public virtual ICollection<Faktura> Faktura { get; set; }
        [InverseProperty("ProjektnummerNavigation")]
        public virtual ICollection<ProjektAktivitet> ProjektAktivitet { get; set; }
    }
}
