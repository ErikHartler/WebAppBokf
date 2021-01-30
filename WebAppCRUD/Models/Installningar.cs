using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Installningar
    {
        [Column("Bokforingsar from", TypeName = "datetime")]
        public DateTime? BokforingsarFrom { get; set; }
        [Column("Bokforingsar tom", TypeName = "datetime")]
        public DateTime? BokforingsarTom { get; set; }
        [StringLength(50)]
        public string Bolagsnamn { get; set; }
        [StringLength(50)]
        public string Organisationsnr { get; set; }
        [StringLength(10)]
        public string KontoIngMoms { get; set; }
        [StringLength(10)]
        public string KontoUtgMoms { get; set; }
        [StringLength(10)]
        public string KontoMomsAvstamning { get; set; }
        [StringLength(10)]
        public string KontoIntakterFrom { get; set; }
        [StringLength(10)]
        public string KontoIntakterTom { get; set; }
        [StringLength(10)]
        public string KontoIntakterKund { get; set; }
        [StringLength(10)]
        public string KontoFordranFrom { get; set; }
        [StringLength(10)]
        public string KontoFordranTom { get; set; }
        [StringLength(10)]
        public string KontoFordranKund { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(KontoFordranFrom))]
        [InverseProperty(nameof(Konto.InstallningarKontoFordranFromNavigation))]
        public virtual Konto KontoFordranFromNavigation { get; set; }
        [ForeignKey(nameof(KontoFordranKund))]
        [InverseProperty(nameof(Konto.InstallningarKontoFordranKundNavigation))]
        public virtual Konto KontoFordranKundNavigation { get; set; }
        [ForeignKey(nameof(KontoFordranTom))]
        [InverseProperty(nameof(Konto.InstallningarKontoFordranTomNavigation))]
        public virtual Konto KontoFordranTomNavigation { get; set; }
        [ForeignKey(nameof(KontoIngMoms))]
        [InverseProperty(nameof(Konto.InstallningarKontoIngMomsNavigation))]
        public virtual Konto KontoIngMomsNavigation { get; set; }
        [ForeignKey(nameof(KontoIntakterFrom))]
        [InverseProperty(nameof(Konto.InstallningarKontoIntakterFromNavigation))]
        public virtual Konto KontoIntakterFromNavigation { get; set; }
        [ForeignKey(nameof(KontoIntakterKund))]
        [InverseProperty(nameof(Konto.InstallningarKontoIntakterKundNavigation))]
        public virtual Konto KontoIntakterKundNavigation { get; set; }
        [ForeignKey(nameof(KontoIntakterTom))]
        [InverseProperty(nameof(Konto.InstallningarKontoIntakterTomNavigation))]
        public virtual Konto KontoIntakterTomNavigation { get; set; }
        [ForeignKey(nameof(KontoMomsAvstamning))]
        [InverseProperty(nameof(Konto.InstallningarKontoMomsAvstamningNavigation))]
        public virtual Konto KontoMomsAvstamningNavigation { get; set; }
        [ForeignKey(nameof(KontoUtgMoms))]
        [InverseProperty(nameof(Konto.InstallningarKontoUtgMomsNavigation))]
        public virtual Konto KontoUtgMomsNavigation { get; set; }
    }
}
