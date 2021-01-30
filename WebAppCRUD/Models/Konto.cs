using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Konto
    {
        public Konto()
        {
            InstallningarKontoFordranFromNavigation = new HashSet<Installningar>();
            InstallningarKontoFordranKundNavigation = new HashSet<Installningar>();
            InstallningarKontoFordranTomNavigation = new HashSet<Installningar>();
            InstallningarKontoIngMomsNavigation = new HashSet<Installningar>();
            InstallningarKontoIntakterFromNavigation = new HashSet<Installningar>();
            InstallningarKontoIntakterKundNavigation = new HashSet<Installningar>();
            InstallningarKontoIntakterTomNavigation = new HashSet<Installningar>();
            InstallningarKontoMomsAvstamningNavigation = new HashSet<Installningar>();
            InstallningarKontoUtgMomsNavigation = new HashSet<Installningar>();
            MallTransaktioner = new HashSet<MallTransaktioner>();
            MallVerifikat = new HashSet<MallVerifikat>();
            Transaktion = new HashSet<Transaktion>();
        }

        [Key]
        [Column("Konto")]
        [StringLength(10)]
        public string Konto1 { get; set; }
        [Column("arsredovisningsrad")]
        [StringLength(255)]
        public string Arsredovisningsrad { get; set; }
        [StringLength(255)]
        public string Benamning { get; set; }
        [Column("IB Debet Kr", TypeName = "money")]
        public decimal? IbDebetKr { get; set; }
        [Column("IB Kredit Kr", TypeName = "money")]
        public decimal? IbKreditKr { get; set; }
        public bool OmDebet { get; set; }
        [StringLength(255)]
        public string Skattekonto { get; set; }

        [InverseProperty(nameof(Installningar.KontoFordranFromNavigation))]
        public virtual ICollection<Installningar> InstallningarKontoFordranFromNavigation { get; set; }
        [InverseProperty(nameof(Installningar.KontoFordranKundNavigation))]
        public virtual ICollection<Installningar> InstallningarKontoFordranKundNavigation { get; set; }
        [InverseProperty(nameof(Installningar.KontoFordranTomNavigation))]
        public virtual ICollection<Installningar> InstallningarKontoFordranTomNavigation { get; set; }
        [InverseProperty(nameof(Installningar.KontoIngMomsNavigation))]
        public virtual ICollection<Installningar> InstallningarKontoIngMomsNavigation { get; set; }
        [InverseProperty(nameof(Installningar.KontoIntakterFromNavigation))]
        public virtual ICollection<Installningar> InstallningarKontoIntakterFromNavigation { get; set; }
        [InverseProperty(nameof(Installningar.KontoIntakterKundNavigation))]
        public virtual ICollection<Installningar> InstallningarKontoIntakterKundNavigation { get; set; }
        [InverseProperty(nameof(Installningar.KontoIntakterTomNavigation))]
        public virtual ICollection<Installningar> InstallningarKontoIntakterTomNavigation { get; set; }
        [InverseProperty(nameof(Installningar.KontoMomsAvstamningNavigation))]
        public virtual ICollection<Installningar> InstallningarKontoMomsAvstamningNavigation { get; set; }
        [InverseProperty(nameof(Installningar.KontoUtgMomsNavigation))]
        public virtual ICollection<Installningar> InstallningarKontoUtgMomsNavigation { get; set; }
        [InverseProperty("KontoNavigation")]
        public virtual ICollection<MallTransaktioner> MallTransaktioner { get; set; }
        [InverseProperty("Konto100ProcNavigation")]
        public virtual ICollection<MallVerifikat> MallVerifikat { get; set; }
        [InverseProperty("KontoNavigation")]
        public virtual ICollection<Transaktion> Transaktion { get; set; }
    }
}
