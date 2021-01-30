using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("LevFakturaRad")]
    public partial class LevFakturaRad
    {
        public int? LevFakturanummer { get; set; }
        public int? Radnummer { get; set; }
        [Column("Produkt/Tjanst")]
        [StringLength(50)]
        public string ProduktTjanst { get; set; }
        [Column(TypeName = "money")]
        public decimal? Enhetspris { get; set; }
        [StringLength(15)]
        public string Enhet { get; set; }
        [Column("Summa Kr", TypeName = "money")]
        public decimal? SummaKr { get; set; }
        public int? Antal { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(LevFakturanummer))]
        [InverseProperty(nameof(LevFaktura.LevFakturaRads))]
        public virtual LevFaktura LevFakturanummerNavigation { get; set; }
    }
}
