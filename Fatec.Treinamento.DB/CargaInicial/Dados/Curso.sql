USE [Treinamento]
GO



SET NOCOUNT ON

SET IDENTITY_INSERT [dbo].[Curso] ON

MERGE INTO [dbo].[Curso] AS Target
USING (VALUES
  (1,'Introdução ao SQL Server',1,3,NULL,'2017-01-12T00:00:00', 'Iniciante')
 ,(2,'Como fazer o apontamento de horas',3,5,4,'2017-01-06T00:00:00', 'Iniciante')
 ,(3,'Web API',2,4,4,'2017-01-12T00:00:00', 'Avançado')
 ,(4,'Integração de Novos Funcionários',3,6,3,'2017-01-02T00:00:00', 'Intermediário')
 ,(5,'Como ser um youtuber',4,7,5,'2017-01-01T00:00:00', 'Iniciante')
) AS Source ([Id],[Nome],[IdAutor],[IdAssunto],[Classificacao],[DataCriacao], [Nivel])
ON (Target.[Id] = Source.[Id])
WHEN MATCHED AND (
	NULLIF(Source.[Nome], Target.[Nome]) IS NOT NULL OR NULLIF(Target.[Nome], Source.[Nome]) IS NOT NULL OR 
	NULLIF(Source.[IdAutor], Target.[IdAutor]) IS NOT NULL OR NULLIF(Target.[IdAutor], Source.[IdAutor]) IS NOT NULL OR 
	NULLIF(Source.[IdAssunto], Target.[IdAssunto]) IS NOT NULL OR NULLIF(Target.[IdAssunto], Source.[IdAssunto]) IS NOT NULL OR 
	NULLIF(Source.[Classificacao], Target.[Classificacao]) IS NOT NULL OR NULLIF(Target.[Classificacao], Source.[Classificacao]) IS NOT NULL OR
	NULLIF(Source.[DataCriacao], Target.[DataCriacao]) IS NOT NULL OR NULLIF(Target.[DataCriacao], Source.[DataCriacao]) IS NOT NULL OR 
	NULLIF(Source.[Nivel], Target.[Nivel]) IS NOT NULL OR NULLIF(Target.[Nivel], Source.[Nivel]) IS NOT NULL) THEN
 UPDATE SET
  [Nome] = Source.[Nome], 
  [IdAutor] = Source.[IdAutor], 
  [IdAssunto] = Source.[IdAssunto], 
  [Classificacao] = Source.[Classificacao], 
  [DataCriacao] = Source.[DataCriacao],
  [Nivel] = Source.[Nivel]
WHEN NOT MATCHED BY TARGET THEN
 INSERT([Id],[Nome],[IdAutor],[IdAssunto],[Classificacao],[DataCriacao],[Nivel])
 VALUES(Source.[Id],Source.[Nome],Source.[IdAutor],Source.[IdAssunto],Source.[Classificacao],Source.[DataCriacao],Source.[Nivel])
WHEN NOT MATCHED BY SOURCE THEN 
 DELETE
;
GO
DECLARE @mergeError int
 , @mergeCount int
SELECT @mergeError = @@ERROR, @mergeCount = @@ROWCOUNT
IF @mergeError != 0
 BEGIN
 PRINT 'ERROR OCCURRED IN MERGE FOR [dbo].[Curso]. Rows affected: ' + CAST(@mergeCount AS VARCHAR(100)); -- SQL should always return zero rows affected
 END
ELSE
 BEGIN
 PRINT '[dbo].[Curso] rows affected by MERGE: ' + CAST(@mergeCount AS VARCHAR(100));
 END
GO

SET IDENTITY_INSERT [dbo].[Curso] OFF
GO
SET NOCOUNT OFF
GO
