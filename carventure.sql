USE [master]
GO
/****** Object:  Database [CarVenture]    Script Date: 9/1/2022 12:00:51 PM ******/
CREATE DATABASE [CarVenture]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarVenture', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CarVenture.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarVenture_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CarVenture_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CarVenture] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarVenture].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarVenture] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarVenture] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarVenture] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarVenture] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarVenture] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarVenture] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarVenture] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarVenture] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarVenture] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarVenture] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarVenture] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarVenture] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarVenture] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarVenture] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarVenture] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarVenture] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarVenture] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarVenture] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarVenture] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarVenture] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarVenture] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarVenture] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarVenture] SET RECOVERY FULL 
GO
ALTER DATABASE [CarVenture] SET  MULTI_USER 
GO
ALTER DATABASE [CarVenture] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarVenture] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarVenture] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarVenture] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarVenture] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarVenture] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CarVenture', N'ON'
GO
ALTER DATABASE [CarVenture] SET QUERY_STORE = OFF
GO
USE [CarVenture]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [uniqueidentifier] NULL,
	[Name] [varchar](75) NOT NULL,
	[RentPrice] [decimal](8, 2) NOT NULL,
	[ImagePath] [varchar](255) NOT NULL,
	[LocationId] [varchar](100) NOT NULL,
	[IsFeatured] [bit] NOT NULL,
	[Status] [int] NULL,
	[Features] [varchar](255) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[Id] [uniqueidentifier] NULL,
	[Name] [varchar](75) NOT NULL,
	[Address] [varchar](255) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [uniqueidentifier] NULL,
	[CarId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[PriceTotal] [decimal](8, 2) NOT NULL,
	[Status] [int] NULL,
	[PickupDate] [datetime] NOT NULL,
	[ReturnDate] [datetime] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [uniqueidentifier] NULL,
	[Title] [varchar](255) NOT NULL,
	[Body] [text] NOT NULL,
	[FeatureImagePath] [varchar](255) NOT NULL,
	[Tag] [varchar](20) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Firstname] [varchar](35) NOT NULL,
	[Lastname] [varchar](35) NOT NULL,
	[Fullname] [varchar](70) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[PhoneNumber] [varchar](11) NOT NULL,
	[Password] [varchar](255) NULL,
	[IsAdmin] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Cars] ([Id], [Name], [RentPrice], [ImagePath], [LocationId], [IsFeatured], [Status], [Features], [CreatedAt], [UpdatedAt]) VALUES (N'5ef149a1-dbe6-47a8-8b1a-2065cb2996ed', N'Toyota Corolla T-20', CAST(50000.00 AS Decimal(8, 2)), N'/images/car1.jpg', N'97624d92-48c6-403e-89ae-32d10aec8e44', 1, 0, N'Air Conditioned,Bluetooth Sound System,Sunroof Available', CAST(N'2022-08-31T01:19:41.160' AS DateTime), CAST(N'2022-08-31T01:19:41.160' AS DateTime))
