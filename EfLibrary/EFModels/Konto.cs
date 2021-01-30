using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Konto")]
    public partial class Konto
    {
        [Key]
        [Column("Konto")]
        [StringLength(10)]
        public string Konto1 { get; set; }
        [Column("arsredovisningsrad")]
        [StringLength(255)]
        public string Arsredovisningsrad { get; set; }
        [StringLength(255)]
        public string Benamning { get; set; }
        [Column("IB Debet Kr", TypeName = "money")]
        public decimal? IbDebetKr { get; set; }
        [Column("IB Kredit Kr", TypeName = "money")]
        public decimal? IbKreditKr { get; set; }
        public bool OmDebet { get; set; }
        [StringLength(255)]
        public string Skattekonto { get; set; }
    }
}
