using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Menyval")]
    public partial class Menyval
    {
        public Menyval()
        {
            MenyvalPeople = new HashSet<MenyvalPerson>();
            MenyvalPersFunkts = new HashSet<MenyvalPersFunkt>();
        }

        [Key]
        public int Menyvalsnr { get; set; }
        [Column("Menyval")]
        [StringLength(20)]
        public string Menyval1 { get; set; }
        [StringLength(20)]
        public string Meny { get; set; }
        [StringLength(100)]
        public string Beskrivning { get; set; }
        [Column("form")]
        [StringLength(50)]
        public string Form { get; set; }
        [Column("report")]
        [StringLength(50)]
        public string Report { get; set; }
        [Column("query")]
        [StringLength(50)]
        public string Query { get; set; }
        [StringLength(50)]
        public string ShellFunction { get; set; }

        [InverseProperty(nameof(MenyvalPerson.MenyvalsnummerNavigation))]
        public virtual ICollection<MenyvalPerson> MenyvalPeople { get; set; }
        [InverseProperty(nameof(MenyvalPersFunkt.MenyvalsnummerNavigation))]
        public virtual ICollection<MenyvalPersFunkt> MenyvalPersFunkts { get; set; }
    }
}
