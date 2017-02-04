CREATE TABLE [dbo].[Curso_Descricao]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Descricao] VARCHAR(500) NULL, 
    [IdCurso] INT NOT NULL, 
    CONSTRAINT [FK_Curso_Descricao_Curso] FOREIGN KEY (IdCurso) REFERENCES [Curso]([Id])
)
