using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Installningar")]
    public partial class Installningar
    {
        [Column("Bokforingsar from", TypeName = "datetime")]
        public DateTime? BokforingsarFrom { get; set; }
        [Column("Bokforingsar tom", TypeName = "datetime")]
        public DateTime? BokforingsarTom { get; set; }
        [StringLength(50)]
        public string Bolagsnamn { get; set; }
        [StringLength(50)]
        public string Organisationsnr { get; set; }
        [StringLength(10)]
        public string KontoIngMoms { get; set; }
        [StringLength(10)]
        public string KontoUtgMoms { get; set; }
        [StringLength(10)]
        public string KontoMomsAvstamning { get; set; }
        [StringLength(10)]
        public string KontoIntakterFrom { get; set; }
        [StringLength(10)]
        public string KontoIntakterTom { get; set; }
        [StringLength(10)]
        public string KontoIntakterKund { get; set; }
        [StringLength(10)]
        public string KontoFordranFrom { get; set; }
        [StringLength(10)]
        public string KontoFordranTom { get; set; }
        [StringLength(10)]
        public string KontoFordranKund { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
