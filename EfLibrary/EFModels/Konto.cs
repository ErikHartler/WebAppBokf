using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Konto
    {
        public Konto()
        {
            InstallningarKontoFordranFromNavigations = new HashSet<Installningar>();
            InstallningarKontoFordranKundNavigations = new HashSet<Installningar>();
            InstallningarKontoFordranTomNavigations = new HashSet<Installningar>();
            InstallningarKontoIngMomsNavigations = new HashSet<Installningar>();
            InstallningarKontoIntakterFromNavigations = new HashSet<Installningar>();
            InstallningarKontoIntakterKundNavigations = new HashSet<Installningar>();
            InstallningarKontoIntakterTomNavigations = new HashSet<Installningar>();
            InstallningarKontoMomsAvstamningNavigations = new HashSet<Installningar>();
            InstallningarKontoUtgMomsNavigations = new HashSet<Installningar>();
            MallTransaktioners = new HashSet<MallTransaktioner>();
            MallVerifikats = new HashSet<MallVerifikat>();
            Transaktions = new HashSet<Transaktion>();
        }

        public string Konto1 { get; set; } = null!;
        public string? Arsredovisningsrad { get; set; }
        public string? Benamning { get; set; }
        public decimal? IbDebetKr { get; set; }
        public decimal? IbKreditKr { get; set; }
        public bool OmDebet { get; set; }
        public string? Skattekonto { get; set; }

        public virtual ICollection<Installningar> InstallningarKontoFordranFromNavigations { get; set; }
        public virtual ICollection<Installningar> InstallningarKontoFordranKundNavigations { get; set; }
        public virtual ICollection<Installningar> InstallningarKontoFordranTomNavigations { get; set; }
        public virtual ICollection<Installningar> InstallningarKontoIngMomsNavigations { get; set; }
        public virtual ICollection<Installningar> InstallningarKontoIntakterFromNavigations { get; set; }
        public virtual ICollection<Installningar> InstallningarKontoIntakterKundNavigations { get; set; }
        public virtual ICollection<Installningar> InstallningarKontoIntakterTomNavigations { get; set; }
        public virtual ICollection<Installningar> InstallningarKontoMomsAvstamningNavigations { get; set; }
        public virtual ICollection<Installningar> InstallningarKontoUtgMomsNavigations { get; set; }
        public virtual ICollection<MallTransaktioner> MallTransaktioners { get; set; }
        public virtual ICollection<MallVerifikat> MallVerifikats { get; set; }
        public virtual ICollection<Transaktion> Transaktions { get; set; }
    }
}
