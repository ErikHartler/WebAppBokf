using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Momsperioder
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Momsperiod start")]
        public DateTime? MomsperiodStart { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Momsperiod slut")]
        public DateTime? MomsperiodSlut { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Senaste inbetalningsdatum")]
        public DateTime? SenasteInbetDatum { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Verifikationsnummer")]
        public int? Verifikationsnr { get; set; }
#nullable enable
        public virtual Verifikation? VerifikationsnrNavigation { get; set; }
#nullable restore
    }
}
