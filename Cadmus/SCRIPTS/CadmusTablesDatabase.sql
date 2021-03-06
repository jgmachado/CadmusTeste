USE [Cadmus]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 07/01/2013 11:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estados](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Pais] [varchar](50) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Sigla] [char](2) NOT NULL,
	[Regiao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cidades]    Script Date: 07/01/2013 11:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cidades](
	[Codigo] [int] NOT NULL,
	[Estado] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Capital] [bit] NOT NULL,
 CONSTRAINT [PK_Cidades] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Cidades_Estados]    Script Date: 07/01/2013 11:03:24 ******/
ALTER TABLE [dbo].[Cidades]  WITH CHECK ADD  CONSTRAINT [FK_Cidades_Estados] FOREIGN KEY([Estado])
REFERENCES [dbo].[Estados] ([Codigo])
GO
ALTER TABLE [dbo].[Cidades] CHECK CONSTRAINT [FK_Cidades_Estados]
GO
