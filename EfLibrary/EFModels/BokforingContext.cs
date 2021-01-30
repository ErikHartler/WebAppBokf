using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EfLibrary.EFModels
{
    public partial class BokforingContext : DbContext
    {
        public BokforingContext()
        {
            ChangeTracker.LazyLoadingEnabled = false;
            //ChangeTracker.AutoDetectChangesEnabled= false;
        }

        public BokforingContext(DbContextOptions<BokforingContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Betalning> Betalnings { get; set; }
        public virtual DbSet<Betalsatt> Betalsatts { get; set; }
        public virtual DbSet<Bokföringsar> Bokföringsars { get; set; }
        public virtual DbSet<Enhet> Enhets { get; set; }
        public virtual DbSet<Faktura> Fakturas { get; set; }
        public virtual DbSet<Fakturarad> Fakturarads { get; set; }
        public virtual DbSet<Installningar> Installningars { get; set; }
        public virtual DbSet<KontaktpersonKund> KontaktpersonKunds { get; set; }
        public virtual DbSet<KontaktpersonLeverantor> KontaktpersonLeverantors { get; set; }
        public virtual DbSet<Konto> Kontos { get; set; }
        public virtual DbSet<Kostnadsbarare> Kostnadsbarares { get; set; }
        public virtual DbSet<Kund> Kunds { get; set; }
        public virtual DbSet<Landskod> Landskods { get; set; }
        public virtual DbSet<LevFaktura> LevFakturas { get; set; }
        public virtual DbSet<LevFakturaRad> LevFakturaRads { get; set; }
        public virtual DbSet<Leverantor> Leverantors { get; set; }
        public virtual DbSet<MallTransaktioner> MallTransaktioners { get; set; }
        public virtual DbSet<MallVerifikat> MallVerifikats { get; set; }
        public virtual DbSet<Meny> Menies { get; set; }
        public virtual DbSet<Menyval> Menyvals { get; set; }
        public virtual DbSet<MenyvalPersFunkt> MenyvalPersFunkts { get; set; }
        public virtual DbSet<MenyvalPerson> MenyvalPeople { get; set; }
        public virtual DbSet<Momsperioder> Momsperioders { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<Personalfunktion> Personalfunktions { get; set; }
        public virtual DbSet<Produkt> Produkts { get; set; }
        public virtual DbSet<Projekt> Projekts { get; set; }
        public virtual DbSet<ProjektAktivitet> ProjektAktivitets { get; set; }
        public virtual DbSet<Rapport> Rapports { get; set; }
        public virtual DbSet<RapportRad> RapportRads { get; set; }
        public virtual DbSet<Transaktion> Transaktions { get; set; }
        public virtual DbSet<Verifikation> Verifikations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-LIEU5OJ9\\SQLEXPRESS;Database=Bokforing;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Betalning>(entity =>
            {
                entity.Property(e => e.Betalsatt).IsUnicode(false);

                entity.HasOne(d => d.BetalsattNavigation)
                    .WithMany(p => p.Betalnings)
                    .HasForeignKey(d => d.Betalsatt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Betalning_Betalsatt");

                entity.HasOne(d => d.KundfakturanrNavigation)
                    .WithMany(p => p.Betalnings)
                    .HasForeignKey(d => d.Kundfakturanr)
                    .HasConstraintName("FK_Betalning_Faktura");

                entity.HasOne(d => d.KundnrNavigation)
                    .WithMany(p => p.Betalnings)
                    .HasForeignKey(d => d.Kundnr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Betalning_Kund");

                entity.HasOne(d => d.LeverantorsnrNavigation)
                    .WithMany(p => p.Betalnings)
                    .HasForeignKey(d => d.Leverantorsnr)
                    .HasConstraintName("FK_Betalning_Leverantor");
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

                entity.Property(e => e.Projekt).IsUnicode(false);

                entity.HasOne(d => d.KundnummerNavigation)
                    .WithMany(p => p.Fakturas)
                    .HasForeignKey(d => d.Kundnummer)
                    .HasConstraintName("FK_Faktura_Kund");
            });

            modelBuilder.Entity<Fakturarad>(entity =>
            {
                entity.Property(e => e.Enhet).IsUnicode(false);

                entity.HasOne(d => d.EnhetNavigation)
                    .WithMany(p => p.Fakturarads)
                    .HasForeignKey(d => d.Enhet)
                    .HasConstraintName("FK_Fakturarad_Enhet");

                entity.HasOne(d => d.FakturanummerNavigation)
                    .WithMany(p => p.Fakturarads)
                    .HasForeignKey(d => d.Fakturanummer)
                    .HasConstraintName("FK_Fakturarad_Faktura");
            });

            modelBuilder.Entity<KontaktpersonKund>(entity =>
            {
                entity.HasOne(d => d.KundnummerNavigation)
                    .WithMany(p => p.KontaktpersonKunds)
                    .HasForeignKey(d => d.Kundnummer)
                    .HasConstraintName("FK_Kontaktperson_Kund_Kund");
            });

            modelBuilder.Entity<KontaktpersonLeverantor>(entity =>
            {
                entity.HasOne(d => d.LeverantorsnummerNavigation)
                    .WithMany(p => p.KontaktpersonLeverantors)
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
            });

            modelBuilder.Entity<Landskod>(entity =>
            {
                entity.Property(e => e.Landskod1).IsUnicode(false);
            });

            modelBuilder.Entity<LevFaktura>(entity =>
            {
                entity.Property(e => e.LevFakturanummer).ValueGeneratedNever();

                entity.HasOne(d => d.VerNrNavigation)
                    .WithMany(p => p.LevFakturas)
                    .HasForeignKey(d => d.VerNr)
                    .HasConstraintName("FK_LevFaktura_Verifikation");
            });

            modelBuilder.Entity<LevFakturaRad>(entity =>
            {
                entity.HasOne(d => d.LevFakturanummerNavigation)
                    .WithMany(p => p.LevFakturaRads)
                    .HasForeignKey(d => d.LevFakturanummer)
                    .HasConstraintName("FK_LevFakturaRad_LevFaktura");
            });

            modelBuilder.Entity<Leverantor>(entity =>
            {
                entity.Property(e => e.Leverantorsnummer).ValueGeneratedNever();

                entity.Property(e => e.Land).IsUnicode(false);

                entity.HasOne(d => d.LandNavigation)
                    .WithMany(p => p.Leverantors)
                    .HasForeignKey(d => d.Land)
                    .HasConstraintName("FK_Leverantor_Landskod");
            });

            modelBuilder.Entity<MallTransaktioner>(entity =>
            {
                entity.Property(e => e.Konto).IsUnicode(false);

                entity.Property(e => e.Kortkod).IsUnicode(false);

                entity.Property(e => e.Kostnadsbarare).IsUnicode(false);

                entity.HasOne(d => d.KortkodNavigation)
                    .WithMany(p => p.MallTransaktioners)
                    .HasForeignKey(d => d.Kortkod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MallTransaktioner_MallVerifikat");
            });

            modelBuilder.Entity<MallVerifikat>(entity =>
            {
                entity.Property(e => e.Kortkod).IsUnicode(false);
            });

            modelBuilder.Entity<Meny>(entity =>
            {
                entity.Property(e => e.Meny1).IsUnicode(false);
            });

            modelBuilder.Entity<Menyval>(entity =>
            {
                entity.Property(e => e.Menyvalsnr).ValueGeneratedNever();
            });

            modelBuilder.Entity<MenyvalPersFunkt>(entity =>
            {
                entity.Property(e => e.Personalfunktion).IsUnicode(false);

                entity.HasOne(d => d.MenyvalsnummerNavigation)
                    .WithMany(p => p.MenyvalPersFunkts)
                    .HasForeignKey(d => d.Menyvalsnummer)
                    .HasConstraintName("FK_Menyval_Pers_funkt_Menyval");

                entity.HasOne(d => d.PersonalfunktionNavigation)
                    .WithMany(p => p.MenyvalPersFunkts)
                    .HasForeignKey(d => d.Personalfunktion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menyval_Pers_funkt_Personalfunktion");
            });

            modelBuilder.Entity<MenyvalPerson>(entity =>
            {
                entity.Property(e => e.Anvandare).IsUnicode(false);

                entity.HasOne(d => d.MenyvalsnummerNavigation)
                    .WithMany(p => p.MenyvalPeople)
                    .HasForeignKey(d => d.Menyvalsnummer)
                    .HasConstraintName("FK_Menyval_Person_Menyval");
            });

            modelBuilder.Entity<Momsperioder>(entity =>
            {
                entity.HasOne(d => d.VerifikationsnrNavigation)
                    .WithMany(p => p.Momsperioders)
                    .HasForeignKey(d => d.Verifikationsnr)
                    .HasConstraintName("FK_Momsperioder_Verifikation");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.Property(e => e.Signatur).IsUnicode(false);
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
                    .WithMany(p => p.Produkts)
                    .HasForeignKey(d => d.Enhet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produkt_Enhet");
            });

            modelBuilder.Entity<Projekt>(entity =>
            {
                entity.Property(e => e.Projektnr).ValueGeneratedNever();
            });

            modelBuilder.Entity<ProjektAktivitet>(entity =>
            {
                entity.HasOne(d => d.LeverantorsnummerNavigation)
                    .WithMany(p => p.ProjektAktivitets)
                    .HasForeignKey(d => d.Leverantorsnummer)
                    .HasConstraintName("FK_ProjektAktivitet_Leverantor");

                entity.HasOne(d => d.ProjektnummerNavigation)
                    .WithMany(p => p.ProjektAktivitets)
                    .HasForeignKey(d => d.Projektnummer)
                    .HasConstraintName("FK_ProjektAktivitet_Projekt");
            });

            modelBuilder.Entity<Rapport>(entity =>
            {
                entity.Property(e => e.Rapport1).IsUnicode(false);
            });

            modelBuilder.Entity<RapportRad>(entity =>
            {
                entity.Property(e => e.Rapport).IsUnicode(false);

                entity.HasOne(d => d.RapportNavigation)
                    .WithMany(p => p.RapportRads)
                    .HasForeignKey(d => d.Rapport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RapportRad_Rapport");
            });

            modelBuilder.Entity<Transaktion>(entity =>
            {
                entity.Property(e => e.Konto).IsUnicode(false);

                entity.Property(e => e.Kostnadsbarare).IsUnicode(false);

                entity.HasOne(d => d.VerifikationNavigation)
                    .WithMany(p => p.Transaktions)
                    .HasForeignKey(d => d.Verifikation)
                    .HasConstraintName("FK_Transaktion_Verifikation");
            });

            modelBuilder.Entity<Verifikation>(entity =>
            {
                entity.Property(e => e.Verifikation1).ValueGeneratedNever();

                entity.HasOne(d => d.FakturanrNavigation)
                    .WithMany(p => p.Verifikations)
                    .HasForeignKey(d => d.Fakturanr)
                    .HasConstraintName("FK_Verifikation_Faktura");

                entity.HasOne(d => d.KundnummerNavigation)
                    .WithMany(p => p.Verifikations)
                    .HasForeignKey(d => d.Kundnummer)
                    .HasConstraintName("FK_Verifikation_Kund");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
