USE [CurierProject]
GO

INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name])
     VALUES
           ((SELECT NEWID())
           ,'Admin'),
		   ((SELECT NEWID())
           ,'User'),
		   ((SELECT NEWID())
           ,'Courier')
GO

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Name]
  FROM [CurierProject].[dbo].[AspNetRoles]

