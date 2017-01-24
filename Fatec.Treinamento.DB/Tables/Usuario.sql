CREATE TABLE [dbo].[Usuario] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Nome]  VARCHAR (100) NOT NULL,
    [Email] VARCHAR (100) NOT NULL,
    [Senha] VARCHAR (20)  NOT NULL,
    [Ativo] BIT           CONSTRAINT [DF_Usuario_Ativo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

