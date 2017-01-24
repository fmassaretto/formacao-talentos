CREATE TABLE [dbo].[Trilha_Curso] (
    [IdTrilha] INT NOT NULL,
    [IdCurso]  INT NOT NULL,
    CONSTRAINT [PK_Trilha_Curso] PRIMARY KEY CLUSTERED ([IdTrilha] ASC, [IdCurso] ASC),
    CONSTRAINT [FK_Trilha_Curso_Curso] FOREIGN KEY ([IdCurso]) REFERENCES [dbo].[Curso] ([Id]),
    CONSTRAINT [FK_Trilha_Curso_Trilha] FOREIGN KEY ([IdTrilha]) REFERENCES [dbo].[Trilha] ([Id])
);

