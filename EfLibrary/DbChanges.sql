--alter table [dbo].betalsatt alter column [Betalsatt] varchar(10) not null
alter table [dbo].betalning alter column [Betalsatt] varchar(10) not null
alter table [dbo].betalning add Id INT not null IDENTITY(1,1)
ALTER TABLE [dbo].betalning ADD  CONSTRAINT [PK_betalning] PRIMARY KEY CLUSTERED 
(
	ID ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


alter table [dbo].kund alter column kundnummer int not null  --IDENTITY(1,1) 
alter table [dbo].betalning alter column kundnr int not null

alter table  [dbo].[Bokföringsar] alter column [Bokforingsar] varchar(4) not null
ALTER TABLE [dbo].Bokföringsar ADD  CONSTRAINT [PK_Bokföringsar] PRIMARY KEY CLUSTERED 
(
	[Bokforingsar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

alter table  [dbo].[Enhet] alter column [Enhet]  varchar(15) not null
ALTER TABLE [dbo].[Enhet] ADD  CONSTRAINT [PK_Enhet] PRIMARY KEY CLUSTERED 
(
	[Enhet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

alter table  [dbo].[Faktura]  alter column  [Fakturanummer]  int not null
ALTER TABLE [dbo].Faktura ADD  CONSTRAINT [PK_Faktura] PRIMARY KEY CLUSTERED 
(
	[Fakturanummer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table  [dbo].[Faktura]  alter column  Projekt  varchar(5)
alter table  [dbo].[Faktura]  add  ProjektId  int

alter table  [dbo].[Faktura]  alter column  land  varchar(5)
alter table  [dbo].[Faktura]  alter column  vernr int

alter table [dbo].[Fakturarad]  add Id INT not null IDENTITY(1,1)
ALTER TABLE [dbo].[Fakturarad] ADD  CONSTRAINT [PK_Fakturarad] PRIMARY KEY CLUSTERED 
(
	Id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

alter table [dbo].[Installningar]  add Id INT not null IDENTITY(1,1)
alter table  [dbo].[Installningar]  alter column  [KontoIngMoms]  varchar(10)
alter table  [dbo].[Installningar]  alter column  [KontoUtgMoms]  varchar(10)
alter table  [dbo].[Installningar]  alter column  [KontoMomsAvstamning]   varchar(10)
alter table  [dbo].[Installningar]  alter column  [KontoIntakterFrom]   varchar(10)
alter table  [dbo].[Installningar]  alter column  [KontoIntakterTom]   varchar(10)
alter table  [dbo].[Installningar]  alter column  [KontoFordranFrom]   varchar(10)
alter table  [dbo].[Installningar]  alter column  [KontoFordranTom]   varchar(10)
alter table  [dbo].[Installningar]  alter column  [KontoFordranKund]    varchar(10)
alter table  [dbo].[Installningar]  alter column   [KontoIntakterKund]    varchar(10)


ALTER TABLE [dbo].[Installningar] ADD  CONSTRAINT [PK_Installningar] PRIMARY KEY CLUSTERED 
(
	Id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

alter table [dbo].[Kontaktperson_Kund]   add Id INT not null IDENTITY(1,1)
ALTER TABLE [dbo].[Kontaktperson_Kund] ADD  CONSTRAINT [PK_Kontaktperson_Kund] PRIMARY KEY CLUSTERED 
(
	Id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
 
update Kontaktperson_Kund set [Kundnummer]=null where kundnummer=0

select distinct kundnummer from Kund


alter table   [dbo].[Kontaktperson_Leverantor]  add Id INT not null IDENTITY(1,1)
ALTER TABLE [dbo].[Kontaktperson_Leverantor] ADD  CONSTRAINT [PK_Kontaktperson_Leverantor] PRIMARY KEY CLUSTERED 
(
	Id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
 
alter table [dbo].[Konto]  alter column  Konto  varchar(10) not null
ALTER TABLE [dbo].[Konto] ADD  CONSTRAINT [PK_Konto] PRIMARY KEY CLUSTERED 
(
	Konto ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

alter table [dbo].[Kostnadsbarare]   alter column  Kostnadsbarare  varchar(15) not null
ALTER TABLE [dbo].Kostnadsbarare ADD  CONSTRAINT [PK_Kostnadsbarare] PRIMARY KEY CLUSTERED 
(
	Kostnadsbarare ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].Kund add  [Landskod] varchar(5) 
alter table [dbo].[Kund] ADD  CONSTRAINT [PK_Kund] PRIMARY KEY CLUSTERED 
(
	[Kundnummer]  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].[Landskod] alter column  [Landskod] varchar(5) not null
alter table [dbo].[Landskod] ADD  CONSTRAINT [PK_Landskod] PRIMARY KEY CLUSTERED 
(
	[Landskod]   ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

alter table [dbo].[Leverantor] alter column [Leverantorsnummer] int   not null
alter table [dbo].[Leverantor]  ADD  CONSTRAINT [PK_Leverantor] PRIMARY KEY CLUSTERED 
(
	[Leverantorsnummer]   ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].[Leverantor] alter column land varchar(5)

alter table [dbo].[LevFaktura] alter column [LevFakturanummer] int not null
alter table [dbo].[LevFaktura] ADD  CONSTRAINT [PK_LevFaktura] PRIMARY KEY CLUSTERED 
(
	[LevFakturanummer]   ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].[LevFaktura] alter column  [VerNr] int

alter table [dbo].[LevFakturaRad]  add Id INT not null IDENTITY(1,1)
alter table [dbo].[LevFakturaRad]  ADD  CONSTRAINT [PK_LevFakturaRad] PRIMARY KEY CLUSTERED 
(
	Id   ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].[LevFakturaRad] alter column  enhet varchar(15) 
alter table [dbo].[MallTransaktioner] alter column [Kortkod] varchar(15) not null
alter table [dbo].[MallTransaktioner]  add Id INT not null IDENTITY(1,1)
alter table [dbo].[MallTransaktioner] alter column konto varchar(10)
alter table [dbo].[MallTransaktioner] alter column [Kostnadsbarare]  varchar(15)
alter table [dbo].[MallTransaktioner] ADD  CONSTRAINT [PK_MallTransaktioner] PRIMARY KEY CLUSTERED 
(
	ID  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].[MallVerifikat]  alter column [Kortkod] varchar(15) not null
alter table [dbo].[MallVerifikat] alter column [Konto100Proc] varchar(10)
alter table [dbo].[MallVerifikat] ADD  CONSTRAINT [PK_MallVerifikat] PRIMARY KEY CLUSTERED 
(
	[Kortkod]  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

alter table [dbo].[Meny]   alter column [Meny] varchar(15) not null
alter table [dbo].[Meny] ADD  CONSTRAINT [PK_Meny] PRIMARY KEY CLUSTERED 
(
	[Meny]  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].[Menyval]  alter column [Menyvalsnr] int  not null
alter table [dbo].[Menyval]   alter column [Meny] varchar(15)
alter table [dbo].[Menyval] ADD  CONSTRAINT [PK_Menyval] PRIMARY KEY CLUSTERED 
(
	[Menyvalsnr]  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].[Menyval_Pers_funkt] alter column [Personalfunktion] varchar(20) not null
alter table [dbo].[Menyval_Pers_funkt]  add Id INT not null IDENTITY(1,1)

alter table [dbo].[Menyval_Pers_funkt] ADD  CONSTRAINT [PK_Menyval_Pers_funkt] PRIMARY KEY CLUSTERED 
(
	ID  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].[Menyval_Person]  add Id INT not null IDENTITY(1,1)
alter table [dbo].[Menyval_Person] alter column [Anvandare] varchar(10)
alter table [dbo].[Menyval_Person] ADD  CONSTRAINT [PK_Menyval_Person] PRIMARY KEY CLUSTERED 
(
	ID  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].[Momsperioder] add Id INT not null IDENTITY(1,1)
alter table [dbo].[Momsperioder] ADD  CONSTRAINT [PK_Momsperioder] PRIMARY KEY CLUSTERED 
(
	ID  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].[Personal] alter column [Signatur] varchar(10) not null
alter table [dbo].[Personal] alter column [Personalfunktion]  varchar(20)
alter table [dbo].[Personal]  ADD  CONSTRAINT [PK_Personal] PRIMARY KEY CLUSTERED 
(
	[Signatur]  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].[Personalfunktion] alter column [Personalfunktion] varchar(20) not null
alter table [dbo].[Personalfunktion]   ADD  CONSTRAINT [PK_Personalfunktion] PRIMARY KEY CLUSTERED 
(
	[Personalfunktion]  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

alter table [dbo].[Produkt] alter column [Produkt/Tjanst] varchar(50) not null
alter table [dbo].[Produkt]   ADD  CONSTRAINT [PK_Produkt] PRIMARY KEY CLUSTERED 
(
	[Produkt/Tjanst]  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].[Produkt]  alter column [Enhet] varchar(15) not null

alter table [dbo].[Projekt] alter column [Projektnr]  INT not null  
alter table [dbo].[Projekt] add CONSTRAINT [PK_Projekt] PRIMARY KEY CLUSTERED 
(
	[Projektnr]  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].[ProjektAktivitet] add Id INT not null IDENTITY(1,1)
alter table [dbo].[ProjektAktivitet] ADD  CONSTRAINT [PK_ProjektAktivitet] PRIMARY KEY CLUSTERED 
(
	ID  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].[Rapport] alter column [Rapport] varchar(10) not null
alter table [dbo].[Rapport]  ADD  CONSTRAINT [PK_Rapport] PRIMARY KEY CLUSTERED 
(
	Rapport ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

alter table [dbo].[Rapportrad] alter column [Rapport] varchar(10) not null
alter table [dbo].[Rapportrad] add Id INT not null IDENTITY(1,1)
alter table [dbo].[Rapportrad] alter column kontofrom varchar(10)
alter table [dbo].[Rapportrad] alter column kontotom varchar(10)

alter table [dbo].[Rapportrad] ADD  CONSTRAINT [PK_Rapportrad] PRIMARY KEY CLUSTERED 
(
	ID  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].[Transaktion] add Id INT not null IDENTITY(1,1)
alter table [dbo].[Transaktion] alter column konto  varchar(10)
alter table [dbo].[Transaktion] alter column kostnadsbarare  varchar(15)

alter table [dbo].[Transaktion] ADD  CONSTRAINT [PK_Transaktion] PRIMARY KEY CLUSTERED 
(
	ID  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
alter table [dbo].[Verifikation]  alter column  [Verifikation] int not null
alter table [dbo].[Verifikation] ADD  CONSTRAINT [PK_Verifikation] PRIMARY KEY CLUSTERED 
(
	Verifikation  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

alter table [dbo].[Verifikation]  alter column [Kundnummer] int  
alter table [dbo].[Verifikation]  alter column [Fakturanr] int


