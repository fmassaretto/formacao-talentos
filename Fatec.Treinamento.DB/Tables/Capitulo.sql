CREATE TABLE [dbo].[Capitulo] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [Nome]    VARCHAR (50) NOT NULL,
    [IdCurso] INT          NOT NULL,
    [Pontos]  INT          NOT NULL,
    CONSTRAINT [PK_Capitulo] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Capitulo_Curso] FOREIGN KEY ([IdCurso]) REFERENCES [dbo].[Curso] ([Id])
);

