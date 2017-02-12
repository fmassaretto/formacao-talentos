CREATE TABLE [dbo].[Curso] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Nome]          VARCHAR (100) NOT NULL,
    [IdAutor]       INT           NOT NULL,
    [IdAssunto]     INT           NOT NULL,
    [Classificacao] INT           NULL,
    [DataCriacao]   DATETIME      CONSTRAINT [DF_Curso_DataCriacao] DEFAULT (getdate()) NOT NULL,
    [Nivel] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Curso_Assunto] FOREIGN KEY ([IdAssunto]) REFERENCES [dbo].[Assunto] ([Id]),
    CONSTRAINT [FK_Curso_Usuario] FOREIGN KEY ([IdAutor]) REFERENCES [dbo].[Usuario] ([Id])
);

