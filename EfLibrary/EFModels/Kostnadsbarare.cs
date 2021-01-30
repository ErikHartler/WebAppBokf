using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Kostnadsbarare")]
    public partial class Kostnadsbarare
    {
        [Key]
        [Column("Kostnadsbarare")]
        [StringLength(15)]
        public string Kostnadsbarare1 { get; set; }
        [StringLength(50)]
        public string Beskrivning { get; set; }
    }
}
