CREATE TABLE [dbo].[Permissao] (
    [IdPerfil]         INT NOT NULL,
    [IdFuncionalidade] INT NOT NULL,
    CONSTRAINT [PK_Permissao] PRIMARY KEY CLUSTERED ([IdPerfil] ASC, [IdFuncionalidade] ASC),
    CONSTRAINT [FK_Permissao_Funcionalidade] FOREIGN KEY ([IdFuncionalidade]) REFERENCES [dbo].[Funcionalidade] ([Id]),
    CONSTRAINT [FK_Permissao_Perfil] FOREIGN KEY ([IdPerfil]) REFERENCES [dbo].[Perfil] ([Id])
);

