USE [master]
GO
/****** Object:  Database [CarVenture]    Script Date: 9/1/2022 4:05:50 AM ******/
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
/****** Object:  Table [dbo].[Cars]    Script Date: 9/1/2022 4:05:50 AM ******/
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
/****** Object:  Table [dbo].[Locations]    Script Date: 9/1/2022 4:05:50 AM ******/
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
/****** Object:  Table [dbo].[Orders]    Script Date: 9/1/2022 4:05:50 AM ******/
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
/****** Object:  Table [dbo].[Posts]    Script Date: 9/1/2022 4:05:50 AM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 9/1/2022 4:05:50 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spAddCar]    Script Date: 9/1/2022 4:05:50 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spAddLocation]    Script Date: 9/1/2022 4:05:50 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spAddOrder]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spAddPost]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spAddUser]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spDeleteCar]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spDeleteLocation]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spDeleteOrder]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spDeletePost]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spDeleteUser]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetAllCars]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetAllLocations]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetAllOrders]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetAllPosts]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetAllUsers]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetCarById]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetLocationById]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetOrderById]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetPostById]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetUserByEmail]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetUserById]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spUpdateCar]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spUpdateLocation]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spUpdateOrder]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spUpdatePost]    Script Date: 9/1/2022 4:05:51 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spUpdateUser]    Script Date: 9/1/2022 4:05:51 AM ******/
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
