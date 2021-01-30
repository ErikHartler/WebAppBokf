using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Landskod
    {
        public Landskod()
        {
            Faktura = new HashSet<Faktura>();
            Kund = new HashSet<Kund>();
            Leverantor = new HashSet<Leverantor>();
        }

        [Key]
        [Column("Landskod")]
        [StringLength(5)]
        public string Landskod1 { get; set; }
        [StringLength(50)]
        public string Land { get; set; }

        [InverseProperty("LandNavigation")]
        public virtual ICollection<Faktura> Faktura { get; set; }
        [InverseProperty("LandskodNavigation")]
        public virtual ICollection<Kund> Kund { get; set; }
        [InverseProperty("LandNavigation")]
        public virtual ICollection<Leverantor> Leverantor { get; set; }
    }
}
