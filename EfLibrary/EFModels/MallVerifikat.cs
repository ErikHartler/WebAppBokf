using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("MallVerifikat")]
    public partial class MallVerifikat
    {
        public MallVerifikat()
        {
            MallTransaktioners = new HashSet<MallTransaktioner>();
        }

        [Key]
        [StringLength(15)]
        public string Kortkod { get; set; }
        [StringLength(10)]
        public string Konto100Proc { get; set; }
        public bool OmDebet100Proc { get; set; }
        [StringLength(255)]
        public string Anvands { get; set; }
        [StringLength(255)]
        public string Frekvens { get; set; }
        [Column(TypeName = "money")]
        public decimal? Belopp100Proc { get; set; }
        public bool OmKundnrSpec { get; set; }

        [InverseProperty(nameof(MallTransaktioner.KortkodNavigation))]
        public virtual ICollection<MallTransaktioner> MallTransaktioners { get; set; }
    }
}
