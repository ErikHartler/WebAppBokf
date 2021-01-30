using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Enhet
    {
        public Enhet()
        {
            Fakturarad = new HashSet<Fakturarad>();
            LevFakturaRad = new HashSet<LevFakturaRad>();
            Produkt = new HashSet<Produkt>();
        }

        [Key]
        [Column("Enhet")]
        [StringLength(15)]
        public string Enhet1 { get; set; }
        [StringLength(50)]
        public string Beskrivning { get; set; }

        [InverseProperty("EnhetNavigation")]
        public virtual ICollection<Fakturarad> Fakturarad { get; set; }
        [InverseProperty("EnhetNavigation")]
        public virtual ICollection<LevFakturaRad> LevFakturaRad { get; set; }
        [InverseProperty("EnhetNavigation")]
        public virtual ICollection<Produkt> Produkt { get; set; }
    }
}
