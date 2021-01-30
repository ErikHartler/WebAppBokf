using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("ProjektAktivitet")]
    public partial class ProjektAktivitet
    {
        public int? Projektnummer { get; set; }
        public int? Aktivitetsnummer { get; set; }
        public int? Leverantorsnummer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartFrom { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TillOchMed { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Leverantorsnummer))]
        [InverseProperty(nameof(Leverantor.ProjektAktivitets))]
        public virtual Leverantor LeverantorsnummerNavigation { get; set; }
        [ForeignKey(nameof(Projektnummer))]
        [InverseProperty(nameof(Projekt.ProjektAktivitets))]
        public virtual Projekt ProjektnummerNavigation { get; set; }
    }
}
