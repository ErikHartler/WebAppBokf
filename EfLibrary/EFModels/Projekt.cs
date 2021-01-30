using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Projekt")]
    public partial class Projekt
    {
        public Projekt()
        {
            ProjektAktivitets = new HashSet<ProjektAktivitet>();
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

        [InverseProperty(nameof(ProjektAktivitet.ProjektnummerNavigation))]
        public virtual ICollection<ProjektAktivitet> ProjektAktivitets { get; set; }
    }
}
