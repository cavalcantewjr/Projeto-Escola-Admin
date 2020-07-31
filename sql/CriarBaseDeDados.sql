CREATE DATABASE [MinhaApiEscola]
GO

USE [MinhaApiCore]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enderecos](
	[Id] [uniqueidentifier] NOT NULL,
	[FornecedorId] [uniqueidentifier] NOT NULL,
	[Logradouro] [varchar](200) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[Complemento] [varchar](250) NULL,
	[Cep] [varchar](20) NOT NULL,
	[Bairro] [varchar](100) NOT NULL,
	[Cidade] [varchar](100) NOT NULL,
	[Estado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Enderecos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Escolas]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escolas](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Escolas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tumras]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turmas](
	[Id] [uniqueidentifier] NOT NULL,
	[EscolaId] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[Descricao] [varchar](1000) NOT NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Escola] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Enderecos]  WITH CHECK ADD  CONSTRAINT [FK_Enderecos_Escolas_EscolaId] FOREIGN KEY([EscolaId])
REFERENCES [dbo].[Escolas] ([Id])
GO
ALTER TABLE [dbo].[Enderecos] CHECK CONSTRAINT [FK_Enderecos_Escolas_EscolaId]
GO
ALTER TABLE [dbo].[Turmas]  WITH CHECK ADD  CONSTRAINT [FK_Turmas_Escolas_EscolasId] FOREIGN KEY([EscolaId])
REFERENCES [dbo].[Fornecedores] ([Id])
GO
ALTER TABLE [dbo].[Turmas] CHECK CONSTRAINT [FK_Turmas_Escolas_EscolasId]
GO


