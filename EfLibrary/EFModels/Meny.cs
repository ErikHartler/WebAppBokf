using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Meny")]
    public partial class Meny
    {
        [Key]
        [Column("Meny")]
        [StringLength(15)]
        public string Meny1 { get; set; }
        [StringLength(50)]
        public string Beskrivning { get; set; }
        [Column("presentationsordning")]
        public int? Presentationsordning { get; set; }
    }
}
