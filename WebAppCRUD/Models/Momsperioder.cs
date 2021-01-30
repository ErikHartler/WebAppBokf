using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Momsperioder
    {
        [Column(TypeName = "datetime")]
        public DateTime? MomsperiodStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? MomsperiodSlut { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SenasteInbetDatum { get; set; }
        public int? Verifikationsnr { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Verifikationsnr))]
        [InverseProperty(nameof(Verifikation.Momsperioder))]
        public virtual Verifikation VerifikationsnrNavigation { get; set; }
    }
}
