USE [Treinamento]
GO



SET NOCOUNT ON

SET IDENTITY_INSERT [dbo].[Usuario] ON

MERGE INTO [dbo].[Usuario] AS Target
USING (VALUES
  (1,'Fernando Barbieri','fbarbieri@live.com','4QrcOUm6Wau+VuBX8g+IPg==',1,1)
 ,(2,'Fernando Mendes','fmendes@viceri.com.br','4QrcOUm6Wau+VuBX8g+IPg==',1,2)
 ,(3,'Mariane Castellano','mcastellano@viceri.com.br','4QrcOUm6Wau+VuBX8g+IPg==',1,2)
 ,(4,'Monica Mesquita','mmesquita@viceri.com.br','4QrcOUm6Wau+VuBX8g+IPg==',1,2)
 ,(5,'Mayara Marin','mmarin@viceri.com.br','4QrcOUm6Wau+VuBX8g+IPg==',1,1)
) AS Source ([Id],[Nome],[Email],[Senha],[Ativo],[IdPerfil])
ON (Target.[Id] = Source.[Id])
WHEN MATCHED AND (
	NULLIF(Source.[Nome], Target.[Nome]) IS NOT NULL OR NULLIF(Target.[Nome], Source.[Nome]) IS NOT NULL OR 
	NULLIF(Source.[Email], Target.[Email]) IS NOT NULL OR NULLIF(Target.[Email], Source.[Email]) IS NOT NULL OR 
	NULLIF(Source.[Senha], Target.[Senha]) IS NOT NULL OR NULLIF(Target.[Senha], Source.[Senha]) IS NOT NULL OR 
	NULLIF(Source.[Senha], Target.[Senha]) IS NOT NULL OR NULLIF(Target.[IdPerfil], Source.[IdPerfil]) IS NOT NULL OR 
	NULLIF(Source.[Ativo], Target.[Ativo]) IS NOT NULL OR NULLIF(Target.[Ativo], Source.[Ativo]) IS NOT NULL) THEN
 UPDATE SET
  [Nome] = Source.[Nome], 
  [Email] = Source.[Email], 
  [Senha] = Source.[Senha], 
  [Ativo] = Source.[Ativo],
  [IdPerfil] = Source.[IdPerfil]
WHEN NOT MATCHED BY TARGET THEN
 INSERT([Id],[Nome],[Email],[Senha],[Ativo],[IdPerfil])
 VALUES(Source.[Id],Source.[Nome],Source.[Email],Source.[Senha],Source.[Ativo], Source.[IdPerfil])
WHEN NOT MATCHED BY SOURCE THEN 
 DELETE
;
GO
DECLARE @mergeError int
 , @mergeCount int
SELECT @mergeError = @@ERROR, @mergeCount = @@ROWCOUNT
IF @mergeError != 0
 BEGIN
 PRINT 'ERROR OCCURRED IN MERGE FOR [dbo].[Usuario]. Rows affected: ' + CAST(@mergeCount AS VARCHAR(100)); -- SQL should always return zero rows affected
 END
ELSE
 BEGIN
 PRINT '[dbo].[Usuario] rows affected by MERGE: ' + CAST(@mergeCount AS VARCHAR(100));
 END
GO

SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET NOCOUNT OFF
GO
