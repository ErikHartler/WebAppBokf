using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class Installningar
    {
        public int Id { get; set; }
        public DateTime? BokforingsarFrom { get; set; }
        public DateTime? BokforingsarTom { get; set; }
        public string? Bolagsnamn { get; set; }
        public string? Organisationsnr { get; set; }
        public string? KontoIngMoms { get; set; }
        public string? KontoUtgMoms { get; set; }
        public string? KontoMomsAvstamning { get; set; }
        public string? KontoIntakterFrom { get; set; }
        public string? KontoIntakterTom { get; set; }
        public string? KontoIntakterKund { get; set; }
        public string? KontoFordranFrom { get; set; }
        public string? KontoFordranTom { get; set; }
        public string? KontoFordranKund { get; set; }

        public virtual Konto? KontoFordranFromNavigation { get; set; }
        public virtual Konto? KontoFordranKundNavigation { get; set; }
        public virtual Konto? KontoFordranTomNavigation { get; set; }
        public virtual Konto? KontoIngMomsNavigation { get; set; }
        public virtual Konto? KontoIntakterFromNavigation { get; set; }
        public virtual Konto? KontoIntakterKundNavigation { get; set; }
        public virtual Konto? KontoIntakterTomNavigation { get; set; }
        public virtual Konto? KontoMomsAvstamningNavigation { get; set; }
        public virtual Konto? KontoUtgMomsNavigation { get; set; }
    }
}
