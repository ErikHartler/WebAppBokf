using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Personalfunktion")]
    public partial class Personalfunktion
    {
        public Personalfunktion()
        {
            MenyvalPersFunkts = new HashSet<MenyvalPersFunkt>();
        }

        [Key]
        [Column("Personalfunktion")]
        [StringLength(20)]
        public string Personalfunktion1 { get; set; }
        [StringLength(50)]
        public string Beskrivning { get; set; }

        [InverseProperty(nameof(MenyvalPersFunkt.PersonalfunktionNavigation))]
        public virtual ICollection<MenyvalPersFunkt> MenyvalPersFunkts { get; set; }
    }
}
