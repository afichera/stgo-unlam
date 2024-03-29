USE [STGO]
GO
/****** Object:  User [stgo]    Script Date: 10/27/2012 18:35:40 ******/
--CREATE USER [stgo] FOR LOGIN [stgo] WITH DEFAULT_SCHEMA=[dbo]
GO


/****** Object:  Table [dbo].[Parametro]    Script Date: 10/27/2012 18:35:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Parametro](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[clave] [varchar](20) NOT NULL,
	[valor] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Parametro] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Empresa]    Script Date: 10/27/2012 18:35:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empresa](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[razonSocial] [varchar](100) NOT NULL,
	[cuit] [varchar](13) NOT NULL,
	[telefono] [varchar](20) NULL,
	[maximoSalas] [smallint] NULL,
	[activa] [tinyint] NULL,
	[userId] [uniqueidentifier] NOT NULL,
	[fechaHoraBaja] [datetime] NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Registracion]    Script Date: 10/27/2012 18:35:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Registracion](
	[razonSocial] [varchar](100) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[cuit] [varchar](13) NOT NULL,
	[telefono] [varchar](20) NULL,
	[passw] [varchar](250) NOT NULL,
	[fechaHoraRegistro] [datetime] NULL,
	[pendiente] [tinyint] NULL,
	[userId][uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Registracion] PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Sala]    Script Date: 10/27/2012 18:35:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sala](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[permiteMultiplo] [tinyint] NULL,
	[frecuencia] [int] NOT NULL,
	[horaInicio] [datetime] NULL,
	[horaFin] [datetime] NULL,
	[empresaId] [bigint] NOT NULL,
	[fechaHoraBaja] [datetime] NULL,
 CONSTRAINT [PK_Sala] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Turno]    Script Date: 10/27/2012 18:35:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Turno](
	[id] [bigint] IDENTITY(100,1) NOT NULL,
	[reservador] [varchar](100) NOT NULL,
	[fechaHoraInicio] [datetime] NULL,
	[fechaHoraFin] [datetime] NULL,
	[descripcion] [varchar](200) NULL,
	[salaId] [bigint] NOT NULL,
 CONSTRAINT [PK_Turno] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF__Registrac__fecha__0CBAE877]    Script Date: 10/27/2012 18:35:39 ******/
ALTER TABLE [dbo].[Registracion] ADD  DEFAULT (getdate()) FOR [fechaHoraRegistro]
GO
/****** Object:  ForeignKey [FK__Sala__empresaId__07020F21]    Script Date: 10/27/2012 18:35:39 ******/
ALTER TABLE [dbo].[Sala]  WITH CHECK ADD FOREIGN KEY([empresaId])
REFERENCES [dbo].[Empresa] ([id])
GO
/****** Object:  ForeignKey [FK__Turno__salaId__09DE7BCC]    Script Date: 10/27/2012 18:35:39 ******/
ALTER TABLE [dbo].[Turno]  WITH CHECK ADD FOREIGN KEY([salaId])
REFERENCES [dbo].[Sala] ([id])
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[Registracion]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO