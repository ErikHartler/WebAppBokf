using System;
using System.Collections.Generic;
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
                optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=Bokforing;Trusted_Connection=True;");
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
            SeedData(modelBuilder);

        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            SeedBetalsatt(modelBuilder);
            SeedProdukt(modelBuilder);
            SeedMeny(modelBuilder);
            SeedMomsPerioder(modelBuilder);
            SeedEnhet(modelBuilder);
            SeedPersonalfunktion(modelBuilder);

            SeedPersonal(modelBuilder);
            SeedMenyVal(modelBuilder);

            SeedKonto(modelBuilder);
            SeedInst(modelBuilder);
            SeedBokfAr(modelBuilder);
           

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private static void SeedBetalsatt(ModelBuilder modelBuilder)
        {
            var betalsatt = new List<Betalsatt>
            {
                new Betalsatt { Betalsatt1 = "BG", Beskrivning = "Bankgiro" },
                new Betalsatt { Betalsatt1 = "PG", Beskrivning = "Postgiro" }
            };
            modelBuilder.Entity<Betalsatt>().HasData(betalsatt);
        }

        private static void SeedBokfAr(ModelBuilder modelBuilder)
        {
            var betalsatt = new List<Bokföringsar>
            {
                new Bokföringsar { Bokforingsar = "2020", Start = new DateTime(2020, 05, 01), Slut = new DateTime(2021, 04, 30), OmStangt = false }
            };
            modelBuilder.Entity<Bokföringsar>().HasData(betalsatt);
        }

        private static void SeedInst(ModelBuilder modelBuilder)
        {
            var installningar = new List<Installningar>
            {
                new Installningar
                {
                    BokforingsarFrom = new DateTime(2020, 05, 01),
                    BokforingsarTom = new DateTime(2021, 04, 30),
                    Bolagsnamn = "Erik Hartler AB",
                    Organisationsnr = "5556944-9035",
                    KontoIngMoms = "2641",
                    KontoUtgMoms = "2611",
                    KontoMomsAvstamning = "2650",
                    KontoIntakterFrom = "3001",
                    KontoIntakterTom = "3740",
                    KontoIntakterKund = "3001",
                    KontoFordranFrom = "1510",
                    KontoFordranTom = "1510",
                    KontoFordranKund = "1510",
                    Id=1

                }
            };
            modelBuilder.Entity<Installningar>().HasData(installningar);
        }



        private static void SeedEnhet(ModelBuilder modelBuilder)
        {
            var enhet = new List<Enhet>
            {
                new Enhet { Enhet1 = "Dagar", Beskrivning = "Dagar" },
                new Enhet { Enhet1 = "Licenser", Beskrivning = "Licenser" },
                new Enhet { Enhet1 = "Mil", Beskrivning = "för milersättningar" },
                new Enhet { Enhet1 = "Styck", Beskrivning = "Styck" },
                new Enhet { Enhet1 = "Timmar", Beskrivning = "Konsultersättning per timme" },
                new Enhet { Enhet1 = "Totalt", Beskrivning = "Totalt" }
            };
            modelBuilder.Entity<Enhet>().HasData(enhet);

        }

        private static void SeedKonto(ModelBuilder modelBuilder)
        {
            var konto = new List<Konto>
            {
                new Konto { Konto1 = "1221", Arsredovisningsrad = "EJ avstämt!!", Benamning = "Inventarier", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "1229", Arsredovisningsrad = "EJ avstämt!!", Benamning = "Ackumulerade avskrivningar på inventarier och verktyg", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "1510", Arsredovisningsrad = "BR-kundfordringar", Benamning = "Kundfordringar", IbDebetKr = 0, OmDebet = false, Skattekonto = "7251" },
                new Konto { Konto1 = "1610", Arsredovisningsrad = "EJ avstämt!!", Benamning = "Kortfristiga fordringar hos Erik", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "1630", Arsredovisningsrad = "BR-skattefordran", Benamning = "Skatter", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "1631", Arsredovisningsrad = "BR-skattefordran", Benamning = "Prel f-Skatt företaget", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "1790", Arsredovisningsrad = "EJ avstämt!!", Benamning = "Upplupna intäkter/förutbetalda konstnader", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "1930", Arsredovisningsrad = "BR-Kassa och Bank", Benamning = "Bank", IbDebetKr = 0, OmDebet = false, Skattekonto = "7281" },
                new Konto { Konto1 = "2017", Arsredovisningsrad = "EJ avstämt!!", Benamning = "Årets kapitaltillskott", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "2081", Arsredovisningsrad = "BR-Aktiekapital", Benamning = "Aktiekapital", IbDebetKr = 0, OmDebet = false, Skattekonto = "7301" },
                new Konto { Konto1 = "2086", Arsredovisningsrad = "EJ avstämt!!", Benamning = "Reservfond", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "2091", Arsredovisningsrad = "TU-Utdelning", Benamning = "Balanserad V/F", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "2099", Arsredovisningsrad = "BR-Fritt eget kapital", Benamning = "Årets resultat", IbDebetKr = 0, OmDebet = false, Skattekonto = "7302" },
                new Konto { Konto1 = "2431", Arsredovisningsrad = "EJ avstämt!!", Benamning = "Pågående arb fakturering", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "2440", Arsredovisningsrad = "EJ avstämt!!", Benamning = "Leverantörsskuld", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "2512", Arsredovisningsrad = "EJ avstämt!!", Benamning = " Beräknad inkomstskatt", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "2518", Arsredovisningsrad = "BR-Skatteskulder", Benamning = "Betald F-skatt", IbDebetKr = 0, OmDebet = false, Skattekonto = "7368" },
                new Konto { Konto1 = "2611", Arsredovisningsrad = "EJ avstämt!!", Benamning = "Utgående moms", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "2641", Arsredovisningsrad = "EJ avstämt!!", Benamning = "Ingående moms", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "2650", Arsredovisningsrad = "BR-Skatteskulder", Benamning = "Redovisningskonto för moms", IbDebetKr = 0, OmDebet = false, Skattekonto = "7368" },
                new Konto { Konto1 = "2710", Arsredovisningsrad = "BR-Skatteskulder", Benamning = "Personalskatt", IbDebetKr = 0, OmDebet = false, Skattekonto = "7368" },
                new Konto { Konto1 = "2731", Arsredovisningsrad = "RR-Personalkostnader", Benamning = "Avräkning lagstadgade sociala avgifter", IbDebetKr = 0, OmDebet = false, Skattekonto = "7514" },
                new Konto { Konto1 = "2820", Arsredovisningsrad = "BR-Övr kortfristiga skulder", Benamning = "Kortfristiga skulder till Erik", IbDebetKr = 0, OmDebet = false, Skattekonto = "7369+7650" },
                new Konto { Konto1 = "2821", Arsredovisningsrad = "BR-Övr kortfristiga skulder", Benamning = "Kortfristiga skulder till Ann", IbDebetKr = 0, OmDebet = false, Skattekonto = "7369+7650" },
                new Konto { Konto1 = "2898", Arsredovisningsrad = "EJ avstämt!!", Benamning = "Outtagen vinstutdelning", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "2940", Arsredovisningsrad = "BR-Skatteskulder", Benamning = "Arb givaravgifter", IbDebetKr = 0, OmDebet = false, Skattekonto = "7368" },
                new Konto { Konto1 = "3001", Arsredovisningsrad = "RR-Nettoomsättning", Benamning = "Försäljning inom Sverige, 25 % moms", IbDebetKr = 0, OmDebet = false, Skattekonto = "7410" },
                new Konto { Konto1 = "3740", Arsredovisningsrad = "RR-Nettoomsättning", Benamning = "Öres- och kronutjämning", IbDebetKr = 0, OmDebet = false, Skattekonto = "7410" },
                new Konto { Konto1 = "4110", Arsredovisningsrad = "RR-Övriga rörelsekostnader", Benamning = "Inköp matriel", IbDebetKr = 0, OmDebet = false, Skattekonto = "7517" },
                new Konto { Konto1 = "5011", Arsredovisningsrad = "RR-Övriga rörelsekostnader", Benamning = "Hyra för kontorslokaler", IbDebetKr = 0, OmDebet = false, Skattekonto = "7517" },
                new Konto { Konto1 = "6020", Arsredovisningsrad = "RR-Övriga rörelsekostnader", Benamning = "Egna facktidskrifter", IbDebetKr = 0, OmDebet = false, Skattekonto = "7517" },
                new Konto { Konto1 = "6071", Arsredovisningsrad = "RR-Övriga rörelsekostnader", Benamning = "Representation, avdragsgill", IbDebetKr = 0, OmDebet = false, Skattekonto = "7517" },
                new Konto { Konto1 = "6072", Arsredovisningsrad = "RR-Övriga rörelsekostnader", Benamning = "Representation, ej avdragsgill", IbDebetKr = 0, OmDebet = false, Skattekonto = "7517" },
                new Konto { Konto1 = "6110", Arsredovisningsrad = "RR-Övriga rörelsekostnader", Benamning = "Kontorsmateriel", IbDebetKr = 0, OmDebet = false, Skattekonto = "7517" },
                new Konto { Konto1 = "6212", Arsredovisningsrad = "RR-Övriga rörelsekostnader", Benamning = "Mobiltelefoni", IbDebetKr = 0, OmDebet = false, Skattekonto = "7517" },
                new Konto { Konto1 = "6250", Arsredovisningsrad = "RR-Övriga rörelsekostnader", Benamning = "Postbefordran", IbDebetKr = 0, OmDebet = false, Skattekonto = "7517" },
                new Konto { Konto1 = "6310", Arsredovisningsrad = "RR-Övriga rörelsekostnader", Benamning = "Företagsförsäkringar", IbDebetKr = 0, OmDebet = false, Skattekonto = "7517" },
                new Konto { Konto1 = "6421", Arsredovisningsrad = "RR-Övriga rörelsekostnader", Benamning = "Revision", IbDebetKr = 0, OmDebet = false, Skattekonto = "7517" },
                new Konto { Konto1 = "6570", Arsredovisningsrad = "RR-Räntekostn e d", Benamning = "Bankkostnader", IbDebetKr = 0, OmDebet = false, Skattekonto = "7522" },
                new Konto { Konto1 = "6991", Arsredovisningsrad = "EJ avstämt!!", Benamning = "Övriga externa kostnader, avdragsgilla", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "6992", Arsredovisningsrad = "EJ avstämt!!", Benamning = "Övriga externa kostnader, ej avdragsgilla", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "7011", Arsredovisningsrad = "RR-Personalkostnader", Benamning = "Löner", IbDebetKr = 0, OmDebet = false, Skattekonto = "" },
                new Konto { Konto1 = "7214", Arsredovisningsrad = "RR-Personalkostnader", Benamning = "Löner till tjänstemän (nya pensionssystemet) Ann", IbDebetKr = 0, OmDebet = false, Skattekonto = "7514" },
                new Konto { Konto1 = "7224", Arsredovisningsrad = "RR-Personalkostnader", Benamning = "Löner till företagsledare (nya pensionssystemet) Erik", IbDebetKr = 0, OmDebet = false, Skattekonto = "7514" },
                new Konto { Konto1 = "7286", Arsredovisningsrad = "RR-Personalkostnader", Benamning = "Semesterlöner till företagsledare", IbDebetKr = 0, OmDebet = false, Skattekonto = "7514" },
                new Konto { Konto1 = "7310", Arsredovisningsrad = "RR-Personalkostnader", Benamning = "Kontanta extraersättningar", IbDebetKr = 0, OmDebet = false, Skattekonto = "7514" },
                new Konto { Konto1 = "7331", Arsredovisningsrad = "RR-Personalkostnader", Benamning = "Skattefria bilersättningar", IbDebetKr = 0, OmDebet = false, Skattekonto = "7514" },
                new Konto { Konto1 = "7333", Arsredovisningsrad = "RR-Personalkostnader", Benamning = "Ersättning för trängselskatt, skattefri", IbDebetKr = 0, OmDebet = false, Skattekonto = "7514" },
                new Konto { Konto1 = "7389", Arsredovisningsrad = "RR-Personalkostnader", Benamning = "Övriga kostnader för förmåner  anställda", IbDebetKr = 0, OmDebet = false, Skattekonto = "7514" },
                new Konto { Konto1 = "7521", Arsredovisningsrad = "RR-Personalkostnader", Benamning = "Arbetsgivaravgifter för löner och ersättningar (nya pensionssystemet)", IbDebetKr = 0, OmDebet = false, Skattekonto = "7514" },
                new Konto { Konto1 = "7529", Arsredovisningsrad = "RR-Personalkostnader", Benamning = "Arbetsgivaravgifter för semester- och löneskulder (nya pensionssystemet)", IbDebetKr = 0, OmDebet = false, Skattekonto = "7514" },
                new Konto { Konto1 = "7570", Arsredovisningsrad = "RR-Övriga rörelsekostnader", Benamning = "Premier för arbetsmarknadsförsäkringar", IbDebetKr = 0, OmDebet = false, Skattekonto = "7514" },

                new Konto { Konto1 = "8311", Arsredovisningsrad = "RR-Övr ränte int", Benamning = "Ränteintäkter från bank", IbDebetKr = 0, OmDebet = false, Skattekonto = "7417" },
                new Konto { Konto1 = "8910", Arsredovisningsrad = "RR-Skatt på årets resultat", Benamning = " Skatt som belastar årets resultat", IbDebetKr = 0, OmDebet = false, Skattekonto = "7528" }
            };

            modelBuilder.Entity<Konto>().HasData(konto);
        }
        private static void SeedMeny(ModelBuilder modelBuilder)
        {
            int i = 1;
            var meny = new List<Meny>
            {
                new Meny { Meny1 = "Parametrar-allm", Beskrivning = "Allmänna parametrar", Presentationsordning = i++ },
                new Meny { Meny1 = "Parametrar-bokf", Beskrivning = "Bokföringsparametrar", Presentationsordning = i++ },
                new Meny { Meny1 = "Parametrar-fakt", Beskrivning = "Parametrar fakturering", Presentationsordning = i++ },
                new Meny { Meny1 = "Rapporter", Beskrivning = "Rapporter", Presentationsordning = i++ },
                new Meny { Meny1 = "Registrering", Beskrivning = "Registrering baserat på parametrar", Presentationsordning = i++ }
            };
            modelBuilder.Entity<Meny>().HasData(meny);

        }
        private static void SeedMenyVal(ModelBuilder modelBuilder)
        {
            int i = 1;
            var menyval = new List<Menyval>
            {
                new Menyval { Menyvalsnr = i++, Menyval1 = "Bokf År", Beskrivning = "Allmänna parametrar" },
                new Menyval { Menyvalsnr = i++, Menyval1 = "Bokf År", Beskrivning = "Allmänna parametrar" }
            };
            modelBuilder.Entity<Menyval>().HasData(menyval);

        }

        private static void SeedMomsPerioder(ModelBuilder modelBuilder)
        {
            int i = 1;
            var momsperioder = new List<Momsperioder>
            {
                new Momsperioder { MomsperiodStart = new DateTime(2020, 4, 1), MomsperiodSlut = new DateTime(2020, 6, 30),Id=i++ },
                new Momsperioder { MomsperiodStart = new DateTime(2020, 7, 1), MomsperiodSlut = new DateTime(2020, 9, 30),Id=i++ },
                new Momsperioder { MomsperiodStart = new DateTime(2020, 10, 1), MomsperiodSlut = new DateTime(2020, 12, 31),Id=i++ },
                new Momsperioder { MomsperiodStart = new DateTime(2020, 1, 1), MomsperiodSlut = new DateTime(2021, 3, 31),Id=i++ }
            };
            modelBuilder.Entity<Momsperioder>().HasData(momsperioder);

        }

        private static void SeedPersonal(ModelBuilder modelBuilder)
        {
            var personal = new List<Personal>
            {
                new Personal { Signatur = "EH", Fornamn = "Erik", Efternamn = "Hartler",Personalfunktion ="VD" }
            };
            modelBuilder.Entity<Personal>().HasData(personal);

        }

        private static void SeedPersonalfunktion(ModelBuilder modelBuilder)
        {
            var personalfunktion = new List<Personalfunktion>
            {
                new Personalfunktion { Personalfunktion1 = "VD" }
            };
            modelBuilder.Entity<Personalfunktion>().HasData(personalfunktion);

        }

        private static void SeedProdukt(ModelBuilder modelBuilder)
        {
            var produkt = new List<Produkt>
            {
                new Produkt { ProduktTjanst = "Systemutveckling", Beskrivning = "Systemutveckling", Enhet = "Timmar", Enhetspris = 850 }
            };
            modelBuilder.Entity<Produkt>().HasData(produkt);

        }


        private static void SeedRapport(ModelBuilder modelBuilder)
        {
            var produkt = new List<Rapport>
            {
                new Rapport { Rapport1 = "BR", Benamning = "Balansräkning", OmTeckenvandning = true, OmKol2Ib = false },
                new Rapport { Rapport1 = "RR", Benamning = "Resultaträkning", OmTeckenvandning = false, OmKol2Ib = true }
            };
            modelBuilder.Entity<Rapport>().HasData(produkt);

        }


        private static void SeedRapportRad(ModelBuilder modelBuilder)
        {
            var produkt = new List<RapportRad>
            {
                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 20, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 21, KontoFrom = "1040", KontoTom = "1040", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 22, KontoFrom = "1210", KontoTom = "1210", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 23, KontoFrom = "1450", KontoTom = "1470", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 30, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 35, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 40, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 50, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 60, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 70, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 71, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 72, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 73, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 74, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 80, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 90, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 100, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 110, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 111, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 112, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 113, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 114, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 115, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 120, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },

                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },

                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                new RapportRad { Rapport = "BR", Radnr = 10, KontoFrom = "", KontoTom = "", RadFromTom = "", Radbenamning = "TILLGÅNGAR", OmAdderaIb = true },
                 
            };
            modelBuilder.Entity<Rapport>().HasData(produkt);

        }

    }
}
