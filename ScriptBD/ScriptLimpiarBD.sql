GO
DELETE FROM [dbo].[transaciones]
DELETE FROM [dbo].[usuarios] WHERE identificacion not in ('1','2','3','4','5')
DELETE FROM [dbo].[comercios]
GO