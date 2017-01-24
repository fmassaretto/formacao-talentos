CREATE TABLE [dbo].[Documento] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [IdCurso]      INT             NOT NULL,
    [Descricao]    VARCHAR (MAX)   NOT NULL,
    [DataCadastro] DATETIME        CONSTRAINT [DF_Documento_DataCadastro] DEFAULT (getdate()) NOT NULL,
    [Arquivo]      VARBINARY (MAX) NULL,
    CONSTRAINT [PK_Documento] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Documento_Curso] FOREIGN KEY ([IdCurso]) REFERENCES [dbo].[Curso] ([Id])
);

