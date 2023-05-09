USE [master]
GO

DROP DATABASE IF EXISTS CurierProject
GO

/****** Object:  Database [CurierProject]    Script Date: 08.02.2023 20:49:02 ******/
CREATE DATABASE [CurierProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CurierProject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CurierProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CurierProject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CurierProject_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CurierProject] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CurierProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CurierProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CurierProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CurierProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CurierProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CurierProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [CurierProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CurierProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CurierProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CurierProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CurierProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CurierProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CurierProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CurierProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CurierProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CurierProject] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CurierProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CurierProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CurierProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CurierProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CurierProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CurierProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CurierProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CurierProject] SET RECOVERY FULL 
GO
ALTER DATABASE [CurierProject] SET  MULTI_USER 
GO
ALTER DATABASE [CurierProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CurierProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CurierProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CurierProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CurierProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CurierProject] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CurierProject', N'ON'
GO
ALTER DATABASE [CurierProject] SET QUERY_STORE = OFF
GO
USE [CurierProject]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 08.02.2023 20:49:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 08.02.2023 20:49:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 08.02.2023 20:49:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 08.02.2023 20:49:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 08.02.2023 20:49:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 08.02.2023 20:49:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[PersonID] [int] NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Assignments]    Script Date: 08.02.2023 20:49:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ShipmentID] [int] NOT NULL,
	[CourierID] [int] NOT NULL,
	[PackageID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Packages]    Script Date: 08.02.2023 20:49:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PackageWeight] [decimal](18, 2) NOT NULL,
	[PackageSize] [int] NOT NULL,
	[PackageDescription] [nvarchar](255) NULL,
	[SenderID] [int] NOT NULL,
	[RecipientID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageStatus]    Script Date: 08.02.2023 20:49:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PackageID] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 08.02.2023 20:49:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[Phone] [int] NOT NULL,
	[Address] [nvarchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[Password] [nvarchar](255) NULL,
	[RoleID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipments]    Script Date: 08.02.2023 20:49:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PackageID] [int] NOT NULL,
	[ShipmentDate] [datetime] NULL,
	[EstimatedDeliveryDate] [datetime] NULL,
	[ActualDeliveryDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUsers_dbo.People_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([ID])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_dbo.AspNetUsers_dbo.People_PersonID]
GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Assignments_dbo.People_CourierID] FOREIGN KEY([CourierID])
REFERENCES [dbo].[People] ([ID])
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_dbo.Assignments_dbo.People_CourierID]
GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Assignments_dbo.Shipments_ShipmentID] FOREIGN KEY([ShipmentID])
REFERENCES [dbo].[Shipments] ([ID])
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_dbo.Assignments_dbo.Shipments_ShipmentID]
GO
ALTER TABLE [dbo].[Packages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Packages_dbo.People_RecipientID] FOREIGN KEY([RecipientID])
REFERENCES [dbo].[People] ([ID])
GO
ALTER TABLE [dbo].[Packages] CHECK CONSTRAINT [FK_dbo.Packages_dbo.People_RecipientID]
GO
ALTER TABLE [dbo].[Packages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Packages_dbo.People_SenderID] FOREIGN KEY([SenderID])
REFERENCES [dbo].[People] ([ID])
GO
ALTER TABLE [dbo].[Packages] CHECK CONSTRAINT [FK_dbo.Packages_dbo.People_SenderID]
GO
ALTER TABLE [dbo].[PackageStatus]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PackageStatus_dbo.Packages_PackageID] FOREIGN KEY([PackageID])
REFERENCES [dbo].[Packages] ([ID])
GO
ALTER TABLE [dbo].[PackageStatus] CHECK CONSTRAINT [FK_dbo.PackageStatus_dbo.Packages_PackageID]
GO
ALTER TABLE [dbo].[Shipments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Shipments_dbo.Packages_PackageID] FOREIGN KEY([PackageID])
REFERENCES [dbo].[Packages] ([ID])
GO
ALTER TABLE [dbo].[Shipments] CHECK CONSTRAINT [FK_dbo.Shipments_dbo.Packages_PackageID]
GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Assignments_dbo.Packages_PackageID] FOREIGN KEY([PackageID])
REFERENCES [dbo].[Packages] ([ID])
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_dbo.Assignments_dbo.Packages_PackageID]
GO

USE [master]
GO
ALTER DATABASE [CurierProject] SET  READ_WRITE 
GO

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