INSERT [dbo].[Cars] ([Id], [Name], [RentPrice], [ImagePath], [LocationId], [IsFeatured], [Status], [Features], [CreatedAt], [UpdatedAt]) VALUES (N'e070a7b3-6ac2-433b-b962-e761e1b22985', N'Toyota Corolla T-23', CAST(55000.00 AS Decimal(8, 2)), N'/images/car2.jpg', N'97624d92-48c6-403e-89ae-32d10aec8e44', 1, 0, N'Air Conditioned,Bluetooth Sound System,Sunroof Available', CAST(N'2022-08-31T01:19:41.160' AS DateTime), CAST(N'2022-08-31T01:19:41.160' AS DateTime))
INSERT [dbo].[Cars] ([Id], [Name], [RentPrice], [ImagePath], [LocationId], [IsFeatured], [Status], [Features], [CreatedAt], [UpdatedAt]) VALUES (N'0b97c56c-20e2-49ca-bdf7-cae664a381cc', N'Toyota Corolla T-25', CAST(60000.00 AS Decimal(8, 2)), N'/images/car3.jpg', N'c8c3b512-5a29-4309-bf63-992e92c1e48d', 0, 0, N'Air Conditioned,Bluetooth Sound System,Sunroof Available', CAST(N'2022-08-31T01:19:41.160' AS DateTime), CAST(N'2022-08-31T01:19:41.160' AS DateTime))
INSERT [dbo].[Cars] ([Id], [Name], [RentPrice], [ImagePath], [LocationId], [IsFeatured], [Status], [Features], [CreatedAt], [UpdatedAt]) VALUES (N'7c35c3e4-0d3f-467a-818c-3c4e49669be2', N'Toyota Corolla T-30', CAST(75000.00 AS Decimal(8, 2)), N'/images/car4.png', N'c8c3b512-5a29-4309-bf63-992e92c1e48d', 0, 1, N'Air Conditioned,Bluetooth Sound System,Sunroof Available', CAST(N'2022-08-31T01:19:41.160' AS DateTime), CAST(N'2022-08-31T01:19:41.160' AS DateTime))
INSERT [dbo].[Cars] ([Id], [Name], [RentPrice], [ImagePath], [LocationId], [IsFeatured], [Status], [Features], [CreatedAt], [UpdatedAt]) VALUES (N'c73b929a-2e61-405d-a1b4-148b8436fbc4', N'Toyota Corolla T-40', CAST(80000.00 AS Decimal(8, 2)), N'/images/car5.jpg', N'08682e31-8fb9-4eae-beb5-9f84ee0cb72a', 0, 0, N'Air Conditioned,Bluetooth Sound System,Sunroof Available', CAST(N'2022-08-31T01:19:41.160' AS DateTime), CAST(N'2022-08-31T01:19:41.160' AS DateTime))
INSERT [dbo].[Cars] ([Id], [Name], [RentPrice], [ImagePath], [LocationId], [IsFeatured], [Status], [Features], [CreatedAt], [UpdatedAt]) VALUES (N'583fab16-29fb-4e04-b2f5-82411689b3f7', N'Toyota Corolla T-45', CAST(83000.00 AS Decimal(8, 2)), N'/images/car6.jpg', N'97624d92-48c6-403e-89ae-32d10aec8e44', 0, 1, N'Air Conditioned,Bluetooth Sound System,Sunroof Available', CAST(N'2022-08-31T01:19:41.160' AS DateTime), CAST(N'2022-08-31T01:19:41.160' AS DateTime))
INSERT [dbo].[Cars] ([Id], [Name], [RentPrice], [ImagePath], [LocationId], [IsFeatured], [Status], [Features], [CreatedAt], [UpdatedAt]) VALUES (N'5df6eeef-fb43-42b9-97ad-c49c9b1c8f47', N'Toyota Corolla T-50', CAST(90000.00 AS Decimal(8, 2)), N'/images/car7.jpg', N'08682e31-8fb9-4eae-beb5-9f84ee0cb72a', 0, 0, N'Air Conditioned,Bluetooth Sound System,Sunroof Available', CAST(N'2022-08-31T01:19:41.160' AS DateTime), CAST(N'2022-08-31T01:19:41.160' AS DateTime))
INSERT [dbo].[Cars] ([Id], [Name], [RentPrice], [ImagePath], [LocationId], [IsFeatured], [Status], [Features], [CreatedAt], [UpdatedAt]) VALUES (N'26732c2c-2fcb-445f-b8a1-85adf45a323a', N'Toyota Corolla T-65', CAST(110000.00 AS Decimal(8, 2)), N'/images/car8.jpg', N'08682e31-8fb9-4eae-beb5-9f84ee0cb72a', 0, 1, N'Air Conditioned,Bluetooth Sound System,Sunroof Available', CAST(N'2022-08-31T01:19:41.160' AS DateTime), CAST(N'2022-08-31T01:19:41.160' AS DateTime))
INSERT [dbo].[Cars] ([Id], [Name], [RentPrice], [ImagePath], [LocationId], [IsFeatured], [Status], [Features], [CreatedAt], [UpdatedAt]) VALUES (N'2426df3b-0ffc-408e-8aad-da774077ebe7', N'Toyota Corolla T-90', CAST(180000.00 AS Decimal(8, 2)), N'/images/car10.jpg', N'97624d92-48c6-403e-89ae-32d10aec8e44', 1, 0, N'Air Conditioned,Bluetooth Sound System,Sunroof Available', CAST(N'2022-08-31T01:19:41.160' AS DateTime), CAST(N'2022-08-31T01:19:41.160' AS DateTime))
GO
INSERT [dbo].[Locations] ([Id], [Name], [Address], [CreatedAt], [UpdatedAt]) VALUES (N'97624d92-48c6-403e-89ae-32d10aec8e44', N'Lekki', N'12 Pineapple Road, Lekki Phase 1', CAST(N'2022-08-31T01:19:41.160' AS DateTime), CAST(N'2022-08-31T01:19:41.160' AS DateTime))
INSERT [dbo].[Locations] ([Id], [Name], [Address], [CreatedAt], [UpdatedAt]) VALUES (N'08682e31-8fb9-4eae-beb5-9f84ee0cb72a', N'Oshodi', N'1 Noxx Avenue, Oshodi', CAST(N'2022-08-31T01:19:41.160' AS DateTime), CAST(N'2022-08-31T01:19:41.160' AS DateTime))
INSERT [dbo].[Locations] ([Id], [Name], [Address], [CreatedAt], [UpdatedAt]) VALUES (N'c8c3b512-5a29-4309-bf63-992e92c1e48d', N'Ikeja', N'16 Oshitelu Street, Ikeja GRA', CAST(N'2022-08-31T01:19:41.160' AS DateTime), CAST(N'2022-08-31T01:19:41.160' AS DateTime))
GO
INSERT [dbo].[Orders] ([Id], [CarId], [UserId], [PriceTotal], [Status], [PickupDate], [ReturnDate], [CreatedAt], [UpdatedAt]) VALUES (N'85a86243-074c-4713-ae5d-ac7e3341531b', N'e070a7b3-6ac2-433b-b962-e761e1b22985', N'86cd1c6a-4fa8-4529-a209-1f10f1eadc1a', CAST(150000.00 AS Decimal(8, 2)), 0, CAST(N'2022-09-09T03:01:00.000' AS DateTime), CAST(N'2022-09-12T03:01:00.000' AS DateTime), CAST(N'2022-09-01T03:01:17.163' AS DateTime), CAST(N'2022-09-01T03:01:17.163' AS DateTime))
INSERT [dbo].[Orders] ([Id], [CarId], [UserId], [PriceTotal], [Status], [PickupDate], [ReturnDate], [CreatedAt], [UpdatedAt]) VALUES (N'7a93bb01-5ea0-4833-a117-11fe0a765425', N'e070a7b3-6ac2-433b-b962-e761e1b22985', N'86cd1c6a-4fa8-4529-a209-1f10f1eadc1a', CAST(150000.00 AS Decimal(8, 2)), 0, CAST(N'2022-09-09T03:01:00.000' AS DateTime), CAST(N'2022-09-12T03:01:00.000' AS DateTime), CAST(N'2022-09-01T03:02:19.413' AS DateTime), CAST(N'2022-09-01T03:02:19.413' AS DateTime))
INSERT [dbo].[Orders] ([Id], [CarId], [UserId], [PriceTotal], [Status], [PickupDate], [ReturnDate], [CreatedAt], [UpdatedAt]) VALUES (N'b4840139-f831-4b04-940a-0207be5ccdd6', N'e070a7b3-6ac2-433b-b962-e761e1b22985', N'86cd1c6a-4fa8-4529-a209-1f10f1eadc1a', CAST(300000.00 AS Decimal(8, 2)), 0, CAST(N'2022-09-17T10:51:00.000' AS DateTime), CAST(N'2022-09-23T10:51:00.000' AS DateTime), CAST(N'2022-09-01T10:51:58.513' AS DateTime), CAST(N'2022-09-01T10:51:58.513' AS DateTime))
INSERT [dbo].[Orders] ([Id], [CarId], [UserId], [PriceTotal], [Status], [PickupDate], [ReturnDate], [CreatedAt], [UpdatedAt]) VALUES (N'ac5444fd-a0cc-4fa5-ad4c-f0f8529c78db', N'e070a7b3-6ac2-433b-b962-e761e1b22985', N'86cd1c6a-4fa8-4529-a209-1f10f1eadc1a', CAST(385000.00 AS Decimal(8, 2)), 0, CAST(N'2022-09-01T11:47:00.000' AS DateTime), CAST(N'2022-09-08T11:47:00.000' AS DateTime), CAST(N'2022-09-01T11:47:36.343' AS DateTime), CAST(N'2022-09-01T11:47:36.343' AS DateTime))
INSERT [dbo].[Orders] ([Id], [CarId], [UserId], [PriceTotal], [Status], [PickupDate], [ReturnDate], [CreatedAt], [UpdatedAt]) VALUES (N'8d51c03f-0acf-4af7-bf21-0c697f12cb2f', N'e070a7b3-6ac2-433b-b962-e761e1b22985', N'86cd1c6a-4fa8-4529-a209-1f10f1eadc1a', CAST(440000.00 AS Decimal(8, 2)), 0, CAST(N'2022-09-01T11:48:00.000' AS DateTime), CAST(N'2022-09-09T11:48:00.000' AS DateTime), CAST(N'2022-09-01T11:48:41.620' AS DateTime), CAST(N'2022-09-01T11:48:41.620' AS DateTime))
GO
INSERT [dbo].[Posts] ([Id], [Title], [Body], [FeatureImagePath], [Tag], [CreatedAt], [UpdatedAt]) VALUES (N'8ac6e339-f852-4138-a5f2-8fb61f7409fb', N'Cars are Us!', N'Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit.', N'/images/Blog Image3.png', N'marketing', CAST(N'2022-08-31T01:19:41.160' AS DateTime), CAST(N'2022-08-31T01:19:41.160' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Body], [FeatureImagePath], [Tag], [CreatedAt], [UpdatedAt]) VALUES (N'0aa7df98-ee7d-4b17-9c17-dec8902893b4', N'We All Need Cars', N'Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit.', N'/images/Blog Image2.png', N'safety', CAST(N'2022-08-31T01:19:41.160' AS DateTime), CAST(N'2022-08-31T01:19:41.160' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Body], [FeatureImagePath], [Tag], [CreatedAt], [UpdatedAt]) VALUES (N'365a994d-c7ed-4a14-a5eb-149ca395125d', N'Cars are Necessary for Cruise', N'Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit.', N'/images/Blog Image3.png', N'cruise', CAST(N'2022-08-31T01:19:41.160' AS DateTime), CAST(N'2022-08-31T01:19:41.160' AS DateTime))
GO
INSERT [dbo].[Users] ([Id], [Firstname], [Lastname], [Fullname], [Email], [PhoneNumber], [Password], [IsAdmin], [CreatedAt], [UpdatedAt]) VALUES (N'86cd1c6a-4fa8-4529-a209-1f10f1eadc1a', N'Nonso', N'Ike', N'Nonso Ike', N'nonsoike@test.com', N'08165951600', N'$2a$11$p2zIhJbM8Zj/TVoIJiNFxuGBw227tAXt6kicLYQg2iP5zanginVEO', 1, CAST(N'2022-09-01T04:00:59.863' AS DateTime), CAST(N'2022-09-01T04:00:59.863' AS DateTime))
GO
/****** Object:  StoredProcedure [dbo].[spAddCar]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spAddCar]
(
	@Id uniqueidentifier,
	@Name varchar(75),
	@RentPrice decimal(8,2),
	@ImagePath varchar(255),
	@LocationId uniqueidentifier,
	@IsFeatured bit,
	@Status varchar(20),
	@Features varchar(255),
	@CreatedAt datetime,
	@UpdatedAt datetime
)
as
begin
	INSERT INTO Cars VALUES (@Id, @Name, @RentPrice, @ImagePath, @LocationId, @IsFeatured, @Status, @Features, @CreatedAt, @UpdatedAt)
end
GO
/****** Object:  StoredProcedure [dbo].[spAddLocation]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spAddLocation]
(
	@Id uniqueidentifier,
	@Name varchar(75),
	@Address varchar(255),
	@CreatedAt datetime,
	@UpdatedAt datetime
)
as
begin
	INSERT INTO Locations VALUES (@Id, @Name, @Address, @CreatedAt, @UpdatedAt)
end
GO
/****** Object:  StoredProcedure [dbo].[spAddOrder]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spAddOrder]
(
	@Id uniqueidentifier,
	@CarId uniqueidentifier,
	@UserId uniqueidentifier,
	@PriceTotal decimal(8,2),
	@Status varchar(20),
	@PickupDate datetime,
	@ReturnDate datetime,
	@CreatedAt datetime,
	@UpdatedAt datetime
)
as
begin
	INSERT INTO Orders VALUES (@Id, @CarId, @UserId, @PriceTotal, @Status, @PickupDate, @ReturnDate, @CreatedAt, @UpdatedAt)
end
GO
/****** Object:  StoredProcedure [dbo].[spAddPost]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spAddPost]
(
	@Id uniqueidentifier,
	@Title varchar(255),
	@Body text,
	@FeatureImagePath varchar(255),
	@Tag varchar(20),
	@CreatedAt datetime,
	@UpdatedAt datetime
)
as
begin
	INSERT INTO Posts VALUES (@Id, @Title, @Body, @FeatureImagePath, @Tag, @CreatedAt, @UpdatedAt)
end
GO
/****** Object:  StoredProcedure [dbo].[spAddUser]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spAddUser]
(
	@Id uniqueidentifier,
	@Firstname varchar(35),
	@Lastname varchar(35),
	@Fullname varchar(70),
	@Email varchar(30),
	@PhoneNumber varchar(11),
	@Password varchar(255),
	@IsAdmin bit,
	@CreatedAt datetime,
	@UpdatedAt datetime
)
as
begin
	INSERT INTO Users VALUES (@Id, @Firstname, @Lastname, @Fullname, @Email, @PhoneNumber, @Password, @IsAdmin, @CreatedAt, @UpdatedAt)
end
GO
/****** Object:  StoredProcedure [dbo].[spDeleteCar]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spDeleteCar]
(
	@Id uniqueidentifier
)
as
begin
	delete from Cars where Id=@Id;
end
GO
/****** Object:  StoredProcedure [dbo].[spDeleteLocation]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spDeleteLocation]
(
	@Id uniqueidentifier
)
as
begin
	delete from Locations where Id=@Id;
end
GO
/****** Object:  StoredProcedure [dbo].[spDeleteOrder]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spDeleteOrder]
(
	@Id uniqueidentifier
)
as
begin
	delete from Orders where Id=@Id;
end
GO
/****** Object:  StoredProcedure [dbo].[spDeletePost]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spDeletePost]
(
	@Id uniqueidentifier
)
as
begin
	delete from Posts where Id=@Id;
end
GO
/****** Object:  StoredProcedure [dbo].[spDeleteUser]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spDeleteUser]
(
	@Id uniqueidentifier
)
as
begin
	delete from Users where Id=@Id;
end
GO
/****** Object:  StoredProcedure [dbo].[spGetAllCars]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetAllCars]
as
begin
	select * from Cars
end
GO
/****** Object:  StoredProcedure [dbo].[spGetAllLocations]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetAllLocations]
as
begin
	select * from Locations
end
GO
/****** Object:  StoredProcedure [dbo].[spGetAllOrders]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetAllOrders]
as
begin
	select * from Orders
end
GO
/****** Object:  StoredProcedure [dbo].[spGetAllPosts]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetAllPosts]
as
begin
	select * from Posts
end
GO
/****** Object:  StoredProcedure [dbo].[spGetAllUsers]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetAllUsers]
as
begin
	select * from Users
end
GO
/****** Object:  StoredProcedure [dbo].[spGetCarById]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetCarById]
(
	@Id uniqueidentifier
)
as
begin
	select * from Cars where Id=@Id
end
GO
/****** Object:  StoredProcedure [dbo].[spGetLocationById]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetLocationById]
(
	@Id uniqueidentifier
)
as
begin
	select * from Locations where Id=@Id
end
GO
/****** Object:  StoredProcedure [dbo].[spGetOrderById]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[spGetOrderById]
(
	@Id uniqueidentifier
)
as
begin
	select * from Orders where Id=@Id
end
GO
/****** Object:  StoredProcedure [dbo].[spGetPostById]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create procedure [dbo].[spGetPostById]
(
	@Id uniqueidentifier
)
as
begin
	select * from Posts where Id=@Id
end
GO
/****** Object:  StoredProcedure [dbo].[spGetUserByEmail]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetUserByEmail]
(
	@Email varchar(30)
)
as
begin
	select * from Users where Email=@Email
end
GO
/****** Object:  StoredProcedure [dbo].[spGetUserById]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetUserById]
(
	@Id uniqueidentifier
)
as
begin
	select * from Users where Id=@Id
end
GO
/****** Object:  StoredProcedure [dbo].[spUpdateCar]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spUpdateCar]
(
	@Id uniqueidentifier,
	@Name varchar(75),
	@RentPrice decimal(8,2),
	@ImagePath varchar(255),
	@LocationId uniqueidentifier,
	@IsFeatured bit,
	@Status varchar(20),
	@Features varchar(255),
	@UpdatedAt datetime
)
as
begin
	update Cars
	set Name=@Name, RentPrice=@RentPrice, ImagePath=@ImagePath, LocationId=@LocationId, IsFeatured=@IsFeatured, Status=@Status, Features=@Features, UpdatedAt=@UpdatedAt
	where Id=@Id;
end
GO
/****** Object:  StoredProcedure [dbo].[spUpdateLocation]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spUpdateLocation]
(
	@Id uniqueidentifier,
	@Name varchar(75),
	@Address varchar(255),
	@UpdatedAt datetime
)
as
begin
	update Locations
	set Name=@Name, @Address=@Address, UpdatedAt=@UpdatedAt
	where Id=@Id;
end
GO
/****** Object:  StoredProcedure [dbo].[spUpdateOrder]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spUpdateOrder]
(
	@Id uniqueidentifier,
	@CarId uniqueidentifier,
	@UserId uniqueidentifier,
	@PriceTotal decimal(8,2),
	@Status varchar(20),
	@PickupDate datetime,
	@ReturnDate datetime,
	@UpdatedAt datetime
)
as
begin
	update Orders
	set CarId=@CarId, UserId=@UserId, PriceTotal=@PriceTotal, Status=@Status, PickupDate=@PickupDate, ReturnDate=@ReturnDate, UpdatedAt=@UpdatedAt
	where Id=@Id;
end
GO
/****** Object:  StoredProcedure [dbo].[spUpdatePost]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spUpdatePost]
(
	@Id uniqueidentifier,
	@Title varchar(255),
	@Body text,
	@FeatureImagePath varchar(255),
	@Tag varchar(20),
	@UpdatedAt datetime
)
as
begin
	update Posts
	set Title=@Title, Body=@Body, FeatureImagePath=@FeatureImagePath, Tag=@Tag, UpdatedAt=@UpdatedAt
	where Id=@Id;
end
GO
/****** Object:  StoredProcedure [dbo].[spUpdateUser]    Script Date: 9/1/2022 12:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spUpdateUser]
(
	@Id uniqueidentifier,
	@Firstname varchar(35),
	@Lastname varchar(35),
	@Fullname varchar(70),
	@Email varchar(30),
	@PhoneNumber varchar(11),
	@Password varchar(50),
	@IsAdmin bit,
	@UpdatedAt datetime
)
as
begin
	update Users
	set Firstname=@Firstname, Lastname=@Lastname, Fullname=@Fullname, Email=@Email, PhoneNumber=@PhoneNumber, Password=@Password, IsAdmin=@IsAdmin, UpdatedAt=@UpdatedAt
	where Id=@Id;
end
GO
USE [master]
GO
ALTER DATABASE [CarVenture] SET  READ_WRITE 
GO
