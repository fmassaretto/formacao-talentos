CREATE TABLE [dbo].[Usuario_Perfil] (
    [IdUsuario] INT NOT NULL,
    [IdPerfil]  INT NOT NULL,
    CONSTRAINT [PK_Usuario_Perfil] PRIMARY KEY CLUSTERED ([IdUsuario] ASC, [IdPerfil] ASC),
    CONSTRAINT [FK_Usuario_Perfil_Perfil] FOREIGN KEY ([IdPerfil]) REFERENCES [dbo].[Perfil] ([Id]),
    CONSTRAINT [FK_Usuario_Perfil_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuario] ([Id])
);

