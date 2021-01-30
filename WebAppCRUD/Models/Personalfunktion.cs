using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Personalfunktion
    {
        public Personalfunktion()
        {
            MenyvalPersFunkt = new HashSet<MenyvalPersFunkt>();
            Personal = new HashSet<Personal>();
        }

        [Key]
        [Column("Personalfunktion")]
        [StringLength(20)]
        public string Personalfunktion1 { get; set; }
        [StringLength(50)]
        public string Beskrivning { get; set; }

        [InverseProperty("PersonalfunktionNavigation")]
        public virtual ICollection<MenyvalPersFunkt> MenyvalPersFunkt { get; set; }
        [InverseProperty("PersonalfunktionNavigation")]
        public virtual ICollection<Personal> Personal { get; set; }
    }
}
