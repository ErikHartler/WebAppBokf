using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Transaktion")]
    public partial class Transaktion
    {
        public int? Verifikation { get; set; }
        public int? Radnummer { get; set; }
        [Column(TypeName = "money")]
        public decimal? DebetKr { get; set; }
        [StringLength(10)]
        public string Konto { get; set; }
        [StringLength(15)]
        public string Kostnadsbarare { get; set; }
        [Column(TypeName = "money")]
        public decimal? KreditKr { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Verifikation))]
        [InverseProperty("Transaktions")]
        public virtual Verifikation VerifikationNavigation { get; set; }
    }
}
