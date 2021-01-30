using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Betalsatt")]
    public partial class Betalsatt
    {
        public Betalsatt()
        {
            Betalnings = new HashSet<Betalning>();
        }

        [Key]
        [Column("Betalsatt")]
        [StringLength(10)]
        public string Betalsatt1 { get; set; }
        [StringLength(50)]
        public string Beskrivning { get; set; }

        [InverseProperty(nameof(Betalning.BetalsattNavigation))]
        public virtual ICollection<Betalning> Betalnings { get; set; }
    }
}
