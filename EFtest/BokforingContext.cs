using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFtest
{
    public partial class BokforingContext : DbContext
    {
        public BokforingContext()
        {
        }

        public BokforingContext(DbContextOptions<BokforingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Betalning> Betalnings { get; set; } = null!;
        public virtual DbSet<Betalsatt> Betalsatts { get; set; } = null!;
        public virtual DbSet<Bokföringsar> Bokföringsars { get; set; } = null!;
        public virtual DbSet<Enhet> Enhets { get; set; } = null!;
        public virtual DbSet<Faktura> Fakturas { get; set; } = null!;
        public virtual DbSet<Fakturarad> Fakturarads { get; set; } = null!;
        public virtual DbSet<Installningar> Installningars { get; set; } = null!;
        public virtual DbSet<KontaktpersonKund> KontaktpersonKunds { get; set; } = null!;
        public virtual DbSet<KontaktpersonLeverantor> KontaktpersonLeverantors { get; set; } = null!;
        public virtual DbSet<Konto> Kontos { get; set; } = null!;
        public virtual DbSet<Kostnadsbarare> Kostnadsbarares { get; set; } = null!;
        public virtual DbSet<Kund> Kunds { get; set; } = null!;
        public virtual DbSet<Landskod> Landskods { get; set; } = null!;
        public virtual DbSet<LevFaktura> LevFakturas { get; set; } = null!;
        public virtual DbSet<LevFakturaRad> LevFakturaRads { get; set; } = null!;
        public virtual DbSet<Leverantor> Leverantors { get; set; } = null!;
        public virtual DbSet<MallTransaktioner> MallTransaktioners { get; set; } = null!;
        public virtual DbSet<MallVerifikat> MallVerifikats { get; set; } = null!;
        public virtual DbSet<Meny> Menies { get; set; } = null!;
        public virtual DbSet<Menyval> Menyvals { get; set; } = null!;
        public virtual DbSet<MenyvalPersFunkt> MenyvalPersFunkts { get; set; } = null!;
        public virtual DbSet<MenyvalPerson> MenyvalPeople { get; set; } = null!;
        public virtual DbSet<Momsperioder> Momsperioders { get; set; } = null!;
        public virtual DbSet<Myview> Myviews { get; set; } = null!;
        public virtual DbSet<Personal> Personals { get; set; } = null!;
        public virtual DbSet<Personalfunktion> Personalfunktions { get; set; } = null!;
        public virtual DbSet<Produkt> Produkts { get; set; } = null!;
        public virtual DbSet<Projekt> Projekts { get; set; } = null!;
        public virtual DbSet<ProjektAktivitet> ProjektAktivitets { get; set; } = null!;
        public virtual DbSet<Rapport> Rapports { get; set; } = null!;
        public virtual DbSet<RapportRad> RapportRads { get; set; } = null!;
        public virtual DbSet<Transaktion> Transaktions { get; set; } = null!;
        public virtual DbSet<Verifikation> Verifikations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=Bokforing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Betalning>(entity =>
            {
                entity.ToTable("Betalning");

                entity.HasIndex(e => e.Betalsatt, "IX_Betalning_Betalsatt");

                entity.HasIndex(e => e.Kundfakturanr, "IX_Betalning_Kundfakturanr");

                entity.HasIndex(e => e.Kundnr, "IX_Betalning_Kundnr");

                entity.HasIndex(e => e.Leverantorsnr, "IX_Betalning_Leverantorsnr");

                entity.HasIndex(e => e.Levfakturanr, "IX_Betalning_Levfakturanr");

                entity.Property(e => e.Betalsatt)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Inbetalning).HasColumnType("money");

                entity.Property(e => e.RegistreradAv).HasMaxLength(10);

                entity.Property(e => e.Registreringsdatum).HasColumnType("datetime");

                entity.Property(e => e.Transdatum).HasColumnType("datetime");

                entity.Property(e => e.Utbetalning).HasColumnType("money");

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

                entity.HasOne(d => d.LevfakturanrNavigation)
                    .WithMany(p => p.Betalnings)
                    .HasForeignKey(d => d.Levfakturanr)
                    .HasConstraintName("FK_Betalning_LevFaktura");
            });

            modelBuilder.Entity<Betalsatt>(entity =>
            {
                entity.HasKey(e => e.Betalsatt1);

                entity.ToTable("Betalsatt");

                entity.Property(e => e.Betalsatt1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Betalsatt");

                entity.Property(e => e.Beskrivning).HasMaxLength(50);
            });

            modelBuilder.Entity<Bokföringsar>(entity =>
            {
                entity.HasKey(e => e.Bokforingsar);

                entity.ToTable("Bokföringsar");

                entity.Property(e => e.Bokforingsar)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Slut).HasColumnType("datetime");

                entity.Property(e => e.Start).HasColumnType("datetime");
            });

            modelBuilder.Entity<Enhet>(entity =>
            {
                entity.HasKey(e => e.Enhet1);

                entity.ToTable("Enhet");

                entity.Property(e => e.Enhet1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Enhet");

                entity.Property(e => e.Beskrivning).HasMaxLength(50);
            });

            modelBuilder.Entity<Faktura>(entity =>
            {
                entity.HasKey(e => e.Fakturanummer);

                entity.ToTable("Faktura");

                entity.HasIndex(e => e.Kundnummer, "IX_Faktura_Kundnummer");

                entity.HasIndex(e => e.Land, "IX_Faktura_Land");

                entity.HasIndex(e => e.ProjektId, "IX_Faktura_ProjektId");

                entity.Property(e => e.Fakturanummer).ValueGeneratedNever();

                entity.Property(e => e.BeloppExklMoms)
                    .HasColumnType("money")
                    .HasColumnName("Belopp Exkl moms");

                entity.Property(e => e.BeloppInklMomsKr)
                    .HasColumnType("money")
                    .HasColumnName("Belopp Inkl Moms Kr");

                entity.Property(e => e.Betaldatum).HasColumnType("datetime");

                entity.Property(e => e.BetaltKr)
                    .HasColumnType("money")
                    .HasColumnName("Betalt Kr");

                entity.Property(e => e.Box).HasMaxLength(50);

                entity.Property(e => e.Coadress)
                    .HasMaxLength(255)
                    .HasColumnName("COAdress");

                entity.Property(e => e.ErRefEfterN).HasMaxLength(255);

                entity.Property(e => e.ErRefForN).HasMaxLength(255);

                entity.Property(e => e.Fakturadatum).HasColumnType("datetime");

                entity.Property(e => e.Forfallodatum).HasColumnType("datetime");

                entity.Property(e => e.Inkasso).HasMaxLength(255);

                entity.Property(e => e.Kommentar).HasMaxLength(255);

                entity.Property(e => e.Kundnamn).HasMaxLength(50);

                entity.Property(e => e.Land)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.MomsKr)
                    .HasColumnType("money")
                    .HasColumnName("Moms Kr");

                entity.Property(e => e.Ort).HasMaxLength(50);

                entity.Property(e => e.Paminnelse1).HasMaxLength(255);

                entity.Property(e => e.Paminnelse2).HasMaxLength(255);

                entity.Property(e => e.Postnummer).HasMaxLength(20);

                entity.Property(e => e.Projekt)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.UtestaendeFordr).HasColumnType("money");

                entity.Property(e => e.Utskriftsdatum).HasColumnType("datetime");

                entity.Property(e => e.VarReferens).HasMaxLength(255);

                entity.Property(e => e.Villkor).HasMaxLength(255);

                entity.HasOne(d => d.KundnummerNavigation)
                    .WithMany(p => p.Fakturas)
                    .HasForeignKey(d => d.Kundnummer)
                    .HasConstraintName("FK_Faktura_Kund");

                entity.HasOne(d => d.LandNavigation)
                    .WithMany(p => p.Fakturas)
                    .HasForeignKey(d => d.Land)
                    .HasConstraintName("FK_Faktura_Landskod");

                entity.HasOne(d => d.ProjektNavigation)
                    .WithMany(p => p.Fakturas)
                    .HasForeignKey(d => d.ProjektId)
                    .HasConstraintName("FK_Faktura_Projekt");
            });

            modelBuilder.Entity<Fakturarad>(entity =>
            {
                entity.ToTable("Fakturarad");

                entity.HasIndex(e => e.Enhet, "IX_Fakturarad_Enhet");

                entity.HasIndex(e => e.Fakturanummer, "IX_Fakturarad_Fakturanummer");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Enhetspris).HasColumnType("money");

                entity.Property(e => e.ProduktTjanst)
                    .HasMaxLength(50)
                    .HasColumnName("Produkt/Tjanst");

                entity.Property(e => e.SummaKr)
                    .HasColumnType("money")
                    .HasColumnName("Summa Kr");

                entity.HasOne(d => d.EnhetNavigation)
                    .WithMany(p => p.Fakturarads)
                    .HasForeignKey(d => d.Enhet)
                    .HasConstraintName("FK_Fakturarad_Enhet");

                entity.HasOne(d => d.FakturanummerNavigation)
                    .WithMany(p => p.Fakturarads)
                    .HasForeignKey(d => d.Fakturanummer)
                    .HasConstraintName("FK_Fakturarad_Faktura");
            });

            modelBuilder.Entity<Installningar>(entity =>
            {
                entity.ToTable("Installningar");

                entity.HasIndex(e => e.KontoFordranFrom, "IX_Installningar_KontoFordranFrom");

                entity.HasIndex(e => e.KontoFordranKund, "IX_Installningar_KontoFordranKund");

                entity.HasIndex(e => e.KontoFordranTom, "IX_Installningar_KontoFordranTom");

                entity.HasIndex(e => e.KontoIngMoms, "IX_Installningar_KontoIngMoms");

                entity.HasIndex(e => e.KontoIntakterFrom, "IX_Installningar_KontoIntakterFrom");

                entity.HasIndex(e => e.KontoIntakterKund, "IX_Installningar_KontoIntakterKund");

                entity.HasIndex(e => e.KontoIntakterTom, "IX_Installningar_KontoIntakterTom");

                entity.HasIndex(e => e.KontoMomsAvstamning, "IX_Installningar_KontoMomsAvstamning");

                entity.HasIndex(e => e.KontoUtgMoms, "IX_Installningar_KontoUtgMoms");

                entity.Property(e => e.BokforingsarFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("Bokforingsar from");

                entity.Property(e => e.BokforingsarTom)
                    .HasColumnType("datetime")
                    .HasColumnName("Bokforingsar tom");

                entity.Property(e => e.Bolagsnamn).HasMaxLength(50);

                entity.Property(e => e.KontoFordranFrom)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KontoFordranKund)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KontoFordranTom)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KontoIngMoms)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KontoIntakterFrom)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KontoIntakterKund)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KontoIntakterTom)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KontoMomsAvstamning)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KontoUtgMoms)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Organisationsnr).HasMaxLength(50);

                entity.HasOne(d => d.KontoFordranFromNavigation)
                    .WithMany(p => p.InstallningarKontoFordranFromNavigations)
                    .HasForeignKey(d => d.KontoFordranFrom)
                    .HasConstraintName("FK_Installningar_Konto5");

                entity.HasOne(d => d.KontoFordranKundNavigation)
                    .WithMany(p => p.InstallningarKontoFordranKundNavigations)
                    .HasForeignKey(d => d.KontoFordranKund)
                    .HasConstraintName("FK_Installningar_Konto7");

                entity.HasOne(d => d.KontoFordranTomNavigation)
                    .WithMany(p => p.InstallningarKontoFordranTomNavigations)
                    .HasForeignKey(d => d.KontoFordranTom)
                    .HasConstraintName("FK_Installningar_Konto6");

                entity.HasOne(d => d.KontoIngMomsNavigation)
                    .WithMany(p => p.InstallningarKontoIngMomsNavigations)
                    .HasForeignKey(d => d.KontoIngMoms)
                    .HasConstraintName("FK_Installningar_Konto");

                entity.HasOne(d => d.KontoIntakterFromNavigation)
                    .WithMany(p => p.InstallningarKontoIntakterFromNavigations)
                    .HasForeignKey(d => d.KontoIntakterFrom)
                    .HasConstraintName("FK_Installningar_Konto3");

                entity.HasOne(d => d.KontoIntakterKundNavigation)
                    .WithMany(p => p.InstallningarKontoIntakterKundNavigations)
                    .HasForeignKey(d => d.KontoIntakterKund)
                    .HasConstraintName("FK_Installningar_Konto8");

                entity.HasOne(d => d.KontoIntakterTomNavigation)
                    .WithMany(p => p.InstallningarKontoIntakterTomNavigations)
                    .HasForeignKey(d => d.KontoIntakterTom)
                    .HasConstraintName("FK_Installningar_Konto4");

                entity.HasOne(d => d.KontoMomsAvstamningNavigation)
                    .WithMany(p => p.InstallningarKontoMomsAvstamningNavigations)
                    .HasForeignKey(d => d.KontoMomsAvstamning)
                    .HasConstraintName("FK_Installningar_Konto2");

                entity.HasOne(d => d.KontoUtgMomsNavigation)
                    .WithMany(p => p.InstallningarKontoUtgMomsNavigations)
                    .HasForeignKey(d => d.KontoUtgMoms)
                    .HasConstraintName("FK_Installningar_Konto1");
            });

            modelBuilder.Entity<KontaktpersonKund>(entity =>
            {
                entity.ToTable("Kontaktperson_Kund");

                entity.HasIndex(e => e.Kundnummer, "IX_Kontaktperson_Kund_Kundnummer");

                entity.Property(e => e.Efternamn).HasMaxLength(30);

                entity.Property(e => e.Fornamn).HasMaxLength(30);

                entity.Property(e => e.TelefonDirekt).HasMaxLength(255);

                entity.Property(e => e.TelefonHem).HasMaxLength(255);

                entity.Property(e => e.TelefonMobil).HasMaxLength(255);

                entity.HasOne(d => d.KundnummerNavigation)
                    .WithMany(p => p.KontaktpersonKunds)
                    .HasForeignKey(d => d.Kundnummer)
                    .HasConstraintName("FK_Kontaktperson_Kund_Kund");
            });

            modelBuilder.Entity<KontaktpersonLeverantor>(entity =>
            {
                entity.ToTable("Kontaktperson_Leverantor");

                entity.HasIndex(e => e.Leverantorsnummer, "IX_Kontaktperson_Leverantor_Leverantorsnummer");

                entity.Property(e => e.Efternamn).HasMaxLength(30);

                entity.Property(e => e.Fornamn).HasMaxLength(30);

                entity.Property(e => e.TelefonDirekt).HasMaxLength(255);

                entity.Property(e => e.TelefonHem).HasMaxLength(255);

                entity.Property(e => e.TelefonMobil).HasMaxLength(255);

                entity.HasOne(d => d.LeverantorsnummerNavigation)
                    .WithMany(p => p.KontaktpersonLeverantors)
                    .HasForeignKey(d => d.Leverantorsnummer)
                    .HasConstraintName("FK_Kontaktperson_Leverantor_Leverantor");
            });

            modelBuilder.Entity<Konto>(entity =>
            {
                entity.HasKey(e => e.Konto1);

                entity.ToTable("Konto");

                entity.Property(e => e.Konto1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Konto");

                entity.Property(e => e.Arsredovisningsrad)
                    .HasMaxLength(255)
                    .HasColumnName("arsredovisningsrad");

                entity.Property(e => e.Benamning).HasMaxLength(255);

                entity.Property(e => e.IbDebetKr)
                    .HasColumnType("money")
                    .HasColumnName("IB Debet Kr");

                entity.Property(e => e.IbKreditKr)
                    .HasColumnType("money")
                    .HasColumnName("IB Kredit Kr");

                entity.Property(e => e.Skattekonto).HasMaxLength(255);
            });

            modelBuilder.Entity<Kostnadsbarare>(entity =>
            {
                entity.HasKey(e => e.Kostnadsbarare1);

                entity.ToTable("Kostnadsbarare");

                entity.Property(e => e.Kostnadsbarare1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Kostnadsbarare");

                entity.Property(e => e.Beskrivning).HasMaxLength(50);
            });

            modelBuilder.Entity<Kund>(entity =>
            {
                entity.HasKey(e => e.Kundnummer);

                entity.ToTable("Kund");

                entity.HasIndex(e => e.Landskod, "IX_Kund_Landskod");

                entity.Property(e => e.Kundnummer).ValueGeneratedNever();

                entity.Property(e => e.Box).HasMaxLength(50);

                entity.Property(e => e.Ibkredit)
                    .HasColumnType("money")
                    .HasColumnName("IBKredit");

                entity.Property(e => e.Kommentar).HasMaxLength(255);

                entity.Property(e => e.KontPersEfternamn)
                    .HasMaxLength(30)
                    .HasColumnName("Kont PersEfternamn");

                entity.Property(e => e.KontPersFornamn)
                    .HasMaxLength(30)
                    .HasColumnName("Kont Pers Fornamn");

                entity.Property(e => e.Kundnamn).HasMaxLength(50);

                entity.Property(e => e.Landskod)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Ort).HasMaxLength(50);

                entity.Property(e => e.Postnummer).HasMaxLength(20);

                entity.Property(e => e.Telefax).HasMaxLength(255);

                entity.Property(e => e.Telefon).HasMaxLength(255);

                entity.Property(e => e.Villkor).HasMaxLength(255);

                entity.HasOne(d => d.LandskodNavigation)
                    .WithMany(p => p.Kunds)
                    .HasForeignKey(d => d.Landskod)
                    .HasConstraintName("FK_Kund_Landskod");
            });

            modelBuilder.Entity<Landskod>(entity =>
            {
                entity.HasKey(e => e.Landskod1);

                entity.ToTable("Landskod");

                entity.Property(e => e.Landskod1)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Landskod");

                entity.Property(e => e.Land).HasMaxLength(50);
            });

            modelBuilder.Entity<LevFaktura>(entity =>
            {
                entity.HasKey(e => e.LevFakturanummer);

                entity.ToTable("LevFaktura");

                entity.HasIndex(e => e.VerNr, "IX_LevFaktura_VerNr");

                entity.Property(e => e.LevFakturanummer).ValueGeneratedNever();

                entity.Property(e => e.BeloppExklMoms)
                    .HasColumnType("money")
                    .HasColumnName("Belopp Exkl moms");

                entity.Property(e => e.BeloppInklMomsKr)
                    .HasColumnType("money")
                    .HasColumnName("Belopp Inkl Moms Kr");

                entity.Property(e => e.Betaldatum).HasColumnType("datetime");

                entity.Property(e => e.BetaltKr)
                    .HasColumnType("money")
                    .HasColumnName("Betalt Kr");

                entity.Property(e => e.ErRefEfterN).HasMaxLength(255);

                entity.Property(e => e.ErRefForN).HasMaxLength(255);

                entity.Property(e => e.Fakturadatum).HasColumnType("datetime");

                entity.Property(e => e.Forfallodatum).HasColumnType("datetime");

                entity.Property(e => e.Kommentar).HasMaxLength(255);

                entity.Property(e => e.MomsKr)
                    .HasColumnType("money")
                    .HasColumnName("Moms Kr");

                entity.Property(e => e.Utskriftsdatum).HasColumnType("datetime");

                entity.Property(e => e.VarReferens).HasMaxLength(255);

                entity.Property(e => e.Villkor).HasMaxLength(255);

                entity.HasOne(d => d.VerNrNavigation)
                    .WithMany(p => p.LevFakturas)
                    .HasForeignKey(d => d.VerNr)
                    .HasConstraintName("FK_LevFaktura_Verifikation");
            });

            modelBuilder.Entity<LevFakturaRad>(entity =>
            {
                entity.ToTable("LevFakturaRad");

                entity.HasIndex(e => e.Enhet, "IX_LevFakturaRad_Enhet");

                entity.HasIndex(e => e.LevFakturanummer, "IX_LevFakturaRad_LevFakturanummer");

                entity.Property(e => e.Enhet)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Enhetspris).HasColumnType("money");

                entity.Property(e => e.ProduktTjanst)
                    .HasMaxLength(50)
                    .HasColumnName("Produkt/Tjanst");

                entity.Property(e => e.SummaKr)
                    .HasColumnType("money")
                    .HasColumnName("Summa Kr");

                entity.HasOne(d => d.EnhetNavigation)
                    .WithMany(p => p.LevFakturaRads)
                    .HasForeignKey(d => d.Enhet)
                    .HasConstraintName("FK_LevFakturaRad_Enhet");

                entity.HasOne(d => d.LevFakturanummerNavigation)
                    .WithMany(p => p.LevFakturaRads)
                    .HasForeignKey(d => d.LevFakturanummer)
                    .HasConstraintName("FK_LevFakturaRad_LevFaktura");
            });

            modelBuilder.Entity<Leverantor>(entity =>
            {
                entity.HasKey(e => e.Leverantorsnummer);

                entity.ToTable("Leverantor");

                entity.HasIndex(e => e.Land, "IX_Leverantor_Land");

                entity.Property(e => e.Leverantorsnummer).ValueGeneratedNever();

                entity.Property(e => e.Adress).HasMaxLength(40);

                entity.Property(e => e.Land)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Namn).HasMaxLength(40);

                entity.Property(e => e.Ort).HasMaxLength(40);

                entity.Property(e => e.Postnummer).HasMaxLength(10);

                entity.Property(e => e.Telefax).HasMaxLength(20);

                entity.Property(e => e.Telefonnummer).HasMaxLength(20);

                entity.HasOne(d => d.LandNavigation)
                    .WithMany(p => p.Leverantors)
                    .HasForeignKey(d => d.Land)
                    .HasConstraintName("FK_Leverantor_Landskod");
            });

            modelBuilder.Entity<MallTransaktioner>(entity =>
            {
                entity.ToTable("MallTransaktioner");

                entity.HasIndex(e => e.Konto, "IX_MallTransaktioner_Konto");

                entity.HasIndex(e => e.Kortkod, "IX_MallTransaktioner_Kortkod");

                entity.HasIndex(e => e.Kostnadsbarare, "IX_MallTransaktioner_Kostnadsbarare");

                entity.Property(e => e.DebetProc).HasColumnType("money");

                entity.Property(e => e.Konto)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Kortkod)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Kostnadsbarare)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.KreditProc).HasColumnType("money");

                entity.HasOne(d => d.KontoNavigation)
                    .WithMany(p => p.MallTransaktioners)
                    .HasForeignKey(d => d.Konto)
                    .HasConstraintName("FK_MallTransaktioner_Konto");

                entity.HasOne(d => d.KortkodNavigation)
                    .WithMany(p => p.MallTransaktioners)
                    .HasForeignKey(d => d.Kortkod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MallTransaktioner_MallVerifikat");

                entity.HasOne(d => d.KostnadsbarareNavigation)
                    .WithMany(p => p.MallTransaktioners)
                    .HasForeignKey(d => d.Kostnadsbarare)
                    .HasConstraintName("FK_MallTransaktioner_Kostnadsbarare");
            });

            modelBuilder.Entity<MallVerifikat>(entity =>
            {
                entity.HasKey(e => e.Kortkod);

                entity.ToTable("MallVerifikat");

                entity.HasIndex(e => e.Konto100Proc, "IX_MallVerifikat_Konto100Proc");

                entity.Property(e => e.Kortkod)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Anvands).HasMaxLength(255);

                entity.Property(e => e.Belopp100Proc).HasColumnType("money");

                entity.Property(e => e.Frekvens).HasMaxLength(255);

                entity.Property(e => e.Konto100Proc)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Konto100ProcNavigation)
                    .WithMany(p => p.MallVerifikats)
                    .HasForeignKey(d => d.Konto100Proc)
                    .HasConstraintName("FK_MallVerifikat_Konto");
            });

            modelBuilder.Entity<Meny>(entity =>
            {
                entity.HasKey(e => e.Meny1);

                entity.ToTable("Meny");

                entity.Property(e => e.Meny1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Meny");

                entity.Property(e => e.Beskrivning).HasMaxLength(50);

                entity.Property(e => e.Presentationsordning).HasColumnName("presentationsordning");
            });

            modelBuilder.Entity<Menyval>(entity =>
            {
                entity.HasKey(e => e.Menyvalsnr);

                entity.ToTable("Menyval");

                entity.HasIndex(e => e.Meny, "IX_Menyval_Meny");

                entity.Property(e => e.Menyvalsnr).ValueGeneratedNever();

                entity.Property(e => e.Beskrivning).HasMaxLength(100);

                entity.Property(e => e.Form)
                    .HasMaxLength(50)
                    .HasColumnName("form");

                entity.Property(e => e.Meny)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Menyval1)
                    .HasMaxLength(20)
                    .HasColumnName("Menyval");

                entity.Property(e => e.Query)
                    .HasMaxLength(50)
                    .HasColumnName("query");

                entity.Property(e => e.Report)
                    .HasMaxLength(50)
                    .HasColumnName("report");

                entity.Property(e => e.ShellFunction).HasMaxLength(50);

                entity.HasOne(d => d.MenyNavigation)
                    .WithMany(p => p.Menyvals)
                    .HasForeignKey(d => d.Meny)
                    .HasConstraintName("FK_Menyval_Meny");
            });

            modelBuilder.Entity<MenyvalPersFunkt>(entity =>
            {
                entity.ToTable("Menyval_Pers_funkt");

                entity.HasIndex(e => e.Menyvalsnummer, "IX_Menyval_Pers_funkt_Menyvalsnummer");

                entity.HasIndex(e => e.Personalfunktion, "IX_Menyval_Pers_funkt_Personalfunktion");

                entity.Property(e => e.Personalfunktion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

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
                entity.ToTable("Menyval_Person");

                entity.HasIndex(e => e.Anvandare, "IX_Menyval_Person_Anvandare");

                entity.HasIndex(e => e.Menyvalsnummer, "IX_Menyval_Person_Menyvalsnummer");

                entity.Property(e => e.AnvandSenast).HasColumnType("datetime");

                entity.Property(e => e.Anvandare)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.AnvandareNavigation)
                    .WithMany(p => p.MenyvalPeople)
                    .HasForeignKey(d => d.Anvandare)
                    .HasConstraintName("FK_Menyval_Person_Personal");

                entity.HasOne(d => d.MenyvalsnummerNavigation)
                    .WithMany(p => p.MenyvalPeople)
                    .HasForeignKey(d => d.Menyvalsnummer)
                    .HasConstraintName("FK_Menyval_Person_Menyval");
            });

            modelBuilder.Entity<Momsperioder>(entity =>
            {
                entity.ToTable("Momsperioder");

                entity.HasIndex(e => e.Verifikationsnr, "IX_Momsperioder_Verifikationsnr");

                entity.Property(e => e.MomsperiodSlut).HasColumnType("datetime");

                entity.Property(e => e.MomsperiodStart).HasColumnType("datetime");

                entity.Property(e => e.SenasteInbetDatum).HasColumnType("datetime");

                entity.HasOne(d => d.VerifikationsnrNavigation)
                    .WithMany(p => p.Momsperioders)
                    .HasForeignKey(d => d.Verifikationsnr)
                    .HasConstraintName("FK_Momsperioder_Verifikation");
            });

            modelBuilder.Entity<Myview>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("myview");

                entity.Property(e => e.Beskrivning).HasMaxLength(200);

                entity.Property(e => e.Bokforingsdatum).HasColumnType("datetime");

                entity.Property(e => e.DebetKr).HasColumnType("money");

                entity.Property(e => e.KreditKr).HasColumnType("money");

                entity.Property(e => e.Transaktionsdatum).HasColumnType("datetime");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.HasKey(e => e.Signatur);

                entity.ToTable("Personal");

                entity.HasIndex(e => e.Personalfunktion, "IX_Personal_Personalfunktion");

                entity.Property(e => e.Signatur)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Efternamn).HasMaxLength(50);

                entity.Property(e => e.Fornamn).HasMaxLength(50);

                entity.Property(e => e.Mobiltelefon).HasMaxLength(20);

                entity.Property(e => e.Personalfunktion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefonnummer).HasMaxLength(20);

                entity.HasOne(d => d.PersonalfunktionNavigation)
                    .WithMany(p => p.Personals)
                    .HasForeignKey(d => d.Personalfunktion)
                    .HasConstraintName("FK_Personal_Personalfunktion");
            });

            modelBuilder.Entity<Personalfunktion>(entity =>
            {
                entity.HasKey(e => e.Personalfunktion1);

                entity.ToTable("Personalfunktion");

                entity.Property(e => e.Personalfunktion1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Personalfunktion");

                entity.Property(e => e.Beskrivning).HasMaxLength(50);
            });

            modelBuilder.Entity<Produkt>(entity =>
            {
                entity.HasKey(e => e.ProduktTjanst);

                entity.ToTable("Produkt");

                entity.HasIndex(e => e.Enhet, "IX_Produkt_Enhet");

                entity.Property(e => e.ProduktTjanst)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Produkt/Tjanst");

                entity.Property(e => e.Beskrivning).HasMaxLength(50);

                entity.Property(e => e.Enhet)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Enhetspris).HasColumnType("money");

                entity.HasOne(d => d.EnhetNavigation)
                    .WithMany(p => p.Produkts)
                    .HasForeignKey(d => d.Enhet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produkt_Enhet");
            });

            modelBuilder.Entity<Projekt>(entity =>
            {
                entity.HasKey(e => e.Projektnr);

                entity.ToTable("Projekt");

                entity.HasIndex(e => e.Kundnr, "IX_Projekt_Kundnr");

                entity.Property(e => e.Projektnr).ValueGeneratedNever();

                entity.Property(e => e.Beskrivning).HasMaxLength(50);

                entity.Property(e => e.Kod).HasMaxLength(5);

                entity.Property(e => e.Projektledare).HasMaxLength(10);

                entity.Property(e => e.StartFrom).HasColumnType("datetime");

                entity.Property(e => e.TillOchMed).HasColumnType("datetime");

                entity.Property(e => e.Timpris).HasColumnType("money");

                entity.Property(e => e.VarReferens).HasMaxLength(10);

                entity.HasOne(d => d.KundnrNavigation)
                    .WithMany(p => p.Projekts)
                    .HasForeignKey(d => d.Kundnr)
                    .HasConstraintName("FK_Projekt_Kund");
            });

            modelBuilder.Entity<ProjektAktivitet>(entity =>
            {
                entity.ToTable("ProjektAktivitet");

                entity.HasIndex(e => e.Leverantorsnummer, "IX_ProjektAktivitet_Leverantorsnummer");

                entity.HasIndex(e => e.Projektnummer, "IX_ProjektAktivitet_Projektnummer");

                entity.Property(e => e.StartFrom).HasColumnType("datetime");

                entity.Property(e => e.TillOchMed).HasColumnType("datetime");

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
                entity.HasKey(e => e.Rapport1);

                entity.ToTable("Rapport");

                entity.Property(e => e.Rapport1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Rapport");

                entity.Property(e => e.Benamning).HasMaxLength(255);

                entity.Property(e => e.Kommentar).HasMaxLength(255);

                entity.Property(e => e.OmKol2Ib).HasColumnName("OmKol2IB");
            });

            modelBuilder.Entity<RapportRad>(entity =>
            {
                entity.ToTable("RapportRad");

                entity.HasIndex(e => e.Rapport, "IX_RapportRad_Rapport");

                entity.Property(e => e.KontoFrom)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KontoTom)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OmAdderaIb).HasColumnName("OmAdderaIB");

                entity.Property(e => e.RadFromTom).HasMaxLength(255);

                entity.Property(e => e.Radbenamning).HasMaxLength(255);

                entity.Property(e => e.Rapport)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.RapportNavigation)
                    .WithMany(p => p.RapportRads)
                    .HasForeignKey(d => d.Rapport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RapportRad_Rapport");
            });

            modelBuilder.Entity<Transaktion>(entity =>
            {
                entity.ToTable("Transaktion");

                entity.HasIndex(e => e.Konto, "IX_Transaktion_Konto");

                entity.HasIndex(e => e.Kostnadsbarare, "IX_Transaktion_Kostnadsbarare");

                entity.HasIndex(e => e.Verifikation, "IX_Transaktion_Verifikation");

                entity.Property(e => e.DebetKr).HasColumnType("money");

                entity.Property(e => e.Konto)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Kostnadsbarare)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.KreditKr).HasColumnType("money");

                entity.HasOne(d => d.KontoNavigation)
                    .WithMany(p => p.Transaktions)
                    .HasForeignKey(d => d.Konto)
                    .HasConstraintName("FK_Transaktion_Konto");

                entity.HasOne(d => d.KostnadsbarareNavigation)
                    .WithMany(p => p.Transaktions)
                    .HasForeignKey(d => d.Kostnadsbarare)
                    .HasConstraintName("FK_Transaktion_Kostnadsbarare");

                entity.HasOne(d => d.VerifikationNavigation)
                    .WithMany(p => p.Transaktions)
                    .HasForeignKey(d => d.Verifikation)
                    .HasConstraintName("FK_Transaktion_Verifikation");
            });

            modelBuilder.Entity<Verifikation>(entity =>
            {
                entity.HasKey(e => e.Verifikation1);

                entity.ToTable("Verifikation");

                entity.HasIndex(e => e.Fakturanr, "IX_Verifikation_Fakturanr");

                entity.HasIndex(e => e.Kundnummer, "IX_Verifikation_Kundnummer");

                entity.Property(e => e.Verifikation1)
                    .ValueGeneratedNever()
                    .HasColumnName("Verifikation");

                entity.Property(e => e.Beskrivning).HasMaxLength(200);

                entity.Property(e => e.Bokforingsdatum).HasColumnType("datetime");

                entity.Property(e => e.DebetKr).HasColumnType("money");

                entity.Property(e => e.KreditKr).HasColumnType("money");

                entity.Property(e => e.Transaktionsdatum).HasColumnType("datetime");

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
