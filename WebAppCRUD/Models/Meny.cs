using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Meny
    {
        public Meny()
        {
            Menyval = new HashSet<Menyval>();
        }

        [Key]
        [Column("Meny")]
        [StringLength(15)]
        public string Meny1 { get; set; }
        [StringLength(50)]
        public string Beskrivning { get; set; }
        [Column("presentationsordning")]
        public int? Presentationsordning { get; set; }

        [InverseProperty("MenyNavigation")]
        public virtual ICollection<Menyval> Menyval { get; set; }
    }
}
