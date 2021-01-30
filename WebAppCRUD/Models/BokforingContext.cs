using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppCRUD.Models
{
    public partial class BokforingContext : DbContext
    {
        public BokforingContext()
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public BokforingContext(DbContextOptions<BokforingContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Betalning> Betalning { get; set; }
        public virtual DbSet<Betalsatt> Betalsatt { get; set; }
        public virtual DbSet<Bokföringsar> Bokföringsar { get; set; }
        public virtual DbSet<Enhet> Enhet { get; set; }
        public virtual DbSet<Faktura> Faktura { get; set; }
        public virtual DbSet<Fakturarad> Fakturarad { get; set; }
        public virtual DbSet<Installningar> Installningar { get; set; }
        public virtual DbSet<KontaktpersonKund> KontaktpersonKund { get; set; }
        public virtual DbSet<KontaktpersonLeverantor> KontaktpersonLeverantor { get; set; }
        public virtual DbSet<Konto> Konto { get; set; }
        public virtual DbSet<Kostnadsbarare> Kostnadsbarare { get; set; }
        public virtual DbSet<Kund> Kund { get; set; }
        public virtual DbSet<Landskod> Landskod { get; set; }
        public virtual DbSet<LevFaktura> LevFaktura { get; set; }
        public virtual DbSet<LevFakturaRad> LevFakturaRad { get; set; }
        public virtual DbSet<Leverantor> Leverantor { get; set; }
        public virtual DbSet<MallTransaktioner> MallTransaktioner { get; set; }
        public virtual DbSet<MallVerifikat> MallVerifikat { get; set; }
        public virtual DbSet<Meny> Meny { get; set; }
        public virtual DbSet<Menyval> Menyval { get; set; }
        public virtual DbSet<MenyvalPersFunkt> MenyvalPersFunkt { get; set; }
        public virtual DbSet<MenyvalPerson> MenyvalPerson { get; set; }
        public virtual DbSet<Momsperioder> Momsperioder { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<Personalfunktion> Personalfunktion { get; set; }
        public virtual DbSet<Produkt> Produkt { get; set; }
        public virtual DbSet<Projekt> Projekt { get; set; }
        public virtual DbSet<ProjektAktivitet> ProjektAktivitet { get; set; }
        public virtual DbSet<Rapport> Rapport { get; set; }
        public virtual DbSet<RapportRad> RapportRad { get; set; }
        public virtual DbSet<Transaktion> Transaktion { get; set; }
        public virtual DbSet<Verifikation> Verifikation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-LIEU5OJ9\\SQLEXPRESS;Database=Bokforing;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Betalning>(entity =>
            {
                entity.Property(e => e.Betalsatt).IsUnicode(false);

                entity.HasOne(d => d.BetalsattNavigation)
                    .WithMany(p => p.Betalning)
                    .HasForeignKey(d => d.Betalsatt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Betalning_Betalsatt");

                entity.HasOne(d => d.KundfakturanrNavigation)
                    .WithMany(p => p.Betalning)
                    .HasForeignKey(d => d.Kundfakturanr)
                    .HasConstraintName("FK_Betalning_Faktura");

                entity.HasOne(d => d.KundnrNavigation)
                    .WithMany(p => p.Betalning)
                    .HasForeignKey(d => d.Kundnr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Betalning_Kund");

                entity.HasOne(d => d.LeverantorsnrNavigation)
                    .WithMany(p => p.Betalning)
                    .HasForeignKey(d => d.Leverantorsnr)
                    .HasConstraintName("FK_Betalning_Leverantor");

                entity.HasOne(d => d.LevfakturanrNavigation)
                    .WithMany(p => p.Betalning)
                    .HasForeignKey(d => d.Levfakturanr)
                    .HasConstraintName("FK_Betalning_LevFaktura");
            });

            modelBuilder.Entity<Betalsatt>(entity =>
            {
                entity.Property(e => e.Betalsatt1).IsUnicode(false);
            });

            modelBuilder.Entity<Bokföringsar>(entity =>
            {
                entity.Property(e => e.Bokforingsar).IsUnicode(false);
            });

            modelBuilder.Entity<Enhet>(entity =>
            {
                entity.Property(e => e.Enhet1).IsUnicode(false);
            });

            modelBuilder.Entity<Faktura>(entity =>
            {
                entity.Property(e => e.Fakturanummer).ValueGeneratedNever();

                entity.Property(e => e.Land).IsUnicode(false);

                entity.Property(e => e.Projekt).IsUnicode(false);

                entity.HasOne(d => d.KundnummerNavigation)
                    .WithMany(p => p.Faktura)
                    .HasForeignKey(d => d.Kundnummer)
                    .HasConstraintName("FK_Faktura_Kund");

                entity.HasOne(d => d.LandNavigation)
                    .WithMany(p => p.Faktura)
                    .HasForeignKey(d => d.Land)
                    .HasConstraintName("FK_Faktura_Landskod");

                entity.HasOne(d => d.ProjektNavigation)
                    .WithMany(p => p.Faktura)
                    .HasForeignKey(d => d.ProjektId)
                    .HasConstraintName("FK_Faktura_Projekt");
            });

            modelBuilder.Entity<Fakturarad>(entity =>
            {
                entity.Property(e => e.Enhet).IsUnicode(false);

                entity.HasOne(d => d.EnhetNavigation)
                    .WithMany(p => p.Fakturarad)
                    .HasForeignKey(d => d.Enhet)
                    .HasConstraintName("FK_Fakturarad_Enhet");

                entity.HasOne(d => d.FakturanummerNavigation)
                    .WithMany(p => p.Fakturarad)
                    .HasForeignKey(d => d.Fakturanummer)
                    .HasConstraintName("FK_Fakturarad_Faktura");
            });

            modelBuilder.Entity<Installningar>(entity =>
            {
                entity.Property(e => e.KontoFordranFrom).IsUnicode(false);

                entity.Property(e => e.KontoFordranKund).IsUnicode(false);

                entity.Property(e => e.KontoFordranTom).IsUnicode(false);

                entity.Property(e => e.KontoIngMoms).IsUnicode(false);

                entity.Property(e => e.KontoIntakterFrom).IsUnicode(false);

                entity.Property(e => e.KontoIntakterKund).IsUnicode(false);

                entity.Property(e => e.KontoIntakterTom).IsUnicode(false);

                entity.Property(e => e.KontoMomsAvstamning).IsUnicode(false);

                entity.Property(e => e.KontoUtgMoms).IsUnicode(false);

                entity.HasOne(d => d.KontoFordranFromNavigation)
                    .WithMany(p => p.InstallningarKontoFordranFromNavigation)
                    .HasForeignKey(d => d.KontoFordranFrom)
                    .HasConstraintName("FK_Installningar_Konto5");

                entity.HasOne(d => d.KontoFordranKundNavigation)
                    .WithMany(p => p.InstallningarKontoFordranKundNavigation)
                    .HasForeignKey(d => d.KontoFordranKund)
                    .HasConstraintName("FK_Installningar_Konto7");

                entity.HasOne(d => d.KontoFordranTomNavigation)
                    .WithMany(p => p.InstallningarKontoFordranTomNavigation)
                    .HasForeignKey(d => d.KontoFordranTom)
                    .HasConstraintName("FK_Installningar_Konto6");

                entity.HasOne(d => d.KontoIngMomsNavigation)
                    .WithMany(p => p.InstallningarKontoIngMomsNavigation)
                    .HasForeignKey(d => d.KontoIngMoms)
                    .HasConstraintName("FK_Installningar_Konto");

                entity.HasOne(d => d.KontoIntakterFromNavigation)
                    .WithMany(p => p.InstallningarKontoIntakterFromNavigation)
                    .HasForeignKey(d => d.KontoIntakterFrom)
                    .HasConstraintName("FK_Installningar_Konto3");

                entity.HasOne(d => d.KontoIntakterKundNavigation)
                    .WithMany(p => p.InstallningarKontoIntakterKundNavigation)
                    .HasForeignKey(d => d.KontoIntakterKund)
                    .HasConstraintName("FK_Installningar_Konto8");

                entity.HasOne(d => d.KontoIntakterTomNavigation)
                    .WithMany(p => p.InstallningarKontoIntakterTomNavigation)
                    .HasForeignKey(d => d.KontoIntakterTom)
                    .HasConstraintName("FK_Installningar_Konto4");

                entity.HasOne(d => d.KontoMomsAvstamningNavigation)
                    .WithMany(p => p.InstallningarKontoMomsAvstamningNavigation)
                    .HasForeignKey(d => d.KontoMomsAvstamning)
                    .HasConstraintName("FK_Installningar_Konto2");

                entity.HasOne(d => d.KontoUtgMomsNavigation)
                    .WithMany(p => p.InstallningarKontoUtgMomsNavigation)
                    .HasForeignKey(d => d.KontoUtgMoms)
                    .HasConstraintName("FK_Installningar_Konto1");
            });

            modelBuilder.Entity<KontaktpersonKund>(entity =>
            {
                entity.HasOne(d => d.KundnummerNavigation)
                    .WithMany(p => p.KontaktpersonKund)
                    .HasForeignKey(d => d.Kundnummer)
                    .HasConstraintName("FK_Kontaktperson_Kund_Kund");
            });

            modelBuilder.Entity<KontaktpersonLeverantor>(entity =>
            {
                entity.HasOne(d => d.LeverantorsnummerNavigation)
                    .WithMany(p => p.KontaktpersonLeverantor)
                    .HasForeignKey(d => d.Leverantorsnummer)
                    .HasConstraintName("FK_Kontaktperson_Leverantor_Leverantor");
            });

            modelBuilder.Entity<Konto>(entity =>
            {
                entity.Property(e => e.Konto1).IsUnicode(false);
            });

            modelBuilder.Entity<Kostnadsbarare>(entity =>
            {
                entity.Property(e => e.Kostnadsbarare1).IsUnicode(false);
            });

            modelBuilder.Entity<Kund>(entity =>
            {
                entity.Property(e => e.Kundnummer).ValueGeneratedNever();

                entity.Property(e => e.Landskod).IsUnicode(false);

                entity.HasOne(d => d.LandskodNavigation)
                    .WithMany(p => p.Kund)
                    .HasForeignKey(d => d.Landskod)
                    .HasConstraintName("FK_Kund_Landskod");
            });

            modelBuilder.Entity<Landskod>(entity =>
            {
                entity.Property(e => e.Landskod1).IsUnicode(false);
            });

            modelBuilder.Entity<LevFaktura>(entity =>
            {
                entity.Property(e => e.LevFakturanummer).ValueGeneratedNever();

                entity.HasOne(d => d.VerNrNavigation)
                    .WithMany(p => p.LevFaktura)
                    .HasForeignKey(d => d.VerNr)
                    .HasConstraintName("FK_LevFaktura_Verifikation");
            });

            modelBuilder.Entity<LevFakturaRad>(entity =>
            {
                entity.Property(e => e.Enhet).IsUnicode(false);

                entity.HasOne(d => d.EnhetNavigation)
                    .WithMany(p => p.LevFakturaRad)
                    .HasForeignKey(d => d.Enhet)
                    .HasConstraintName("FK_LevFakturaRad_Enhet");

                entity.HasOne(d => d.LevFakturanummerNavigation)
                    .WithMany(p => p.LevFakturaRad)
                    .HasForeignKey(d => d.LevFakturanummer)
                    .HasConstraintName("FK_LevFakturaRad_LevFaktura");
            });

            modelBuilder.Entity<Leverantor>(entity =>
            {
                entity.Property(e => e.Leverantorsnummer).ValueGeneratedNever();

                entity.Property(e => e.Land).IsUnicode(false);

                entity.HasOne(d => d.LandNavigation)
                    .WithMany(p => p.Leverantor)
                    .HasForeignKey(d => d.Land)
                    .HasConstraintName("FK_Leverantor_Landskod");
            });

            modelBuilder.Entity<MallTransaktioner>(entity =>
            {
                entity.Property(e => e.Konto).IsUnicode(false);

                entity.Property(e => e.Kortkod).IsUnicode(false);

                entity.Property(e => e.Kostnadsbarare).IsUnicode(false);

                entity.HasOne(d => d.KontoNavigation)
                    .WithMany(p => p.MallTransaktioner)
                    .HasForeignKey(d => d.Konto)
                    .HasConstraintName("FK_MallTransaktioner_Konto");

                entity.HasOne(d => d.KortkodNavigation)
                    .WithMany(p => p.MallTransaktioner)
                    .HasForeignKey(d => d.Kortkod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MallTransaktioner_MallVerifikat");

                entity.HasOne(d => d.KostnadsbarareNavigation)
                    .WithMany(p => p.MallTransaktioner)
                    .HasForeignKey(d => d.Kostnadsbarare)
                    .HasConstraintName("FK_MallTransaktioner_Kostnadsbarare");
            });

            modelBuilder.Entity<MallVerifikat>(entity =>
            {
                entity.Property(e => e.Kortkod).IsUnicode(false);

                entity.Property(e => e.Konto100Proc).IsUnicode(false);

                entity.HasOne(d => d.Konto100ProcNavigation)
                    .WithMany(p => p.MallVerifikat)
                    .HasForeignKey(d => d.Konto100Proc)
                    .HasConstraintName("FK_MallVerifikat_Konto");
            });

            modelBuilder.Entity<Meny>(entity =>
            {
                entity.Property(e => e.Meny1).IsUnicode(false);
            });

            modelBuilder.Entity<Menyval>(entity =>
            {
                entity.Property(e => e.Menyvalsnr).ValueGeneratedNever();

                entity.Property(e => e.Meny).IsUnicode(false);

                entity.HasOne(d => d.MenyNavigation)
                    .WithMany(p => p.Menyval)
                    .HasForeignKey(d => d.Meny)
                    .HasConstraintName("FK_Menyval_Meny");
            });

            modelBuilder.Entity<MenyvalPersFunkt>(entity =>
            {
                entity.Property(e => e.Personalfunktion).IsUnicode(false);

                entity.HasOne(d => d.MenyvalsnummerNavigation)
                    .WithMany(p => p.MenyvalPersFunkt)
                    .HasForeignKey(d => d.Menyvalsnummer)
                    .HasConstraintName("FK_Menyval_Pers_funkt_Menyval");

                entity.HasOne(d => d.PersonalfunktionNavigation)
                    .WithMany(p => p.MenyvalPersFunkt)
                    .HasForeignKey(d => d.Personalfunktion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menyval_Pers_funkt_Personalfunktion");
            });

            modelBuilder.Entity<MenyvalPerson>(entity =>
            {
                entity.Property(e => e.Anvandare).IsUnicode(false);

                entity.HasOne(d => d.AnvandareNavigation)
                    .WithMany(p => p.MenyvalPerson)
                    .HasForeignKey(d => d.Anvandare)
                    .HasConstraintName("FK_Menyval_Person_Personal");

                entity.HasOne(d => d.MenyvalsnummerNavigation)
                    .WithMany(p => p.MenyvalPerson)
                    .HasForeignKey(d => d.Menyvalsnummer)
                    .HasConstraintName("FK_Menyval_Person_Menyval");
            });

            modelBuilder.Entity<Momsperioder>(entity =>
            {
                entity.HasOne(d => d.VerifikationsnrNavigation)
                    .WithMany(p => p.Momsperioder)
                    .HasForeignKey(d => d.Verifikationsnr)
                    .HasConstraintName("FK_Momsperioder_Verifikation");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.Property(e => e.Signatur).IsUnicode(false);

                entity.Property(e => e.Personalfunktion).IsUnicode(false);

                entity.HasOne(d => d.PersonalfunktionNavigation)
                    .WithMany(p => p.Personal)
                    .HasForeignKey(d => d.Personalfunktion)
                    .HasConstraintName("FK_Personal_Personalfunktion");
            });

            modelBuilder.Entity<Personalfunktion>(entity =>
            {
                entity.Property(e => e.Personalfunktion1).IsUnicode(false);
            });

            modelBuilder.Entity<Produkt>(entity =>
            {
                entity.Property(e => e.ProduktTjanst).IsUnicode(false);

                entity.Property(e => e.Enhet).IsUnicode(false);

                entity.HasOne(d => d.EnhetNavigation)
                    .WithMany(p => p.Produkt)
                    .HasForeignKey(d => d.Enhet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produkt_Enhet");
            });

            modelBuilder.Entity<Projekt>(entity =>
            {
                entity.Property(e => e.Projektnr).ValueGeneratedNever();

                entity.HasOne(d => d.KundnrNavigation)
                    .WithMany(p => p.Projekt)
                    .HasForeignKey(d => d.Kundnr)
                    .HasConstraintName("FK_Projekt_Kund");
            });

            modelBuilder.Entity<ProjektAktivitet>(entity =>
            {
                entity.HasOne(d => d.LeverantorsnummerNavigation)
                    .WithMany(p => p.ProjektAktivitet)
                    .HasForeignKey(d => d.Leverantorsnummer)
                    .HasConstraintName("FK_ProjektAktivitet_Leverantor");

                entity.HasOne(d => d.ProjektnummerNavigation)
                    .WithMany(p => p.ProjektAktivitet)
                    .HasForeignKey(d => d.Projektnummer)
                    .HasConstraintName("FK_ProjektAktivitet_Projekt");
            });

            modelBuilder.Entity<Rapport>(entity =>
            {
                entity.Property(e => e.Rapport1).IsUnicode(false);
            });

            modelBuilder.Entity<RapportRad>(entity =>
            {
                entity.Property(e => e.KontoFrom).IsUnicode(false);

                entity.Property(e => e.KontoTom).IsUnicode(false);

                entity.Property(e => e.Rapport).IsUnicode(false);

                entity.HasOne(d => d.RapportNavigation)
                    .WithMany(p => p.RapportRad)
                    .HasForeignKey(d => d.Rapport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RapportRad_Rapport");
            });

            modelBuilder.Entity<Transaktion>(entity =>
            {
                entity.Property(e => e.Konto).IsUnicode(false);

                entity.Property(e => e.Kostnadsbarare).IsUnicode(false);

                entity.HasOne(d => d.KontoNavigation)
                    .WithMany(p => p.Transaktion)
                    .HasForeignKey(d => d.Konto)
                    .HasConstraintName("FK_Transaktion_Konto");

                entity.HasOne(d => d.KostnadsbarareNavigation)
                    .WithMany(p => p.Transaktion)
                    .HasForeignKey(d => d.Kostnadsbarare)
                    .HasConstraintName("FK_Transaktion_Kostnadsbarare");

                entity.HasOne(d => d.VerifikationNavigation)
                    .WithMany(p => p.Transaktion)
                    .HasForeignKey(d => d.Verifikation)
                    .HasConstraintName("FK_Transaktion_Verifikation");
            });

            modelBuilder.Entity<Verifikation>(entity =>
            {
                entity.Property(e => e.Verifikation1).ValueGeneratedNever();

                entity.HasOne(d => d.FakturanrNavigation)
                    .WithMany(p => p.Verifikation)
                    .HasForeignKey(d => d.Fakturanr)
                    .HasConstraintName("FK_Verifikation_Faktura");

                entity.HasOne(d => d.KundnummerNavigation)
                    .WithMany(p => p.Verifikation)
                    .HasForeignKey(d => d.Kundnummer)
                    .HasConstraintName("FK_Verifikation_Kund");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
