using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCRUD.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { "6250", "RR-Övriga rörelsekostnader", "Postbefordran", 0m, null, false, "7517" },
                    { "6071", "RR-Övriga rörelsekostnader", "Representation, avdragsgill", 0m, null, false, "7517" },
                    { "6110", "RR-Övriga rörelsekostnader", "Kontorsmateriel", 0m, null, false, "7517" },
                    { "6072", "RR-Övriga rörelsekostnader", "Representation, ej avdragsgill", 0m, null, false, "7517" },
                    { "6992", "EJ avstämt!!", "Övriga externa kostnader, ej avdragsgilla", 0m, null, false, "" },
                    { "6020", "RR-Övriga rörelsekostnader", "Egna facktidskrifter", 0m, null, false, "7517" },
                    { "6212", "RR-Övriga rörelsekostnader", "Mobiltelefoni", 0m, null, false, "7517" },
                    { "7011", "RR-Personalkostnader", "Löner", 0m, null, false, "" },
                    { "7310", "RR-Personalkostnader", "Kontanta extraersättningar", 0m, null, false, "7514" },
                    { "7224", "RR-Personalkostnader", "Löner till företagsledare (nya pensionssystemet) Erik", 0m, null, false, "7514" },
                    { "7286", "RR-Personalkostnader", "Semesterlöner till företagsledare", 0m, null, false, "7514" },
                    { "5011", "RR-Övriga rörelsekostnader", "Hyra för kontorslokaler", 0m, null, false, "7517" },
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
                    { "4110", "RR-Övriga rörelsekostnader", "Inköp matriel", 0m, null, false, "7517" },
                    { "2940", "BR-Skatteskulder", "Arb givaravgifter", 0m, null, false, "7368" },
                    { "1221", "EJ avstämt!!", "Inventarier", 0m, null, false, "" },
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
                    { "3001", "RR-Nettoomsättning", "Försäljning inom Sverige, 25 % moms", 0m, null, false, "7410" },
                    { "2017", "EJ avstämt!!", "Årets kapitaltillskott", 0m, null, false, "" },
                    { "2081", "BR-Aktiekapital", "Aktiekapital", 0m, null, false, "7301" },
                    { "2086", "EJ avstämt!!", "Reservfond", 0m, null, false, "" },
                    { "2091", "TU-Utdelning", "Balanserad V/F", 0m, null, false, "" },
                    { "2099", "BR-Fritt eget kapital", "Årets resultat", 0m, null, false, "7302" },
                    { "1930", "BR-Kassa och Bank", "Bank", 0m, null, false, "7281" },
                    { "2440", "EJ avstämt!!", "Leverantörsskuld", 0m, null, false, "" },
                    { "2431", "EJ avstämt!!", "Pågående arb fakturering", 0m, null, false, "" },
                    { "2898", "EJ avstämt!!", "Outtagen vinstutdelning", 0m, null, false, "" },
                    { "2820", "BR-Övr kortfristiga skulder", "Kortfristiga skulder till Erik", 0m, null, false, "7369+7650" },
                    { "2731", "RR-Personalkostnader", "Avräkning lagstadgade sociala avgifter", 0m, null, false, "7514" },
                    { "2710", "BR-Skatteskulder", "Personalskatt", 0m, null, false, "7368" },
                    { "2821", "BR-Övr kortfristiga skulder", "Kortfristiga skulder till Ann", 0m, null, false, "7369+7650" },
                    { "2641", "EJ avstämt!!", "Ingående moms", 0m, null, false, "" },
                    { "2611", "EJ avstämt!!", "Utgående moms", 0m, null, false, "" },
                    { "2518", "BR-Skatteskulder", "Betald F-skatt", 0m, null, false, "7368" },
                    { "2512", "EJ avstämt!!", " Beräknad inkomstskatt", 0m, null, false, "" },
                    { "2650", "BR-Skatteskulder", "Redovisningskonto för moms", 0m, null, false, "7368" }
                });

            migrationBuilder.InsertData(
                table: "Meny",
                columns: new[] { "Meny", "Beskrivning", "presentationsordning" },
                values: new object[,]
                {
                    { "Parametrar-allm", "Allmänna parametrar", 1 },
                    { "Parametrar-bokf", "Bokföringsparametrar", 2 },
                    { "Parametrar-fakt", "Parametrar fakturering", 3 },
                    { "Rapporter", "Rapporter", 4 },
                    { "Registrering", "Registrering baserat på parametrar", 5 }
                });

            migrationBuilder.InsertData(
                table: "Menyval",
                columns: new[] { "Menyvalsnr", "Beskrivning", "form", "Meny", "Menyval", "query", "report", "ShellFunction" },
                values: new object[,]
                {
                    { 2, "Allmänna parametrar", null, null, "Bokf År", null, null, null },
                    { 1, "Allmänna parametrar", null, null, "Bokf År", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Momsperioder",
                columns: new[] { "Id", "MomsperiodSlut", "MomsperiodStart", "SenasteInbetDatum", "Verifikationsnr" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 4, new DateTime(2021, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 1, new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 2, new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Betalsatt",
                keyColumn: "Betalsatt",
                keyValue: "BG");

            migrationBuilder.DeleteData(
                table: "Betalsatt",
                keyColumn: "Betalsatt",
                keyValue: "PG");

            migrationBuilder.DeleteData(
                table: "Bokföringsar",
                keyColumn: "Bokforingsar",
                keyValue: "2020");

            migrationBuilder.DeleteData(
                table: "Enhet",
                keyColumn: "Enhet",
                keyValue: "Dagar");

            migrationBuilder.DeleteData(
                table: "Enhet",
                keyColumn: "Enhet",
                keyValue: "Licenser");

            migrationBuilder.DeleteData(
                table: "Enhet",
                keyColumn: "Enhet",
                keyValue: "Mil");

            migrationBuilder.DeleteData(
                table: "Enhet",
                keyColumn: "Enhet",
                keyValue: "Styck");

            migrationBuilder.DeleteData(
                table: "Enhet",
                keyColumn: "Enhet",
                keyValue: "Totalt");

            migrationBuilder.DeleteData(
                table: "Installningar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "1221");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "1229");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "1610");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "1630");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "1631");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "1790");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "1930");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2017");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2081");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2086");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2091");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2099");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2431");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2440");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2512");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2518");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2710");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2731");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2820");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2821");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2898");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2940");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "4110");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "5011");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "6020");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "6071");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "6072");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "6110");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "6212");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "6250");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "6310");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "6421");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "6570");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "6991");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "6992");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "7011");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "7214");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "7224");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "7286");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "7310");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "7331");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "7333");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "7389");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "7521");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "7529");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "7570");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "8311");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "8910");

            migrationBuilder.DeleteData(
                table: "Meny",
                keyColumn: "Meny",
                keyValue: "Parametrar-allm");

            migrationBuilder.DeleteData(
                table: "Meny",
                keyColumn: "Meny",
                keyValue: "Parametrar-bokf");

            migrationBuilder.DeleteData(
                table: "Meny",
                keyColumn: "Meny",
                keyValue: "Parametrar-fakt");

            migrationBuilder.DeleteData(
                table: "Meny",
                keyColumn: "Meny",
                keyValue: "Rapporter");

            migrationBuilder.DeleteData(
                table: "Meny",
                keyColumn: "Meny",
                keyValue: "Registrering");

            migrationBuilder.DeleteData(
                table: "Menyval",
                keyColumn: "Menyvalsnr",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menyval",
                keyColumn: "Menyvalsnr",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Momsperioder",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Momsperioder",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Momsperioder",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Momsperioder",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "Signatur",
                keyValue: "EH");

            migrationBuilder.DeleteData(
                table: "Produkt",
                keyColumn: "Produkt/Tjanst",
                keyValue: "Systemutveckling");

            migrationBuilder.DeleteData(
                table: "Enhet",
                keyColumn: "Enhet",
                keyValue: "Timmar");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "1510");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2611");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2641");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "2650");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "3001");

            migrationBuilder.DeleteData(
                table: "Konto",
                keyColumn: "Konto",
                keyValue: "3740");

            migrationBuilder.DeleteData(
                table: "Personalfunktion",
                keyColumn: "Personalfunktion",
                keyValue: "VD");
        }
    }
}
