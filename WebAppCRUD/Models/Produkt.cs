using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Produkt
    {
        [Key]
        [Column("Produkt/Tjanst")]
        [StringLength(50)]
        public string ProduktTjanst { get; set; }
        [StringLength(50)]
        public string Beskrivning { get; set; }
        [Required]
        [StringLength(15)]
        public string Enhet { get; set; }
        [Column(TypeName = "money")]
        public decimal? Enhetspris { get; set; }

        [ForeignKey(nameof(Enhet))]
        [InverseProperty("Produkt")]
        public virtual Enhet EnhetNavigation { get; set; }
    }
}
