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

        [System.ComponentModel.DataAnnotations.Display(Name = "Kontonummer")]
        public string Konto1 { get; set; } = null!;

        [System.ComponentModel.DataAnnotations.Display(Name = "Debetkonto?")]
        public bool OmDebet { get; set; }


#nullable enable
        [System.ComponentModel.DataAnnotations.Display(Name = "Årsredovisningsrad")]
        public string? Arsredovisningsrad { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Benämning")]
        public string? Benamning { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Ingående debet kr")]
        public decimal? IbDebetKr { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Ingående kredit kr")]
        public decimal? IbKreditKr { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Skattekonto")]
        public string? Skattekonto { get; set; }
#nullable restore
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
