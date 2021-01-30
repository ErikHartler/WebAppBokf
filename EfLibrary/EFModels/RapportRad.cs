using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("RapportRad")]
    public partial class RapportRad
    {
        [Required]
        [StringLength(10)]
        public string Rapport { get; set; }
        public double? Radnr { get; set; }
        [StringLength(10)]
        public string KontoFrom { get; set; }
        [StringLength(10)]
        public string KontoTom { get; set; }
        [StringLength(255)]
        public string RadFromTom { get; set; }
        [StringLength(255)]
        public string Radbenamning { get; set; }
        [Column("OmAdderaIB")]
        public bool OmAdderaIb { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Rapport))]
        [InverseProperty("RapportRads")]
        public virtual Rapport RapportNavigation { get; set; }
    }
}
