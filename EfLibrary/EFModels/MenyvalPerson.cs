using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
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

        [ForeignKey(nameof(Menyvalsnummer))]
        [InverseProperty(nameof(Menyval.MenyvalPeople))]
        public virtual Menyval MenyvalsnummerNavigation { get; set; }
    }
}
