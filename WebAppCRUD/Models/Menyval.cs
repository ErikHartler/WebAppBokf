using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Menyval
    {
        public Menyval()
        {
            MenyvalPersFunkt = new HashSet<MenyvalPersFunkt>();
            MenyvalPerson = new HashSet<MenyvalPerson>();
        }

        [Key]
        public int Menyvalsnr { get; set; }
        [Column("Menyval")]
        [StringLength(20)]
        public string Menyval1 { get; set; }
        [StringLength(15)]
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

        [ForeignKey(nameof(Meny))]
        [InverseProperty("Menyval")]
        public virtual Meny MenyNavigation { get; set; }
        [InverseProperty("MenyvalsnummerNavigation")]
        public virtual ICollection<MenyvalPersFunkt> MenyvalPersFunkt { get; set; }
        [InverseProperty("MenyvalsnummerNavigation")]
        public virtual ICollection<MenyvalPerson> MenyvalPerson { get; set; }
    }
}
