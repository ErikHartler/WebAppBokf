using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    [Table("Menyval_Person")]
    public partial class MenyvalPerson
    {
        [StringLength(10)]
        public string Anvandare { get; set; }
        public int? Menyvalsnummer { get; set; }
        public int? AnvandAntal { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AnvandSenast { get; set; }
        public bool MakeCmd { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Anvandare))]
        [InverseProperty(nameof(Personal.MenyvalPerson))]
        public virtual Personal AnvandareNavigation { get; set; }
        [ForeignKey(nameof(Menyvalsnummer))]
        [InverseProperty(nameof(Menyval.MenyvalPerson))]
        public virtual Menyval MenyvalsnummerNavigation { get; set; }
    }
}
