CREATE TABLE [dbo].[Perfil] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Nome] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED ([Id] ASC)
);

