using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Enhet")]
    public partial class Enhet
    {
        public Enhet()
        {
            Fakturarads = new HashSet<Fakturarad>();
            Produkts = new HashSet<Produkt>();
        }

        [Key]
        [Column("Enhet")]
        [StringLength(15)]
        public string Enhet1 { get; set; }
        [StringLength(50)]
        public string Beskrivning { get; set; }

        [InverseProperty(nameof(Fakturarad.EnhetNavigation))]
        public virtual ICollection<Fakturarad> Fakturarads { get; set; }
        [InverseProperty(nameof(Produkt.EnhetNavigation))]
        public virtual ICollection<Produkt> Produkts { get; set; }
    }
}
