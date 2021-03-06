USE [master]
GO
/****** Object:  Database [Treinamento]    Script Date: 2017-02-26 4:18:25 PM ******/
CREATE DATABASE [Treinamento]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Treinamento', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Treinamento.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Treinamento_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Treinamento_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Treinamento] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Treinamento].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Treinamento] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [Treinamento] SET ANSI_NULLS ON 
GO
ALTER DATABASE [Treinamento] SET ANSI_PADDING ON 
GO
ALTER DATABASE [Treinamento] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [Treinamento] SET ARITHABORT ON 
GO
ALTER DATABASE [Treinamento] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Treinamento] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Treinamento] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Treinamento] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Treinamento] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [Treinamento] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [Treinamento] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Treinamento] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [Treinamento] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Treinamento] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Treinamento] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Treinamento] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Treinamento] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Treinamento] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Treinamento] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Treinamento] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Treinamento] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Treinamento] SET RECOVERY FULL 
GO
ALTER DATABASE [Treinamento] SET  MULTI_USER 
GO
ALTER DATABASE [Treinamento] SET PAGE_VERIFY NONE  
GO
ALTER DATABASE [Treinamento] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Treinamento] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Treinamento] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Treinamento] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Treinamento]
GO
/****** Object:  Table [dbo].[Assunto]    Script Date: 2017-02-26 4:18:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assunto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NULL,
 CONSTRAINT [PK_Assunto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Capitulo]    Script Date: 2017-02-26 4:18:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Capitulo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[IdCurso] [int] NOT NULL,
	[Pontos] [int] NOT NULL,
 CONSTRAINT [PK_Capitulo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Curso]    Script Date: 2017-02-26 4:18:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[IdAutor] [int] NOT NULL,
	[IdAssunto] [int] NOT NULL,
	[Classificacao] [int] NULL,
	[DataCriacao] [datetime] NOT NULL,
	[Nivel] [varchar](50) NULL,
	[Img] [varchar](100) NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Curso_Classificacao]    Script Date: 2017-02-26 4:18:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso_Classificacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCurso] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Nota] [int] NULL,
 CONSTRAINT [PK_Curso_Classificacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Curso_Descricao]    Script Date: 2017-02-26 4:18:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso_Descricao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](500) NULL,
	[IdCurso] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Documento]    Script Date: 2017-02-26 4:18:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCurso] [int] NOT NULL,
	[Descricao] [varchar](max) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
	[Arquivo] [varbinary](max) NULL,
 CONSTRAINT [PK_Documento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Funcionalidade]    Script Date: 2017-02-26 4:18:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionalidade](
	[Id] [int] NOT NULL,
	[Nome] [varchar](50) NULL,
 CONSTRAINT [PK_Funcionalidade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 2017-02-26 4:18:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[Id] [int] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permissao]    Script Date: 2017-02-26 4:18:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissao](
	[IdPerfil] [int] NOT NULL,
	[IdFuncionalidade] [int] NOT NULL,
 CONSTRAINT [PK_Permissao] PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC,
	[IdFuncionalidade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Treinamento]    Script Date: 2017-02-26 4:18:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treinamento](
	[IdUsuario] [int] NOT NULL,
	[IdCurso] [int] NOT NULL,
	[DataInicio] [datetime] NOT NULL,
	[UltimoAcesso] [datetime] NOT NULL,
	[DataConclusao] [datetime] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Treinamento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Treinamento_Capitulo]    Script Date: 2017-02-26 4:18:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treinamento_Capitulo](
	[IdUsuario] [int] NOT NULL,
	[IdCurso] [int] NOT NULL,
	[IdCapitulo] [int] NOT NULL,
	[Pontos] [int] NOT NULL,
	[DataConclusao] [datetime] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Treinamento_Capitulo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Trilha]    Script Date: 2017-02-26 4:18:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trilha](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Ativa] [bit] NOT NULL,
 CONSTRAINT [PK_Trilha] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Trilha_Curso]    Script Date: 2017-02-26 4:18:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trilha_Curso](
	[IdTrilha] [int] NOT NULL,
	[IdCurso] [int] NOT NULL,
 CONSTRAINT [PK_Trilha_Curso] PRIMARY KEY CLUSTERED 
(
	[IdTrilha] ASC,
	[IdCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 2017-02-26 4:18:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
	[Ativo] [bit] NOT NULL,
	[IdPerfil] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Video]    Script Date: 2017-02-26 4:18:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Video](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](80) NOT NULL,
	[Duracao] [int] NOT NULL,
	[IdCapitulo] [int] NOT NULL,
	[CodigoVideo] [varchar](100) NULL,
	[Thumbnail] [varchar](200) NULL,
 CONSTRAINT [PK_Video] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Assunto] ON 

INSERT [dbo].[Assunto] ([Id], [Nome]) VALUES (2, N'Finanças')
INSERT [dbo].[Assunto] ([Id], [Nome]) VALUES (3, N'SQL Server')
INSERT [dbo].[Assunto] ([Id], [Nome]) VALUES (4, N'ASP.NET')
INSERT [dbo].[Assunto] ([Id], [Nome]) VALUES (5, N'Sistema de Apontamento de Horas')
INSERT [dbo].[Assunto] ([Id], [Nome]) VALUES (6, N'RH')
INSERT [dbo].[Assunto] ([Id], [Nome]) VALUES (7, N'Diversos')
INSERT [dbo].[Assunto] ([Id], [Nome]) VALUES (8, N'VENDAS')
INSERT [dbo].[Assunto] ([Id], [Nome]) VALUES (9, N'Desenvolvimento')
INSERT [dbo].[Assunto] ([Id], [Nome]) VALUES (10, N'Estátistica')
SET IDENTITY_INSERT [dbo].[Assunto] OFF
SET IDENTITY_INSERT [dbo].[Capitulo] ON 

INSERT [dbo].[Capitulo] ([Id], [Nome], [IdCurso], [Pontos]) VALUES (1, N'Intro', 1, 5)
INSERT [dbo].[Capitulo] ([Id], [Nome], [IdCurso], [Pontos]) VALUES (2, N'Conceitos basicos', 1, 3)
INSERT [dbo].[Capitulo] ([Id], [Nome], [IdCurso], [Pontos]) VALUES (3, N'Linguagem sql', 1, 6)
INSERT [dbo].[Capitulo] ([Id], [Nome], [IdCurso], [Pontos]) VALUES (4, N'Comandos DDL', 1, 5)
INSERT [dbo].[Capitulo] ([Id], [Nome], [IdCurso], [Pontos]) VALUES (5, N'Intro', 2, 5)
INSERT [dbo].[Capitulo] ([Id], [Nome], [IdCurso], [Pontos]) VALUES (6, N'Apontamento diario', 2, 5)
INSERT [dbo].[Capitulo] ([Id], [Nome], [IdCurso], [Pontos]) VALUES (7, N'Como fazer o relatório mensal', 2, 3)
INSERT [dbo].[Capitulo] ([Id], [Nome], [IdCurso], [Pontos]) VALUES (8, N'Introdução', 15, 3)
INSERT [dbo].[Capitulo] ([Id], [Nome], [IdCurso], [Pontos]) VALUES (9, N'Conceitos Básicos', 15, 6)
INSERT [dbo].[Capitulo] ([Id], [Nome], [IdCurso], [Pontos]) VALUES (10, N'Tomadas de Decisões', 15, 7)
INSERT [dbo].[Capitulo] ([Id], [Nome], [IdCurso], [Pontos]) VALUES (11, N'Operadores', 15, 6)
SET IDENTITY_INSERT [dbo].[Capitulo] OFF
SET IDENTITY_INSERT [dbo].[Curso] ON 

INSERT [dbo].[Curso] ([Id], [Nome], [IdAutor], [IdAssunto], [Classificacao], [DataCriacao], [Nivel], [Img]) VALUES (1, N'Introdução ao SQL Server', 1, 3, 3, CAST(N'2017-01-12T00:00:00.000' AS DateTime), N'Intermediário', N'sqlserver.png')
INSERT [dbo].[Curso] ([Id], [Nome], [IdAutor], [IdAssunto], [Classificacao], [DataCriacao], [Nivel], [Img]) VALUES (2, N'Como fazer o apontamento de horas', 3, 5, NULL, CAST(N'2017-01-06T00:00:00.000' AS DateTime), N'Iniciante', N'Planilha-de-Controle-de-Ponto.jpg')
INSERT [dbo].[Curso] ([Id], [Nome], [IdAutor], [IdAssunto], [Classificacao], [DataCriacao], [Nivel], [Img]) VALUES (3, N'Web API', 2, 4, NULL, CAST(N'2017-01-12T00:00:00.000' AS DateTime), N'Avançado', N'WebAPI-CacheCow.png')
INSERT [dbo].[Curso] ([Id], [Nome], [IdAutor], [IdAssunto], [Classificacao], [DataCriacao], [Nivel], [Img]) VALUES (4, N'Integração de Novos Funcionários', 3, 6, NULL, CAST(N'2017-01-02T00:00:00.000' AS DateTime), N'Iniciante', N'c.jpg')
INSERT [dbo].[Curso] ([Id], [Nome], [IdAutor], [IdAssunto], [Classificacao], [DataCriacao], [Nivel], [Img]) VALUES (5, N'Como ser um youtuber', 4, 7, NULL, CAST(N'2017-01-01T00:00:00.000' AS DateTime), N'Iniciante', N'18190417170318-t300x200.jpg')
INSERT [dbo].[Curso] ([Id], [Nome], [IdAutor], [IdAssunto], [Classificacao], [DataCriacao], [Nivel], [Img]) VALUES (6, N'Instalação do SQL Server', 2, 2, NULL, CAST(N'2017-02-06T03:43:41.917' AS DateTime), N'Intermediário', N'articles-images-guide-to-sql-server.jpg')
INSERT [dbo].[Curso] ([Id], [Nome], [IdAutor], [IdAssunto], [Classificacao], [DataCriacao], [Nivel], [Img]) VALUES (10, N'Curso Avançado de ASP.net', 1, 4, 4, CAST(N'2017-02-06T04:55:45.830' AS DateTime), N'Avançado', N'microsoft aspnet.jpg')
INSERT [dbo].[Curso] ([Id], [Nome], [IdAutor], [IdAssunto], [Classificacao], [DataCriacao], [Nivel], [Img]) VALUES (11, N'Novo Curso SQL SERVER', 6, 3, NULL, CAST(N'2017-02-06T05:06:02.000' AS DateTime), N'Intermediário', N'articles-images-guide-to-sql-server.jpg')
INSERT [dbo].[Curso] ([Id], [Nome], [IdAutor], [IdAssunto], [Classificacao], [DataCriacao], [Nivel], [Img]) VALUES (12, N'Como calcular as horas extras', 1, 6, NULL, CAST(N'2017-02-06T06:50:47.000' AS DateTime), N'Iniciante', N'planilha.jpg')
INSERT [dbo].[Curso] ([Id], [Nome], [IdAutor], [IdAssunto], [Classificacao], [DataCriacao], [Nivel], [Img]) VALUES (15, N'Desenvolvimento em Linguagem CS', 6, 9, 5, CAST(N'2017-01-01T00:00:00.000' AS DateTime), N'Iniciante', N'302456128744958823.png')
INSERT [dbo].[Curso] ([Id], [Nome], [IdAutor], [IdAssunto], [Classificacao], [DataCriacao], [Nivel], [Img]) VALUES (16, N'Alimentação saudável para de área de TI', 7, 7, NULL, CAST(N'2017-01-01T00:00:00.000' AS DateTime), N'Inciante', N'Alimentação-saudável-300x200.jpg')
INSERT [dbo].[Curso] ([Id], [Nome], [IdAutor], [IdAssunto], [Classificacao], [DataCriacao], [Nivel], [Img]) VALUES (17, N'Estátistica Avançada', 8, 7, NULL, CAST(N'2017-01-01T00:00:00.000' AS DateTime), N'Avançado', N'ESTATISTICA-1-300x200.jpg')
INSERT [dbo].[Curso] ([Id], [Nome], [IdAutor], [IdAssunto], [Classificacao], [DataCriacao], [Nivel], [Img]) VALUES (18, N'Como ser organizada em 5 passos', 9, 7, NULL, CAST(N'2017-01-01T00:00:00.000' AS DateTime), N'Iniciante', N'organi_5.jpg')
INSERT [dbo].[Curso] ([Id], [Nome], [IdAutor], [IdAssunto], [Classificacao], [DataCriacao], [Nivel], [Img]) VALUES (19, N'Como desenvolver um sistema para nutrição clínica', 10, 7, 1, CAST(N'2017-01-01T00:00:00.000' AS DateTime), N'Iniciante', N'fisiologia-aplicada-ao-esporte.jpg')
SET IDENTITY_INSERT [dbo].[Curso] OFF
SET IDENTITY_INSERT [dbo].[Curso_Classificacao] ON 

INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (1, 1, 1, 4)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (2, 1, 2, 5)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (3, 1, 3, 4)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (4, 1, 4, 3)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (5, 1, 5, 4)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (7, 1, 1, 3)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (9, 1, 2, 0)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (10, 1, 2, 0)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (11, 1, 2, 0)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (12, 1, 2, 0)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (14, 1, 2, 5)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (15, 1, 2, 5)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (16, 1, 2, 5)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (17, 1, 2, 4)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (18, 1, 2, 5)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (19, 1, 2, 4)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (20, 1, 2, 4)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (21, 1, 4, 4)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (22, 15, 2, 5)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (23, 19, 1, 1)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (24, 19, 1, 1)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (25, 19, 1, 1)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (26, 15, 1, 5)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (27, 10, 1, 5)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (28, 10, 1, 5)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (29, 10, 1, 4)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (30, 10, 1, 4)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (31, 15, 1, 5)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (32, 15, 1, 5)
INSERT [dbo].[Curso_Classificacao] ([Id], [IdCurso], [IdUsuario], [Nota]) VALUES (33, 15, 1, 5)
SET IDENTITY_INSERT [dbo].[Curso_Classificacao] OFF
SET IDENTITY_INSERT [dbo].[Curso_Descricao] ON 

INSERT [dbo].[Curso_Descricao] ([Id], [Descricao], [IdCurso]) VALUES (1, N'Introdução ao SQL Server é um curso que mostra como utilizar e a lingaguem necessária para criar scripts de banco de dados', 1)
INSERT [dbo].[Curso_Descricao] ([Id], [Descricao], [IdCurso]) VALUES (2, N'Como fazer o apontamento de horas é um curso que irá ensina-lo a utilizar o sistema ', 2)
INSERT [dbo].[Curso_Descricao] ([Id], [Descricao], [IdCurso]) VALUES (3, N'Web API é um curso que ensinará como utilizar corretamente as APIs no desenvolvimento', 3)
INSERT [dbo].[Curso_Descricao] ([Id], [Descricao], [IdCurso]) VALUES (4, N'Integração de Novos Funcionários é um curso que irá ajudar os novos colaboradores a entender o funcionamento da Viceri e ambienta-los ao seu funcionamento', 4)
INSERT [dbo].[Curso_Descricao] ([Id], [Descricao], [IdCurso]) VALUES (5, N'Como ser um youtuber é um curso que lhe ensinará a fazer os vídeos mais legal, ganhando muitos likes e seguidores', 5)
INSERT [dbo].[Curso_Descricao] ([Id], [Descricao], [IdCurso]) VALUES (7, N'Desenvolvimento em Linguagem C# é um curso que lhe proverá conhecimentos sobre a linguagem C#, apredendo corretamente sua utilização ', 15)
INSERT [dbo].[Curso_Descricao] ([Id], [Descricao], [IdCurso]) VALUES (8, N'Alimentação saudável para trabalhadores da área de TI irá trazer informações sobre como se alimentar de forma mais saudável garantindo que todos os nutrientes necessários sejam devidamente ingeridos', 16)
INSERT [dbo].[Curso_Descricao] ([Id], [Descricao], [IdCurso]) VALUES (9, N'Estátistica Avançada é um curso que lhe trará conhecimentos sobre estátistica avançada como modelos estatísticos clássicos e bayesianos; modelos paramétricos, não paramétricos e semi-paramétricos; formulação geral do problema do teste de hipóteses; lema de Neyman-Pearson e testes UMP', 17)
INSERT [dbo].[Curso_Descricao] ([Id], [Descricao], [IdCurso]) VALUES (10, N'Como ser organizada em 5 passos é um curso que busca a organização do seu tempo e da suas coisas como um meio de facilitar e economizar tempo conseguindo desempenhar as tarefas de modo simples e eficaz', 18)
INSERT [dbo].[Curso_Descricao] ([Id], [Descricao], [IdCurso]) VALUES (11, N'Como desenvolver um sistema para nutrição clínica é um curso que irá fornecer alguns pré-requisitos necessários para o desenvolvimento de sistema para nutrição de forma simples e fácil', 19)
INSERT [dbo].[Curso_Descricao] ([Id], [Descricao], [IdCurso]) VALUES (12, N'Esse curso é ideal para quem quer dar os primeiros passos com a linguagem SQL, começando pela instalação do SQL Server e seus componentes.', 6)
INSERT [dbo].[Curso_Descricao] ([Id], [Descricao], [IdCurso]) VALUES (13, N'O curso ASP.NET 2013 com C# - Recursos Avançados é voltado para profissionais que dominam técnicas intermediárias da plataforma ASP.NET e desejam aprofundar seus conhecimentos na linguagem. O curso aborda recursos avançados de desenvolvimento como Bootstrap, Single Page Apps, Design Patterns, Templates, MVC e Providers.', 10)
INSERT [dbo].[Curso_Descricao] ([Id], [Descricao], [IdCurso]) VALUES (14, N'Este Curso de SQL Server, apresenta sobre os sistemas gerenciadores de Banco de Dados, como iniciar o SETUP e como editar as informações do servidor SQL Server. Além disso, você aprenderá a eliminar valores duplicados e a realizar consultas avançadas.', 11)
INSERT [dbo].[Curso_Descricao] ([Id], [Descricao], [IdCurso]) VALUES (15, N'Uma das competências do setor de recursos humanos é calcular hora extra, isto é, as horas trabalhadas além da jornada estabelecida em contrato com o funcionário. Existem diversas formas de controlar as horas extras, como fazendo uso de um software de departamento pessoal ou de controle de ponto, por exemplo. Mas pouca gente sabe que uma alternativa para fazer esse cálculo é o Microsoft Excel.', 12)
SET IDENTITY_INSERT [dbo].[Curso_Descricao] OFF
INSERT [dbo].[Funcionalidade] ([Id], [Nome]) VALUES (1, N'Cadastrar Curso')
INSERT [dbo].[Funcionalidade] ([Id], [Nome]) VALUES (2, N'Manutenção Usuarios')
INSERT [dbo].[Perfil] ([Id], [Nome]) VALUES (1, N'Administrador')
INSERT [dbo].[Perfil] ([Id], [Nome]) VALUES (2, N'Usuario')
INSERT [dbo].[Perfil] ([Id], [Nome]) VALUES (3, N'Instrutor')
INSERT [dbo].[Permissao] ([IdPerfil], [IdFuncionalidade]) VALUES (1, 1)
INSERT [dbo].[Permissao] ([IdPerfil], [IdFuncionalidade]) VALUES (1, 2)
INSERT [dbo].[Permissao] ([IdPerfil], [IdFuncionalidade]) VALUES (3, 1)
SET IDENTITY_INSERT [dbo].[Treinamento] ON 

INSERT [dbo].[Treinamento] ([IdUsuario], [IdCurso], [DataInicio], [UltimoAcesso], [DataConclusao], [Id]) VALUES (1, 5, CAST(N'2017-02-11T22:59:52.353' AS DateTime), CAST(N'2017-01-03T00:00:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Treinamento] ([IdUsuario], [IdCurso], [DataInicio], [UltimoAcesso], [DataConclusao], [Id]) VALUES (5, 3, CAST(N'2017-02-11T11:59:50.317' AS DateTime), CAST(N'2017-01-10T00:00:00.000' AS DateTime), CAST(N'2017-01-16T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Treinamento] ([IdUsuario], [IdCurso], [DataInicio], [UltimoAcesso], [DataConclusao], [Id]) VALUES (3, 4, CAST(N'2017-02-11T11:28:11.800' AS DateTime), CAST(N'2017-02-11T11:28:11.800' AS DateTime), NULL, 4)
INSERT [dbo].[Treinamento] ([IdUsuario], [IdCurso], [DataInicio], [UltimoAcesso], [DataConclusao], [Id]) VALUES (1, 1, CAST(N'2017-02-11T23:01:27.840' AS DateTime), CAST(N'2017-02-15T23:52:44.073' AS DateTime), CAST(N'2017-02-13T01:12:05.963' AS DateTime), 6)
INSERT [dbo].[Treinamento] ([IdUsuario], [IdCurso], [DataInicio], [UltimoAcesso], [DataConclusao], [Id]) VALUES (2, 1, CAST(N'2017-02-12T02:14:46.097' AS DateTime), CAST(N'2017-02-13T13:23:20.013' AS DateTime), CAST(N'2017-02-13T07:55:24.950' AS DateTime), 7)
INSERT [dbo].[Treinamento] ([IdUsuario], [IdCurso], [DataInicio], [UltimoAcesso], [DataConclusao], [Id]) VALUES (2, 12, CAST(N'2017-02-12T07:43:28.500' AS DateTime), CAST(N'2017-02-12T07:43:28.500' AS DateTime), NULL, 8)
INSERT [dbo].[Treinamento] ([IdUsuario], [IdCurso], [DataInicio], [UltimoAcesso], [DataConclusao], [Id]) VALUES (1, 19, CAST(N'2017-02-14T21:18:56.793' AS DateTime), CAST(N'2017-02-26T14:02:13.020' AS DateTime), CAST(N'2017-02-26T14:00:20.573' AS DateTime), 9)
INSERT [dbo].[Treinamento] ([IdUsuario], [IdCurso], [DataInicio], [UltimoAcesso], [DataConclusao], [Id]) VALUES (4, 1, CAST(N'2017-02-16T02:09:33.437' AS DateTime), CAST(N'2017-02-16T02:28:36.637' AS DateTime), CAST(N'2017-02-16T02:16:49.907' AS DateTime), 10)
INSERT [dbo].[Treinamento] ([IdUsuario], [IdCurso], [DataInicio], [UltimoAcesso], [DataConclusao], [Id]) VALUES (2, 15, CAST(N'2017-02-16T12:02:53.350' AS DateTime), CAST(N'2017-02-16T12:02:53.350' AS DateTime), CAST(N'2017-02-16T12:03:36.440' AS DateTime), 11)
INSERT [dbo].[Treinamento] ([IdUsuario], [IdCurso], [DataInicio], [UltimoAcesso], [DataConclusao], [Id]) VALUES (1, 15, CAST(N'2017-02-26T15:01:32.310' AS DateTime), CAST(N'2017-02-26T16:14:46.537' AS DateTime), CAST(N'2017-02-26T15:01:39.653' AS DateTime), 12)
INSERT [dbo].[Treinamento] ([IdUsuario], [IdCurso], [DataInicio], [UltimoAcesso], [DataConclusao], [Id]) VALUES (1, 10, CAST(N'2017-02-26T15:04:08.270' AS DateTime), CAST(N'2017-02-26T15:05:07.463' AS DateTime), CAST(N'2017-02-26T15:04:15.987' AS DateTime), 13)
SET IDENTITY_INSERT [dbo].[Treinamento] OFF
SET IDENTITY_INSERT [dbo].[Treinamento_Capitulo] ON 

INSERT [dbo].[Treinamento_Capitulo] ([IdUsuario], [IdCurso], [IdCapitulo], [Pontos], [DataConclusao], [id]) VALUES (1, 2, 5, 5, CAST(N'2017-01-02T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Treinamento_Capitulo] ([IdUsuario], [IdCurso], [IdCapitulo], [Pontos], [DataConclusao], [id]) VALUES (1, 2, 6, 3, CAST(N'2017-01-03T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Treinamento_Capitulo] ([IdUsuario], [IdCurso], [IdCapitulo], [Pontos], [DataConclusao], [id]) VALUES (5, 1, 1, 5, CAST(N'2017-01-03T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Treinamento_Capitulo] ([IdUsuario], [IdCurso], [IdCapitulo], [Pontos], [DataConclusao], [id]) VALUES (5, 1, 2, 6, CAST(N'2017-01-10T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Treinamento_Capitulo] ([IdUsuario], [IdCurso], [IdCapitulo], [Pontos], [DataConclusao], [id]) VALUES (5, 1, 3, 4, CAST(N'2017-01-13T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Treinamento_Capitulo] ([IdUsuario], [IdCurso], [IdCapitulo], [Pontos], [DataConclusao], [id]) VALUES (5, 1, 4, 7, CAST(N'2017-01-15T00:00:00.000' AS DateTime), 6)
SET IDENTITY_INSERT [dbo].[Treinamento_Capitulo] OFF
SET IDENTITY_INSERT [dbo].[Trilha] ON 

INSERT [dbo].[Trilha] ([Id], [Nome], [Ativa]) VALUES (1, N'Trilha de Integração', 1)
INSERT [dbo].[Trilha] ([Id], [Nome], [Ativa]) VALUES (2, N'Trilha Técnica', 1)
INSERT [dbo].[Trilha] ([Id], [Nome], [Ativa]) VALUES (3, N'Diversos', 1)
INSERT [dbo].[Trilha] ([Id], [Nome], [Ativa]) VALUES (4, N'Triha FrontEnd', 1)
INSERT [dbo].[Trilha] ([Id], [Nome], [Ativa]) VALUES (5, N'Trilha DB', 1)
INSERT [dbo].[Trilha] ([Id], [Nome], [Ativa]) VALUES (6, N'Trilha Web', 1)
INSERT [dbo].[Trilha] ([Id], [Nome], [Ativa]) VALUES (7, N'Trilha Raspberry PI', 1)
INSERT [dbo].[Trilha] ([Id], [Nome], [Ativa]) VALUES (8, N'Trilha Financeiro', 0)
INSERT [dbo].[Trilha] ([Id], [Nome], [Ativa]) VALUES (9, N'Trilha Vendas', 1)
INSERT [dbo].[Trilha] ([Id], [Nome], [Ativa]) VALUES (10, N'Trilha Estátistica', 1)
SET IDENTITY_INSERT [dbo].[Trilha] OFF
INSERT [dbo].[Trilha_Curso] ([IdTrilha], [IdCurso]) VALUES (1, 2)
INSERT [dbo].[Trilha_Curso] ([IdTrilha], [IdCurso]) VALUES (1, 4)
INSERT [dbo].[Trilha_Curso] ([IdTrilha], [IdCurso]) VALUES (2, 1)
INSERT [dbo].[Trilha_Curso] ([IdTrilha], [IdCurso]) VALUES (2, 3)
INSERT [dbo].[Trilha_Curso] ([IdTrilha], [IdCurso]) VALUES (3, 5)
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Ativo], [IdPerfil]) VALUES (1, N'Fernando Barbieri', N'fbarbieri@live.com', N'4QrcOUm6Wau+VuBX8g+IPg==', 1, 1)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Ativo], [IdPerfil]) VALUES (2, N'Fernando Mendes', N'fmendes@viceri.com.br', N'4QrcOUm6Wau+VuBX8g+IPg==', 1, 2)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Ativo], [IdPerfil]) VALUES (3, N'Mariane Castellano', N'mcastellano@viceri.com.br', N'4QrcOUm6Wau+VuBX8g+IPg==', 1, 2)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Ativo], [IdPerfil]) VALUES (4, N'Monica Mesquita', N'mmesquita@viceri.com.br', N'4QrcOUm6Wau+VuBX8g+IPg==', 1, 3)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Ativo], [IdPerfil]) VALUES (5, N'Mayara Marin', N'mmarin@viceri.com.br', N'4QrcOUm6Wau+VuBX8g+IPg==', 1, 3)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Ativo], [IdPerfil]) VALUES (6, N'Fábio Massaretto', N'fabiomassa@viceri.com.br', N'4QrcOUm6Wau+VuBX8g+IPg==', 1, 1)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Ativo], [IdPerfil]) VALUES (7, N'Gabi di Paolla', N'gabipaolla@viceri.com.br', N'4QrcOUm6Wau+VuBX8g+IPg==', 1, 2)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Ativo], [IdPerfil]) VALUES (8, N'Luã Gomes', N'luagomes@viceri.com.br', N'4QrcOUm6Wau+VuBX8g+IPg==', 1, 1)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Ativo], [IdPerfil]) VALUES (9, N'Bárbara Pontes', N'bahpontes@viceri.com.br', N'4QrcOUm6Wau+VuBX8g+IPg==', 1, 3)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Ativo], [IdPerfil]) VALUES (10, N'Fabi Corsi', N'fabicorsi@viceri.com.br', N'4QrcOUm6Wau+VuBX8g+IPg==', 1, 1)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Ativo], [IdPerfil]) VALUES (18, N'Teste', N'teste@teste.com', N'4QrcOUm6Wau+VuBX8g+IPg==', 1, 2)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
SET IDENTITY_INSERT [dbo].[Video] ON 

INSERT [dbo].[Video] ([Id], [Nome], [Duracao], [IdCapitulo], [CodigoVideo], [Thumbnail]) VALUES (1, N'Instalação do SQL Server 2012 Express Edition', 180, 1, N'xJYl1TgNd_Y', NULL)
INSERT [dbo].[Video] ([Id], [Nome], [Duracao], [IdCapitulo], [CodigoVideo], [Thumbnail]) VALUES (2, N'1 - T-SQL - Introdução e grupos de comandos', 90, 1, N'2kWoPT-6JqA', NULL)
INSERT [dbo].[Video] ([Id], [Nome], [Duracao], [IdCapitulo], [CodigoVideo], [Thumbnail]) VALUES (3, N'2 - T-SQL - Bancos de Dados, SGBDR, Tipos de Dados', 60, 2, N'pCpr4gRjBsI', NULL)
INSERT [dbo].[Video] ([Id], [Nome], [Duracao], [IdCapitulo], [CodigoVideo], [Thumbnail]) VALUES (4, N'3 - T-SQL - CREATE DATABASE - Criar Banco de Dados', 30, 3, N'828s3z0LCHs', NULL)
INSERT [dbo].[Video] ([Id], [Nome], [Duracao], [IdCapitulo], [CodigoVideo], [Thumbnail]) VALUES (12, N'T-SQL ALTER e DROP TABLE - Alterar e Excluir Tabelas', 45, 4, N'Jf2Hr2q4hf8', NULL)
INSERT [dbo].[Video] ([Id], [Nome], [Duracao], [IdCapitulo], [CodigoVideo], [Thumbnail]) VALUES (13, N'Aula 1 - Introdução - eXcript', 360, 8, N'PSchhzHyJrM', NULL)
INSERT [dbo].[Video] ([Id], [Nome], [Duracao], [IdCapitulo], [CodigoVideo], [Thumbnail]) VALUES (14, N'Aula 2 - Console Application - eXcript', 460, 9, N'Hfg4Ia2k0ZM', NULL)
INSERT [dbo].[Video] ([Id], [Nome], [Duracao], [IdCapitulo], [CodigoVideo], [Thumbnail]) VALUES (15, N'Aula 3 - C# Project - eXcript', 300, 9, N'hUlDF6dWrSI', NULL)
INSERT [dbo].[Video] ([Id], [Nome], [Duracao], [IdCapitulo], [CodigoVideo], [Thumbnail]) VALUES (16, N'Aula 4 - Comentários - eXcript', 280, 9, N'Jeh5eYFOoos', NULL)
INSERT [dbo].[Video] ([Id], [Nome], [Duracao], [IdCapitulo], [CodigoVideo], [Thumbnail]) VALUES (18, N'Aula 5 - Variáveis I - eXcript', 400, 9, N'4IwPvi4jLqg', NULL)
INSERT [dbo].[Video] ([Id], [Nome], [Duracao], [IdCapitulo], [CodigoVideo], [Thumbnail]) VALUES (19, N'Aula 6 - Tipos de Dados - eXcript', 320, 9, N'BIisdMxNow0', NULL)
INSERT [dbo].[Video] ([Id], [Nome], [Duracao], [IdCapitulo], [CodigoVideo], [Thumbnail]) VALUES (20, N'Aula 12 - Tomada de Decisão I', 260, 10, N'0URcCYZ_F7k', NULL)
INSERT [dbo].[Video] ([Id], [Nome], [Duracao], [IdCapitulo], [CodigoVideo], [Thumbnail]) VALUES (21, N'Aula 13 - Tomada de Decisão II', 340, 10, N'scthOhtJAhY', NULL)
INSERT [dbo].[Video] ([Id], [Nome], [Duracao], [IdCapitulo], [CodigoVideo], [Thumbnail]) VALUES (22, N'Aula 14 - Estrutura "else" - senão - eXcript', 450, 10, N'3DD66P6rU3g', NULL)
INSERT [dbo].[Video] ([Id], [Nome], [Duracao], [IdCapitulo], [CodigoVideo], [Thumbnail]) VALUES (23, N'Aula 15 - Operadores Aritméticos - eXcript', 400, 11, N'Ix6srvnRY14', NULL)
INSERT [dbo].[Video] ([Id], [Nome], [Duracao], [IdCapitulo], [CodigoVideo], [Thumbnail]) VALUES (24, N'Aula 17 - Operadores Relacionais', 300, 11, N'YfR9gQx1gTY', NULL)
SET IDENTITY_INSERT [dbo].[Video] OFF
ALTER TABLE [dbo].[Curso] ADD  CONSTRAINT [DF_Curso_DataCriacao]  DEFAULT (getdate()) FOR [DataCriacao]
GO
ALTER TABLE [dbo].[Documento] ADD  CONSTRAINT [DF_Documento_DataCadastro]  DEFAULT (getdate()) FOR [DataCadastro]
GO
ALTER TABLE [dbo].[Treinamento] ADD  CONSTRAINT [DF_Treinamento_DataInicio]  DEFAULT (getdate()) FOR [DataInicio]
GO
ALTER TABLE [dbo].[Trilha] ADD  CONSTRAINT [DF_Trilha_Ativa]  DEFAULT ((1)) FOR [Ativa]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_Ativo]  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Capitulo]  WITH CHECK ADD  CONSTRAINT [FK_Capitulo_Curso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Curso] ([Id])
GO
ALTER TABLE [dbo].[Capitulo] CHECK CONSTRAINT [FK_Capitulo_Curso]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Assunto] FOREIGN KEY([IdAssunto])
REFERENCES [dbo].[Assunto] ([Id])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_Assunto]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Usuario] FOREIGN KEY([IdAutor])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_Usuario]
GO
ALTER TABLE [dbo].[Curso_Classificacao]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Classificacao_Curso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Curso] ([Id])
GO
ALTER TABLE [dbo].[Curso_Classificacao] CHECK CONSTRAINT [FK_Curso_Classificacao_Curso]
GO
ALTER TABLE [dbo].[Curso_Classificacao]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Classificacao_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Curso_Classificacao] CHECK CONSTRAINT [FK_Curso_Classificacao_Usuario]
GO
ALTER TABLE [dbo].[Curso_Descricao]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Descricao_Curso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Curso] ([Id])
GO
ALTER TABLE [dbo].[Curso_Descricao] CHECK CONSTRAINT [FK_Curso_Descricao_Curso]
GO
ALTER TABLE [dbo].[Documento]  WITH CHECK ADD  CONSTRAINT [FK_Documento_Curso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Curso] ([Id])
GO
ALTER TABLE [dbo].[Documento] CHECK CONSTRAINT [FK_Documento_Curso]
GO
ALTER TABLE [dbo].[Permissao]  WITH CHECK ADD  CONSTRAINT [FK_Permissao_Funcionalidade] FOREIGN KEY([IdFuncionalidade])
REFERENCES [dbo].[Funcionalidade] ([Id])
GO
ALTER TABLE [dbo].[Permissao] CHECK CONSTRAINT [FK_Permissao_Funcionalidade]
GO
ALTER TABLE [dbo].[Permissao]  WITH CHECK ADD  CONSTRAINT [FK_Permissao_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([Id])
GO
ALTER TABLE [dbo].[Permissao] CHECK CONSTRAINT [FK_Permissao_Perfil]
GO
ALTER TABLE [dbo].[Treinamento]  WITH CHECK ADD  CONSTRAINT [FK_Treinamento_Curso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Curso] ([Id])
GO
ALTER TABLE [dbo].[Treinamento] CHECK CONSTRAINT [FK_Treinamento_Curso]
GO
ALTER TABLE [dbo].[Treinamento]  WITH CHECK ADD  CONSTRAINT [FK_Treinamento_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Treinamento] CHECK CONSTRAINT [FK_Treinamento_Usuario]
GO
ALTER TABLE [dbo].[Treinamento_Capitulo]  WITH CHECK ADD  CONSTRAINT [FK_Treinamento_Capitulo_Capitulo] FOREIGN KEY([IdCapitulo])
REFERENCES [dbo].[Capitulo] ([Id])
GO
ALTER TABLE [dbo].[Treinamento_Capitulo] CHECK CONSTRAINT [FK_Treinamento_Capitulo_Capitulo]
GO
ALTER TABLE [dbo].[Treinamento_Capitulo]  WITH CHECK ADD  CONSTRAINT [FK_Treinamento_Capitulo_Curso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Curso] ([Id])
GO
ALTER TABLE [dbo].[Treinamento_Capitulo] CHECK CONSTRAINT [FK_Treinamento_Capitulo_Curso]
GO
ALTER TABLE [dbo].[Treinamento_Capitulo]  WITH CHECK ADD  CONSTRAINT [FK_Treinamento_Capitulo_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Treinamento_Capitulo] CHECK CONSTRAINT [FK_Treinamento_Capitulo_Usuario]
GO
ALTER TABLE [dbo].[Trilha_Curso]  WITH CHECK ADD  CONSTRAINT [FK_Trilha_Curso_Curso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Curso] ([Id])
GO
ALTER TABLE [dbo].[Trilha_Curso] CHECK CONSTRAINT [FK_Trilha_Curso_Curso]
GO
ALTER TABLE [dbo].[Trilha_Curso]  WITH CHECK ADD  CONSTRAINT [FK_Trilha_Curso_Trilha] FOREIGN KEY([IdTrilha])
REFERENCES [dbo].[Trilha] ([Id])
GO
ALTER TABLE [dbo].[Trilha_Curso] CHECK CONSTRAINT [FK_Trilha_Curso_Trilha]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Perfil]
GO
ALTER TABLE [dbo].[Video]  WITH CHECK ADD  CONSTRAINT [FK_Video_Capitulo] FOREIGN KEY([IdCapitulo])
REFERENCES [dbo].[Capitulo] ([Id])
GO
ALTER TABLE [dbo].[Video] CHECK CONSTRAINT [FK_Video_Capitulo]
GO
USE [master]
GO
ALTER DATABASE [Treinamento] SET  READ_WRITE 
GO
