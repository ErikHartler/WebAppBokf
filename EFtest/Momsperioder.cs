using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class Momsperioder
    {
        public int Id { get; set; }
        public DateTime? MomsperiodStart { get; set; }
        public DateTime? MomsperiodSlut { get; set; }
        public DateTime? SenasteInbetDatum { get; set; }
        public int? Verifikationsnr { get; set; }

        public virtual Verifikation? VerifikationsnrNavigation { get; set; }
    }
}
