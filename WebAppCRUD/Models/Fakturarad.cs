using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Fakturarad
    {
        public int? Fakturanummer { get; set; }
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
        public double? Antal { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Enhet))]
        [InverseProperty("Fakturarad")]
        public virtual Enhet EnhetNavigation { get; set; }
        [ForeignKey(nameof(Fakturanummer))]
        [InverseProperty(nameof(Faktura.Fakturarad))]
        public virtual Faktura FakturanummerNavigation { get; set; }
    }
}
