CREATE TABLE [dbo].[Treinamento_Capitulo] (
    [IdUsuario]     INT      NOT NULL,
    [IdCurso]       INT      NOT NULL,
    [IdCapitulo]    INT      NOT NULL,
    [Pontos]        INT      NOT NULL,
    [DataConclusao] DATETIME NULL,
    [Id] INT NOT NULL IDENTITY, 
    CONSTRAINT [PK_Treinamento_Capitulo] PRIMARY KEY CLUSTERED ([Id]), 
    CONSTRAINT [FK_Treinamento_Capitulo_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuario]([Id]), 
    CONSTRAINT [FK_Treinamento_Capitulo_Curso] FOREIGN KEY ([IdCurso]) REFERENCES [Curso]([Id]), 
    CONSTRAINT [FK_Treinamento_Capitulo_Capitulo] FOREIGN KEY ([IdCapitulo]) REFERENCES [Capitulo]([Id])
);

