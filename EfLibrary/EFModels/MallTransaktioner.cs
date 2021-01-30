using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("MallTransaktioner")]
    public partial class MallTransaktioner
    {
        [Required]
        [StringLength(15)]
        public string Kortkod { get; set; }
        public int? Radnr { get; set; }
        [Column(TypeName = "money")]
        public decimal? DebetProc { get; set; }
        [Column(TypeName = "money")]
        public decimal? KreditProc { get; set; }
        [StringLength(10)]
        public string Konto { get; set; }
        [StringLength(15)]
        public string Kostnadsbarare { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Kortkod))]
        [InverseProperty(nameof(MallVerifikat.MallTransaktioners))]
        public virtual MallVerifikat KortkodNavigation { get; set; }
    }
}
