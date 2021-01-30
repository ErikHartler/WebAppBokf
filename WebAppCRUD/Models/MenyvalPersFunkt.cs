using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    [Table("Menyval_Pers_funkt")]
    public partial class MenyvalPersFunkt
    {
        [Required]
        [StringLength(20)]
        public string Personalfunktion { get; set; }
        public int? Menyvalsnummer { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Menyvalsnummer))]
        [InverseProperty(nameof(Menyval.MenyvalPersFunkt))]
        public virtual Menyval MenyvalsnummerNavigation { get; set; }
        [ForeignKey(nameof(Personalfunktion))]
        [InverseProperty("MenyvalPersFunkt")]
        public virtual Personalfunktion PersonalfunktionNavigation { get; set; }
    }
}
