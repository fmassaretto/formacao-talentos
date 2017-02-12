CREATE TABLE [dbo].[Curso_Classificacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCurso] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Nota] [int] NULL,
 CONSTRAINT [PK_Curso_Classificacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY], 
    CONSTRAINT [FK_Curso_Classificacao_Curso] FOREIGN KEY (IdCurso) REFERENCES [Curso]([Id]), 
    CONSTRAINT [FK_Curso_Classificacao_Usuario] FOREIGN KEY (IdUsuario) REFERENCES [Usuario]([Id])
) ON [PRIMARY]
