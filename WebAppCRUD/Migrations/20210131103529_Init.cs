using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCRUD.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Betalsatt",
                columns: table => new
                {
                    Betalsatt = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Betalsatt", x => x.Betalsatt);
                });

            migrationBuilder.CreateTable(
                name: "Bokföringsar",
                columns: table => new
                {
                    Bokforingsar = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    Start = table.Column<DateTime>(type: "datetime", nullable: true),
                    Slut = table.Column<DateTime>(type: "datetime", nullable: true),
                    OmStangt = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bokföringsar", x => x.Bokforingsar);
                });

            migrationBuilder.CreateTable(
                name: "Enhet",
                columns: table => new
                {
                    Enhet = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enhet", x => x.Enhet);
                });

            migrationBuilder.CreateTable(
                name: "Konto",
                columns: table => new
                {
                    Konto = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    arsredovisningsrad = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Benamning = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IBDebetKr = table.Column<decimal>(name: "IB Debet Kr", type: "money", nullable: true),
                    IBKreditKr = table.Column<decimal>(name: "IB Kredit Kr", type: "money", nullable: true),
                    OmDebet = table.Column<bool>(type: "bit", nullable: false),
                    Skattekonto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konto", x => x.Konto);
                });

            migrationBuilder.CreateTable(
                name: "Kostnadsbarare",
                columns: table => new
                {
                    Kostnadsbarare = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kostnadsbarare", x => x.Kostnadsbarare);
                });

            migrationBuilder.CreateTable(
                name: "Landskod",
                columns: table => new
                {
                    Landskod = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Land = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landskod", x => x.Landskod);
                });

            migrationBuilder.CreateTable(
                name: "Meny",
                columns: table => new
                {
                    Meny = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    presentationsordning = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meny", x => x.Meny);
                });

            migrationBuilder.CreateTable(
                name: "Personalfunktion",
                columns: table => new
                {
                    Personalfunktion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personalfunktion", x => x.Personalfunktion);
                });

            migrationBuilder.CreateTable(
                name: "Rapport",
                columns: table => new
                {
                    Rapport = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Benamning = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OmTeckenvandning = table.Column<bool>(type: "bit", nullable: false),
                    OmKol2IB = table.Column<bool>(type: "bit", nullable: false),
                    Kommentar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rapport", x => x.Rapport);
                });

            migrationBuilder.CreateTable(
                name: "Produkt",
                columns: table => new
                {
                    ProduktTjanst = table.Column<string>(name: "Produkt/Tjanst", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Enhet = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Enhetspris = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkt", x => x.ProduktTjanst);
                    table.ForeignKey(
                        name: "FK_Produkt_Enhet",
                        column: x => x.Enhet,
                        principalTable: "Enhet",
                        principalColumn: "Enhet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Installningar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bokforingsarfrom = table.Column<DateTime>(name: "Bokforingsar from", type: "datetime", nullable: true),
                    Bokforingsartom = table.Column<DateTime>(name: "Bokforingsar tom", type: "datetime", nullable: true),
                    Bolagsnamn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Organisationsnr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KontoIngMoms = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    KontoUtgMoms = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    KontoMomsAvstamning = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    KontoIntakterFrom = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    KontoIntakterTom = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    KontoIntakterKund = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    KontoFordranFrom = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    KontoFordranTom = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    KontoFordranKund = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installningar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Installningar_Konto",
                        column: x => x.KontoIngMoms,
                        principalTable: "Konto",
                        principalColumn: "Konto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Installningar_Konto1",
                        column: x => x.KontoUtgMoms,
                        principalTable: "Konto",
                        principalColumn: "Konto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Installningar_Konto2",
                        column: x => x.KontoMomsAvstamning,
                        principalTable: "Konto",
                        principalColumn: "Konto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Installningar_Konto3",
                        column: x => x.KontoIntakterFrom,
                        principalTable: "Konto",
                        principalColumn: "Konto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Installningar_Konto4",
                        column: x => x.KontoIntakterTom,
                        principalTable: "Konto",
                        principalColumn: "Konto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Installningar_Konto5",
                        column: x => x.KontoFordranFrom,
                        principalTable: "Konto",
                        principalColumn: "Konto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Installningar_Konto6",
                        column: x => x.KontoFordranTom,
                        principalTable: "Konto",
                        principalColumn: "Konto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Installningar_Konto7",
                        column: x => x.KontoFordranKund,
                        principalTable: "Konto",
                        principalColumn: "Konto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Installningar_Konto8",
                        column: x => x.KontoIntakterKund,
                        principalTable: "Konto",
                        principalColumn: "Konto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MallVerifikat",
                columns: table => new
                {
                    Kortkod = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Konto100Proc = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    OmDebet100Proc = table.Column<bool>(type: "bit", nullable: false),
                    Anvands = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Frekvens = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Belopp100Proc = table.Column<decimal>(type: "money", nullable: true),
                    OmKundnrSpec = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MallVerifikat", x => x.Kortkod);
                    table.ForeignKey(
                        name: "FK_MallVerifikat_Konto",
                        column: x => x.Konto100Proc,
                        principalTable: "Konto",
                        principalColumn: "Konto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kund",
                columns: table => new
                {
                    Kundnummer = table.Column<int>(type: "int", nullable: false),
                    Kundnamn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Box = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Postnummer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KontPersFornamn = table.Column<string>(name: "Kont Pers Fornamn", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    KontPersEfternamn = table.Column<string>(name: "Kont PersEfternamn", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Forfallodagar = table.Column<int>(type: "int", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Telefax = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Kommentar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Villkor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IBKredit = table.Column<decimal>(type: "money", nullable: true),
                    Landskod = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kund", x => x.Kundnummer);
                    table.ForeignKey(
                        name: "FK_Kund_Landskod",
                        column: x => x.Landskod,
                        principalTable: "Landskod",
                        principalColumn: "Landskod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leverantor",
                columns: table => new
                {
                    Leverantorsnummer = table.Column<int>(type: "int", nullable: false),
                    Namn = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Postnummer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Ort = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Land = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Telefonnummer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Telefax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leverantor", x => x.Leverantorsnummer);
                    table.ForeignKey(
                        name: "FK_Leverantor_Landskod",
                        column: x => x.Land,
                        principalTable: "Landskod",
                        principalColumn: "Landskod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menyval",
                columns: table => new
                {
                    Menyvalsnr = table.Column<int>(type: "int", nullable: false),
                    Menyval = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Meny = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Beskrivning = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    form = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    report = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    query = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShellFunction = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menyval", x => x.Menyvalsnr);
                    table.ForeignKey(
                        name: "FK_Menyval_Meny",
                        column: x => x.Meny,
                        principalTable: "Meny",
                        principalColumn: "Meny",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    Signatur = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Fornamn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Efternamn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefonnummer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mobiltelefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Personalfunktion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    IntroViaknappar = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.Signatur);
                    table.ForeignKey(
                        name: "FK_Personal_Personalfunktion",
                        column: x => x.Personalfunktion,
                        principalTable: "Personalfunktion",
                        principalColumn: "Personalfunktion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RapportRad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rapport = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Radnr = table.Column<double>(type: "float", nullable: true),
                    KontoFrom = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    KontoTom = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    RadFromTom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Radbenamning = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OmAdderaIB = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RapportRad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RapportRad_Rapport",
                        column: x => x.Rapport,
                        principalTable: "Rapport",
                        principalColumn: "Rapport",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MallTransaktioner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kortkod = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Radnr = table.Column<int>(type: "int", nullable: true),
                    DebetProc = table.Column<decimal>(type: "money", nullable: true),
                    KreditProc = table.Column<decimal>(type: "money", nullable: true),
                    Konto = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Kostnadsbarare = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MallTransaktioner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MallTransaktioner_Konto",
                        column: x => x.Konto,
                        principalTable: "Konto",
                        principalColumn: "Konto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MallTransaktioner_Kostnadsbarare",
                        column: x => x.Kostnadsbarare,
                        principalTable: "Kostnadsbarare",
                        principalColumn: "Kostnadsbarare",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MallTransaktioner_MallVerifikat",
                        column: x => x.Kortkod,
                        principalTable: "MallVerifikat",
                        principalColumn: "Kortkod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kontaktperson_Kund",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kundnummer = table.Column<int>(type: "int", nullable: true),
                    Radnummer = table.Column<int>(type: "int", nullable: true),
                    Fornamn = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Efternamn = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TelefonDirekt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TelefonHem = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TelefonMobil = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontaktperson_Kund", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kontaktperson_Kund_Kund",
                        column: x => x.Kundnummer,
                        principalTable: "Kund",
                        principalColumn: "Kundnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projekt",
                columns: table => new
                {
                    Projektnr = table.Column<int>(type: "int", nullable: false),
                    Kundnr = table.Column<int>(type: "int", nullable: true),
                    StartFrom = table.Column<DateTime>(type: "datetime", nullable: true),
                    Kod = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Beskrivning = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Projektledare = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TillOchMed = table.Column<DateTime>(type: "datetime", nullable: true),
                    Timpris = table.Column<decimal>(type: "money", nullable: true),
                    VarReferens = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ErReferens = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekt", x => x.Projektnr);
                    table.ForeignKey(
                        name: "FK_Projekt_Kund",
                        column: x => x.Kundnr,
                        principalTable: "Kund",
                        principalColumn: "Kundnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kontaktperson_Leverantor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Leverantorsnummer = table.Column<int>(type: "int", nullable: true),
                    Radnummer = table.Column<int>(type: "int", nullable: true),
                    Fornamn = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Efternamn = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TelefonDirekt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TelefonHem = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TelefonMobil = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontaktperson_Leverantor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kontaktperson_Leverantor_Leverantor",
                        column: x => x.Leverantorsnummer,
                        principalTable: "Leverantor",
                        principalColumn: "Leverantorsnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menyval_Pers_funkt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personalfunktion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Menyvalsnummer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menyval_Pers_funkt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menyval_Pers_funkt_Menyval",
                        column: x => x.Menyvalsnummer,
                        principalTable: "Menyval",
                        principalColumn: "Menyvalsnr",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menyval_Pers_funkt_Personalfunktion",
                        column: x => x.Personalfunktion,
                        principalTable: "Personalfunktion",
                        principalColumn: "Personalfunktion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menyval_Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anvandare = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Menyvalsnummer = table.Column<int>(type: "int", nullable: true),
                    AnvandAntal = table.Column<int>(type: "int", nullable: true),
                    AnvandSenast = table.Column<DateTime>(type: "datetime", nullable: true),
                    MakeCmd = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menyval_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menyval_Person_Menyval",
                        column: x => x.Menyvalsnummer,
                        principalTable: "Menyval",
                        principalColumn: "Menyvalsnr",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menyval_Person_Personal",
                        column: x => x.Anvandare,
                        principalTable: "Personal",
                        principalColumn: "Signatur",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Faktura",
                columns: table => new
                {
                    Fakturanummer = table.Column<int>(type: "int", nullable: false),
                    Fakturadatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    Forfallodatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    Utskriftsdatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    Kundnummer = table.Column<int>(type: "int", nullable: true),
                    Kundnamn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Box = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Postnummer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BeloppExklmoms = table.Column<decimal>(name: "Belopp Exkl moms", type: "money", nullable: true),
                    MomsKr = table.Column<decimal>(name: "Moms Kr", type: "money", nullable: true),
                    BeloppInklMomsKr = table.Column<decimal>(name: "Belopp Inkl Moms Kr", type: "money", nullable: true),
                    BetaltKr = table.Column<decimal>(name: "Betalt Kr", type: "money", nullable: true),
                    Betaldatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    VarReferens = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ErRefForN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Kommentar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ErRefEfterN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Villkor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Momssats = table.Column<double>(type: "float", nullable: true),
                    VerNr = table.Column<double>(type: "float", nullable: true),
                    Paminnelse1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Paminnelse2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Inkasso = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UtestaendeFordr = table.Column<decimal>(type: "money", nullable: true),
                    COAdress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Land = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Godkann = table.Column<bool>(type: "bit", nullable: false),
                    Projekt = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    ProjektId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faktura", x => x.Fakturanummer);
                    table.ForeignKey(
                        name: "FK_Faktura_Kund",
                        column: x => x.Kundnummer,
                        principalTable: "Kund",
                        principalColumn: "Kundnummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faktura_Landskod",
                        column: x => x.Land,
                        principalTable: "Landskod",
                        principalColumn: "Landskod",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faktura_Projekt",
                        column: x => x.ProjektId,
                        principalTable: "Projekt",
                        principalColumn: "Projektnr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjektAktivitet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Projektnummer = table.Column<int>(type: "int", nullable: true),
                    Aktivitetsnummer = table.Column<int>(type: "int", nullable: true),
                    Leverantorsnummer = table.Column<int>(type: "int", nullable: true),
                    StartFrom = table.Column<DateTime>(type: "datetime", nullable: true),
                    TillOchMed = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjektAktivitet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjektAktivitet_Leverantor",
                        column: x => x.Leverantorsnummer,
                        principalTable: "Leverantor",
                        principalColumn: "Leverantorsnummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjektAktivitet_Projekt",
                        column: x => x.Projektnummer,
                        principalTable: "Projekt",
                        principalColumn: "Projektnr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fakturarad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fakturanummer = table.Column<int>(type: "int", nullable: true),
                    Radnummer = table.Column<int>(type: "int", nullable: true),
                    ProduktTjanst = table.Column<string>(name: "Produkt/Tjanst", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Enhetspris = table.Column<decimal>(type: "money", nullable: true),
                    Enhet = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    SummaKr = table.Column<decimal>(name: "Summa Kr", type: "money", nullable: true),
                    Antal = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakturarad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fakturarad_Enhet",
                        column: x => x.Enhet,
                        principalTable: "Enhet",
                        principalColumn: "Enhet",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fakturarad_Faktura",
                        column: x => x.Fakturanummer,
                        principalTable: "Faktura",
                        principalColumn: "Fakturanummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Verifikation",
                columns: table => new
                {
                    Verifikation = table.Column<int>(type: "int", nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Transaktionsdatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    DebetKr = table.Column<decimal>(type: "money", nullable: true),
                    KreditKr = table.Column<decimal>(type: "money", nullable: true),
                    Bokforingsdatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    Kundnummer = table.Column<int>(type: "int", nullable: true),
                    Fakturanr = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verifikation", x => x.Verifikation);
                    table.ForeignKey(
                        name: "FK_Verifikation_Faktura",
                        column: x => x.Fakturanr,
                        principalTable: "Faktura",
                        principalColumn: "Fakturanummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Verifikation_Kund",
                        column: x => x.Kundnummer,
                        principalTable: "Kund",
                        principalColumn: "Kundnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LevFaktura",
                columns: table => new
                {
                    LevFakturanummer = table.Column<int>(type: "int", nullable: false),
                    Fakturadatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    Forfallodatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    Utskriftsdatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    Leverantörsnummer = table.Column<int>(type: "int", nullable: true),
                    BeloppExklmoms = table.Column<decimal>(name: "Belopp Exkl moms", type: "money", nullable: true),
                    MomsKr = table.Column<decimal>(name: "Moms Kr", type: "money", nullable: true),
                    BeloppInklMomsKr = table.Column<decimal>(name: "Belopp Inkl Moms Kr", type: "money", nullable: true),
                    BetaltKr = table.Column<decimal>(name: "Betalt Kr", type: "money", nullable: true),
                    Betaldatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    VarReferens = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ErRefForN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Kommentar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ErRefEfterN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Villkor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Momssats = table.Column<double>(type: "float", nullable: true),
                    VerNr = table.Column<int>(type: "int", nullable: true),
                    Godkann = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevFaktura", x => x.LevFakturanummer);
                    table.ForeignKey(
                        name: "FK_LevFaktura_Verifikation",
                        column: x => x.VerNr,
                        principalTable: "Verifikation",
                        principalColumn: "Verifikation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Momsperioder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MomsperiodStart = table.Column<DateTime>(type: "datetime", nullable: true),
                    MomsperiodSlut = table.Column<DateTime>(type: "datetime", nullable: true),
                    SenasteInbetDatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    Verifikationsnr = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Momsperioder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Momsperioder_Verifikation",
                        column: x => x.Verifikationsnr,
                        principalTable: "Verifikation",
                        principalColumn: "Verifikation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaktion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verifikation = table.Column<int>(type: "int", nullable: true),
                    Radnummer = table.Column<int>(type: "int", nullable: true),
                    DebetKr = table.Column<decimal>(type: "money", nullable: true),
                    Konto = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Kostnadsbarare = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    KreditKr = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaktion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaktion_Konto",
                        column: x => x.Konto,
                        principalTable: "Konto",
                        principalColumn: "Konto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaktion_Kostnadsbarare",
                        column: x => x.Kostnadsbarare,
                        principalTable: "Kostnadsbarare",
                        principalColumn: "Kostnadsbarare",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaktion_Verifikation",
                        column: x => x.Verifikation,
                        principalTable: "Verifikation",
                        principalColumn: "Verifikation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Betalning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transdatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    Betalsatt = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Gironr = table.Column<int>(type: "int", nullable: true),
                    Inbetalning = table.Column<decimal>(type: "money", nullable: true),
                    Utbetalning = table.Column<decimal>(type: "money", nullable: true),
                    Kundnr = table.Column<int>(type: "int", nullable: false),
                    Kundfakturanr = table.Column<int>(type: "int", nullable: true),
                    Leverantorsnr = table.Column<int>(type: "int", nullable: true),
                    Levfakturanr = table.Column<int>(type: "int", nullable: true),
                    Registreringsdatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegistreradAv = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Betalning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Betalning_Betalsatt",
                        column: x => x.Betalsatt,
                        principalTable: "Betalsatt",
                        principalColumn: "Betalsatt",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Betalning_Faktura",
                        column: x => x.Kundfakturanr,
                        principalTable: "Faktura",
                        principalColumn: "Fakturanummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Betalning_Kund",
                        column: x => x.Kundnr,
                        principalTable: "Kund",
                        principalColumn: "Kundnummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Betalning_Leverantor",
                        column: x => x.Leverantorsnr,
                        principalTable: "Leverantor",
                        principalColumn: "Leverantorsnummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Betalning_LevFaktura",
                        column: x => x.Levfakturanr,
                        principalTable: "LevFaktura",
                        principalColumn: "LevFakturanummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LevFakturaRad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevFakturanummer = table.Column<int>(type: "int", nullable: true),
                    Radnummer = table.Column<int>(type: "int", nullable: true),
                    ProduktTjanst = table.Column<string>(name: "Produkt/Tjanst", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Enhetspris = table.Column<decimal>(type: "money", nullable: true),
                    Enhet = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    SummaKr = table.Column<decimal>(name: "Summa Kr", type: "money", nullable: true),
                    Antal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevFakturaRad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevFakturaRad_Enhet",
                        column: x => x.Enhet,
                        principalTable: "Enhet",
                        principalColumn: "Enhet",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LevFakturaRad_LevFaktura",
                        column: x => x.LevFakturanummer,
                        principalTable: "LevFaktura",
                        principalColumn: "LevFakturanummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Betalsatt",
                columns: new[] { "Betalsatt", "Beskrivning" },
                values: new object[,]
                {
                    { "BG", "Bankgiro" },
                    { "PG", "Postgiro" }
                });

            migrationBuilder.InsertData(
                table: "Bokföringsar",
                columns: new[] { "Bokforingsar", "OmStangt", "Slut", "Start" },
                values: new object[] { "2020", false, new DateTime(2021, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Enhet",
                columns: new[] { "Enhet", "Beskrivning" },
                values: new object[,]
                {
                    { "Dagar", "Dagar" },
                    { "Licenser", "Licenser" },
                    { "Mil", "för milersättningar" },
                    { "Styck", "Styck" },
                    { "Timmar", "Konsultersättning per timme" },
                    { "Totalt", "Totalt" }
                });

            migrationBuilder.InsertData(
                table: "Konto",
                columns: new[] { "Konto", "arsredovisningsrad", "Benamning", "IB Debet Kr", "IB Kredit Kr", "OmDebet", "Skattekonto" },
                values: new object[,]
                {
                    { "6991", "EJ avstämt!!", "Övriga externa kostnader, avdragsgilla", 0m, null, false, "" },
                    { "6570", "RR-Räntekostn e d", "Bankkostnader", 0m, null, false, "7522" },
                    { "6421", "RR-Övriga rörelsekostnader", "Revision", 0m, null, false, "7517" },
                    { "6310", "RR-Övriga rörelsekostnader", "Företagsförsäkringar", 0m, null, false, "7517" },
                    { "6212", "RR-Övriga rörelsekostnader", "Mobiltelefoni", 0m, null, false, "7517" },
                    { "6020", "RR-Övriga rörelsekostnader", "Egna facktidskrifter", 0m, null, false, "7517" },
                    { "6072", "RR-Övriga rörelsekostnader", "Representation, ej avdragsgill", 0m, null, false, "7517" },
                    { "6071", "RR-Övriga rörelsekostnader", "Representation, avdragsgill", 0m, null, false, "7517" },
                    { "6992", "EJ avstämt!!", "Övriga externa kostnader, ej avdragsgilla", 0m, null, false, "" },
                    { "5011", "RR-Övriga rörelsekostnader", "Hyra för kontorslokaler", 0m, null, false, "7517" },
                    { "6110", "RR-Övriga rörelsekostnader", "Kontorsmateriel", 0m, null, false, "7517" },
                    { "7011", "RR-Personalkostnader", "Löner", 0m, null, false, "" },
                    { "7310", "RR-Personalkostnader", "Kontanta extraersättningar", 0m, null, false, "7514" },
                    { "7224", "RR-Personalkostnader", "Löner till företagsledare (nya pensionssystemet) Erik", 0m, null, false, "7514" },
                    { "7286", "RR-Personalkostnader", "Semesterlöner till företagsledare", 0m, null, false, "7514" },
                    { "4110", "RR-Övriga rörelsekostnader", "Inköp matriel", 0m, null, false, "7517" },
                    { "7331", "RR-Personalkostnader", "Skattefria bilersättningar", 0m, null, false, "7514" },
                    { "7333", "RR-Personalkostnader", "Ersättning för trängselskatt, skattefri", 0m, null, false, "7514" },
                    { "7389", "RR-Personalkostnader", "Övriga kostnader för förmåner  anställda", 0m, null, false, "7514" },
                    { "7521", "RR-Personalkostnader", "Arbetsgivaravgifter för löner och ersättningar (nya pensionssystemet)", 0m, null, false, "7514" },
                    { "7529", "RR-Personalkostnader", "Arbetsgivaravgifter för semester- och löneskulder (nya pensionssystemet)", 0m, null, false, "7514" },
                    { "7570", "RR-Övriga rörelsekostnader", "Premier för arbetsmarknadsförsäkringar", 0m, null, false, "7514" },
                    { "8311", "RR-Övr ränte int", "Ränteintäkter från bank", 0m, null, false, "7417" },
                    { "8910", "RR-Skatt på årets resultat", " Skatt som belastar årets resultat", 0m, null, false, "7528" },
                    { "7214", "RR-Personalkostnader", "Löner till tjänstemän (nya pensionssystemet) Ann", 0m, null, false, "7514" },
                    { "3740", "RR-Nettoomsättning", "Öres- och kronutjämning", 0m, null, false, "7410" },
                    { "6250", "RR-Övriga rörelsekostnader", "Postbefordran", 0m, null, false, "7517" },
                    { "2940", "BR-Skatteskulder", "Arb givaravgifter", 0m, null, false, "7368" },
                    { "3001", "RR-Nettoomsättning", "Försäljning inom Sverige, 25 % moms", 0m, null, false, "7410" },
                    { "1229", "EJ avstämt!!", "Ackumulerade avskrivningar på inventarier och verktyg", 0m, null, false, "" },
                    { "1510", "BR-kundfordringar", "Kundfordringar", 0m, null, false, "7251" },
                    { "1610", "EJ avstämt!!", "Kortfristiga fordringar hos Erik", 0m, null, false, "" },
                    { "1630", "BR-skattefordran", "Skatter", 0m, null, false, "" }
                });

            migrationBuilder.InsertData(
                table: "Konto",
                columns: new[] { "Konto", "arsredovisningsrad", "Benamning", "IB Debet Kr", "IB Kredit Kr", "OmDebet", "Skattekonto" },
                values: new object[,]
                {
                    { "1631", "BR-skattefordran", "Prel f-Skatt företaget", 0m, null, false, "" },
                    { "1790", "EJ avstämt!!", "Upplupna intäkter/förutbetalda konstnader", 0m, null, false, "" },
                    { "1930", "BR-Kassa och Bank", "Bank", 0m, null, false, "7281" },
                    { "2017", "EJ avstämt!!", "Årets kapitaltillskott", 0m, null, false, "" },
                    { "2081", "BR-Aktiekapital", "Aktiekapital", 0m, null, false, "7301" },
                    { "2086", "EJ avstämt!!", "Reservfond", 0m, null, false, "" },
                    { "2091", "TU-Utdelning", "Balanserad V/F", 0m, null, false, "" },
                    { "2099", "BR-Fritt eget kapital", "Årets resultat", 0m, null, false, "7302" },
                    { "1221", "EJ avstämt!!", "Inventarier", 0m, null, false, "" },
                    { "2440", "EJ avstämt!!", "Leverantörsskuld", 0m, null, false, "" },
                    { "2512", "EJ avstämt!!", " Beräknad inkomstskatt", 0m, null, false, "" },
                    { "2518", "BR-Skatteskulder", "Betald F-skatt", 0m, null, false, "7368" },
                    { "2611", "EJ avstämt!!", "Utgående moms", 0m, null, false, "" },
                    { "2431", "EJ avstämt!!", "Pågående arb fakturering", 0m, null, false, "" },
                    { "2641", "EJ avstämt!!", "Ingående moms", 0m, null, false, "" },
                    { "2650", "BR-Skatteskulder", "Redovisningskonto för moms", 0m, null, false, "7368" },
                    { "2710", "BR-Skatteskulder", "Personalskatt", 0m, null, false, "7368" },
                    { "2731", "RR-Personalkostnader", "Avräkning lagstadgade sociala avgifter", 0m, null, false, "7514" },
                    { "2820", "BR-Övr kortfristiga skulder", "Kortfristiga skulder till Erik", 0m, null, false, "7369+7650" },
                    { "2821", "BR-Övr kortfristiga skulder", "Kortfristiga skulder till Ann", 0m, null, false, "7369+7650" },
                    { "2898", "EJ avstämt!!", "Outtagen vinstutdelning", 0m, null, false, "" }
                });

            migrationBuilder.InsertData(
                table: "Meny",
                columns: new[] { "Meny", "Beskrivning", "presentationsordning" },
                values: new object[,]
                {
                    { "Registrering", "Registrering baserat på parametrar", 5 },
                    { "Rapporter", "Rapporter", 4 },
                    { "Parametrar-allm", "Allmänna parametrar", 1 },
                    { "Parametrar-bokf", "Bokföringsparametrar", 2 },
                    { "Parametrar-fakt", "Parametrar fakturering", 3 }
                });

            migrationBuilder.InsertData(
                table: "Menyval",
                columns: new[] { "Menyvalsnr", "Beskrivning", "form", "Meny", "Menyval", "query", "report", "ShellFunction" },
                values: new object[,]
                {
                    { 10, null, "Personals", null, "Personal", null, null, null },
                    { 15, null, "LevFakturas", null, "Leverantörsfakturor", null, null, null },
                    { 16, null, "Installningars", null, "Inställningar", null, null, null },
                    { 14, null, "Verifikations", null, "Verifikat", null, null, null },
                    { 13, null, "Rapports", null, "Rapporter", null, null, null },
                    { 12, null, "Projekts", null, "Projekt", null, null, null },
                    { 11, null, "Produkts", null, "Produkt", null, null, null },
                    { 9, null, "Menies", null, "Menyunderhåll", null, null, null },
                    { 2, null, "Enhets", null, "Enhet", null, null, null },
                    { 7, null, "Landskods", null, "Landskoder", null, null, null },
                    { 6, null, "Kunds", null, "Kund", null, null, null },
                    { 5, null, "Kostnadsbarares", null, "Kostnadsbärare", null, null, null },
                    { 4, null, "Kontoes", null, "Konto", null, null, null },
                    { 3, null, "Fakturas", null, "Faktura", null, null, null },
                    { 1, null, "Bokföringsar", null, "Bokf År", null, null, null },
                    { 8, null, "Leverantors", null, "Leverantör", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Momsperioder",
                columns: new[] { "Id", "MomsperiodSlut", "MomsperiodStart", "SenasteInbetDatum", "Verifikationsnr" },
                values: new object[,]
                {
                    { 4, new DateTime(2021, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 1, new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 2, new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 3, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "Personalfunktion",
                columns: new[] { "Personalfunktion", "Beskrivning" },
                values: new object[] { "VD", null });

            migrationBuilder.InsertData(
                table: "Installningar",
                columns: new[] { "Id", "Bokforingsar from", "Bokforingsar tom", "Bolagsnamn", "KontoFordranFrom", "KontoFordranKund", "KontoFordranTom", "KontoIngMoms", "KontoIntakterFrom", "KontoIntakterKund", "KontoIntakterTom", "KontoMomsAvstamning", "KontoUtgMoms", "Organisationsnr" },
                values: new object[] { 1, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Erik Hartler AB", "1510", "1510", "1510", "2641", "3001", "3001", "3740", "2650", "2611", "5556944-9035" });

            migrationBuilder.InsertData(
                table: "Personal",
                columns: new[] { "Signatur", "Efternamn", "Fornamn", "IntroViaknappar", "Mobiltelefon", "Personalfunktion", "Telefonnummer" },
                values: new object[] { "EH", "Hartler", "Erik", false, null, "VD", null });

            migrationBuilder.InsertData(
                table: "Produkt",
                columns: new[] { "Produkt/Tjanst", "Beskrivning", "Enhet", "Enhetspris" },
                values: new object[] { "Systemutveckling", "Systemutveckling", "Timmar", 850m });

            migrationBuilder.CreateIndex(
                name: "IX_Betalning_Betalsatt",
                table: "Betalning",
                column: "Betalsatt");

            migrationBuilder.CreateIndex(
                name: "IX_Betalning_Kundfakturanr",
                table: "Betalning",
                column: "Kundfakturanr");

            migrationBuilder.CreateIndex(
                name: "IX_Betalning_Kundnr",
                table: "Betalning",
                column: "Kundnr");

            migrationBuilder.CreateIndex(
                name: "IX_Betalning_Leverantorsnr",
                table: "Betalning",
                column: "Leverantorsnr");

            migrationBuilder.CreateIndex(
                name: "IX_Betalning_Levfakturanr",
                table: "Betalning",
                column: "Levfakturanr");

            migrationBuilder.CreateIndex(
                name: "IX_Faktura_Kundnummer",
                table: "Faktura",
                column: "Kundnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Faktura_Land",
                table: "Faktura",
                column: "Land");

            migrationBuilder.CreateIndex(
                name: "IX_Faktura_ProjektId",
                table: "Faktura",
                column: "ProjektId");

            migrationBuilder.CreateIndex(
                name: "IX_Fakturarad_Enhet",
                table: "Fakturarad",
                column: "Enhet");

            migrationBuilder.CreateIndex(
                name: "IX_Fakturarad_Fakturanummer",
                table: "Fakturarad",
                column: "Fakturanummer");

            migrationBuilder.CreateIndex(
                name: "IX_Installningar_KontoFordranFrom",
                table: "Installningar",
                column: "KontoFordranFrom");

            migrationBuilder.CreateIndex(
                name: "IX_Installningar_KontoFordranKund",
                table: "Installningar",
                column: "KontoFordranKund");

            migrationBuilder.CreateIndex(
                name: "IX_Installningar_KontoFordranTom",
                table: "Installningar",
                column: "KontoFordranTom");

            migrationBuilder.CreateIndex(
                name: "IX_Installningar_KontoIngMoms",
                table: "Installningar",
                column: "KontoIngMoms");

            migrationBuilder.CreateIndex(
                name: "IX_Installningar_KontoIntakterFrom",
                table: "Installningar",
                column: "KontoIntakterFrom");

            migrationBuilder.CreateIndex(
                name: "IX_Installningar_KontoIntakterKund",
                table: "Installningar",
                column: "KontoIntakterKund");

            migrationBuilder.CreateIndex(
                name: "IX_Installningar_KontoIntakterTom",
                table: "Installningar",
                column: "KontoIntakterTom");

            migrationBuilder.CreateIndex(
                name: "IX_Installningar_KontoMomsAvstamning",
                table: "Installningar",
                column: "KontoMomsAvstamning");

            migrationBuilder.CreateIndex(
                name: "IX_Installningar_KontoUtgMoms",
                table: "Installningar",
                column: "KontoUtgMoms");

            migrationBuilder.CreateIndex(
                name: "IX_Kontaktperson_Kund_Kundnummer",
                table: "Kontaktperson_Kund",
                column: "Kundnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Kontaktperson_Leverantor_Leverantorsnummer",
                table: "Kontaktperson_Leverantor",
                column: "Leverantorsnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Kund_Landskod",
                table: "Kund",
                column: "Landskod");

            migrationBuilder.CreateIndex(
                name: "IX_Leverantor_Land",
                table: "Leverantor",
                column: "Land");

            migrationBuilder.CreateIndex(
                name: "IX_LevFaktura_VerNr",
                table: "LevFaktura",
                column: "VerNr");

            migrationBuilder.CreateIndex(
                name: "IX_LevFakturaRad_Enhet",
                table: "LevFakturaRad",
                column: "Enhet");

            migrationBuilder.CreateIndex(
                name: "IX_LevFakturaRad_LevFakturanummer",
                table: "LevFakturaRad",
                column: "LevFakturanummer");

            migrationBuilder.CreateIndex(
                name: "IX_MallTransaktioner_Konto",
                table: "MallTransaktioner",
                column: "Konto");

            migrationBuilder.CreateIndex(
                name: "IX_MallTransaktioner_Kortkod",
                table: "MallTransaktioner",
                column: "Kortkod");

            migrationBuilder.CreateIndex(
                name: "IX_MallTransaktioner_Kostnadsbarare",
                table: "MallTransaktioner",
                column: "Kostnadsbarare");

            migrationBuilder.CreateIndex(
                name: "IX_MallVerifikat_Konto100Proc",
                table: "MallVerifikat",
                column: "Konto100Proc");

            migrationBuilder.CreateIndex(
                name: "IX_Menyval_Meny",
                table: "Menyval",
                column: "Meny");

            migrationBuilder.CreateIndex(
                name: "IX_Menyval_Pers_funkt_Menyvalsnummer",
                table: "Menyval_Pers_funkt",
                column: "Menyvalsnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Menyval_Pers_funkt_Personalfunktion",
                table: "Menyval_Pers_funkt",
                column: "Personalfunktion");

            migrationBuilder.CreateIndex(
                name: "IX_Menyval_Person_Anvandare",
                table: "Menyval_Person",
                column: "Anvandare");

            migrationBuilder.CreateIndex(
                name: "IX_Menyval_Person_Menyvalsnummer",
                table: "Menyval_Person",
                column: "Menyvalsnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Momsperioder_Verifikationsnr",
                table: "Momsperioder",
                column: "Verifikationsnr");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_Personalfunktion",
                table: "Personal",
                column: "Personalfunktion");

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_Enhet",
                table: "Produkt",
                column: "Enhet");

            migrationBuilder.CreateIndex(
                name: "IX_Projekt_Kundnr",
                table: "Projekt",
                column: "Kundnr");

            migrationBuilder.CreateIndex(
                name: "IX_ProjektAktivitet_Leverantorsnummer",
                table: "ProjektAktivitet",
                column: "Leverantorsnummer");

            migrationBuilder.CreateIndex(
                name: "IX_ProjektAktivitet_Projektnummer",
                table: "ProjektAktivitet",
                column: "Projektnummer");

            migrationBuilder.CreateIndex(
                name: "IX_RapportRad_Rapport",
                table: "RapportRad",
                column: "Rapport");

            migrationBuilder.CreateIndex(
                name: "IX_Transaktion_Konto",
                table: "Transaktion",
                column: "Konto");

            migrationBuilder.CreateIndex(
                name: "IX_Transaktion_Kostnadsbarare",
                table: "Transaktion",
                column: "Kostnadsbarare");

            migrationBuilder.CreateIndex(
                name: "IX_Transaktion_Verifikation",
                table: "Transaktion",
                column: "Verifikation");

            migrationBuilder.CreateIndex(
                name: "IX_Verifikation_Fakturanr",
                table: "Verifikation",
                column: "Fakturanr");

            migrationBuilder.CreateIndex(
                name: "IX_Verifikation_Kundnummer",
                table: "Verifikation",
                column: "Kundnummer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Betalning");

            migrationBuilder.DropTable(
                name: "Bokföringsar");

            migrationBuilder.DropTable(
                name: "Fakturarad");

            migrationBuilder.DropTable(
                name: "Installningar");

            migrationBuilder.DropTable(
                name: "Kontaktperson_Kund");

            migrationBuilder.DropTable(
                name: "Kontaktperson_Leverantor");

            migrationBuilder.DropTable(
                name: "LevFakturaRad");

            migrationBuilder.DropTable(
                name: "MallTransaktioner");

            migrationBuilder.DropTable(
                name: "Menyval_Pers_funkt");

            migrationBuilder.DropTable(
                name: "Menyval_Person");

            migrationBuilder.DropTable(
                name: "Momsperioder");

            migrationBuilder.DropTable(
                name: "Produkt");

            migrationBuilder.DropTable(
                name: "ProjektAktivitet");

            migrationBuilder.DropTable(
                name: "RapportRad");

            migrationBuilder.DropTable(
                name: "Transaktion");

            migrationBuilder.DropTable(
                name: "Betalsatt");

            migrationBuilder.DropTable(
                name: "LevFaktura");

            migrationBuilder.DropTable(
                name: "MallVerifikat");

            migrationBuilder.DropTable(
                name: "Menyval");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "Enhet");

            migrationBuilder.DropTable(
                name: "Leverantor");

            migrationBuilder.DropTable(
                name: "Rapport");

            migrationBuilder.DropTable(
                name: "Kostnadsbarare");

            migrationBuilder.DropTable(
                name: "Verifikation");

            migrationBuilder.DropTable(
                name: "Konto");

            migrationBuilder.DropTable(
                name: "Meny");

            migrationBuilder.DropTable(
                name: "Personalfunktion");

            migrationBuilder.DropTable(
                name: "Faktura");

            migrationBuilder.DropTable(
                name: "Projekt");

            migrationBuilder.DropTable(
                name: "Kund");

            migrationBuilder.DropTable(
                name: "Landskod");
        }
    }
}
