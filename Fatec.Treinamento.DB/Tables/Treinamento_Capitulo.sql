CREATE TABLE [dbo].[Treinamento_Capitulo] (
    [IdUsuario]     INT      NOT NULL,
    [IdCurso]       INT      NOT NULL,
    [IdCapitulo]    INT      NOT NULL,
    [Pontos]        INT      NOT NULL,
    [DataConclusao] DATETIME NULL,
    CONSTRAINT [PK_Treinamento_Capitulo] PRIMARY KEY CLUSTERED ([IdUsuario] ASC, [IdCurso] ASC, [IdCapitulo] ASC),
    CONSTRAINT [FK_Treinamento_Capitulo_Capitulo] FOREIGN KEY ([IdCapitulo]) REFERENCES [dbo].[Capitulo] ([Id]),
    CONSTRAINT [FK_Treinamento_Capitulo_Treinamento] FOREIGN KEY ([IdUsuario], [IdCurso]) REFERENCES [dbo].[Treinamento] ([IdUsuario], [IdCurso])
);

