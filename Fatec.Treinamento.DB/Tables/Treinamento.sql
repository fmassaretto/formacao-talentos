CREATE TABLE [dbo].[Treinamento] (
    [IdUsuario]     INT      NOT NULL,
    [IdCurso]       INT      NOT NULL,
    [DataInicio]    DATETIME CONSTRAINT [DF_Treinamento_DataInicio] DEFAULT (getdate()) NOT NULL,
    [UltimoAcesso]  DATETIME NOT NULL,
    [DataConclusao] DATETIME NULL,
    [Id] INT NOT NULL IDENTITY, 
    CONSTRAINT [PK_Treinamento] PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [FK_Treinamento_Curso] FOREIGN KEY ([IdCurso]) REFERENCES [dbo].[Curso] ([Id]),
    CONSTRAINT [FK_Treinamento_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuario] ([Id])
);

