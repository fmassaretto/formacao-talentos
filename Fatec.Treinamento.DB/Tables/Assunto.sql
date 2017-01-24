CREATE TABLE [dbo].[Assunto] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Nome] VARCHAR (100) NULL,
    CONSTRAINT [PK_Assunto] PRIMARY KEY CLUSTERED ([Id] ASC)
);

