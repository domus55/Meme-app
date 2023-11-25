USE [master]
GO
/****** Object:  Database [MemeApp]    Script Date: 25.11.2023 16:11:09 ******/
CREATE DATABASE [MemeApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MemeApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MemeApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MemeApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MemeApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MemeApp] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MemeApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MemeApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MemeApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MemeApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MemeApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MemeApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [MemeApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MemeApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MemeApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MemeApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MemeApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MemeApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MemeApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MemeApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MemeApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MemeApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MemeApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MemeApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MemeApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MemeApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MemeApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MemeApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MemeApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MemeApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MemeApp] SET  MULTI_USER 
GO
ALTER DATABASE [MemeApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MemeApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MemeApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MemeApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MemeApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MemeApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MemeApp] SET QUERY_STORE = ON
GO
ALTER DATABASE [MemeApp] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MemeApp]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 25.11.2023 16:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nchar](64) NOT NULL,
	[Password] [nchar](64) NULL,
	[Image] [image] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 25.11.2023 16:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MemeId] [int] NULL,
	[UserId] [int] NULL,
	[CommentText] [nchar](1024) NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Memes]    Script Date: 25.11.2023 16:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Memes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Creator_Id] [int] NULL,
	[Title] [nchar](128) NULL,
	[Image] [image] NULL,
	[Points] [int] NULL,
	[Comments] [int] NULL,
 CONSTRAINT [PK_Memes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Points]    Script Date: 25.11.2023 16:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Points](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[User_Id] [int] NULL,
	[Meme_Id] [int] NULL,
	[Points] [int] NULL,
 CONSTRAINT [PK_Points] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddComment]    Script Date: 25.11.2023 16:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddComment]
@memeId int,
@userId int,
@commentText nchar(1024)
AS
INSERT INTO Comments(MemeId, UserId, CommentText)
VALUES (@memeId, @userId, @commentText)

UPDATE MEMES
SET Comments = Comments + 1
WHERE MEMES.ID = @memeId
GO
/****** Object:  StoredProcedure [dbo].[CheckIfUsernameExists]    Script Date: 25.11.2023 16:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckIfUsernameExists] 
@Username nchar(64)
AS
SELECT
COUNT(ID)
FROM Accounts
WHERE Username = @Username
GO
/****** Object:  StoredProcedure [dbo].[CountAllMemes]    Script Date: 25.11.2023 16:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CountAllMemes]

AS
SELECT
COUNT(ID)
FROM Memes
GO
/****** Object:  StoredProcedure [dbo].[CreateNewUser]    Script Date: 25.11.2023 16:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateNewUser]
@Username nchar(64),
@Password nchar(64),
@Image image
AS
INSERT INTO Accounts(Username, Password, Image)
VALUES (@Username, @Password, @Image)

GO
/****** Object:  StoredProcedure [dbo].[GetUserId]    Script Date: 25.11.2023 16:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserId]
@Username nchar(64)
AS
SELECT ID
FROM Accounts
WHERE Username = @Username
GO
/****** Object:  StoredProcedure [dbo].[LogIn]    Script Date: 25.11.2023 16:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LogIn]
@Username varchar(64), 
@Password varchar(64)
AS
SELECT
COUNT(ID)
FROM Accounts
WHERE Username = @Username AND
Password = @Password
GO
USE [master]
GO
ALTER DATABASE [MemeApp] SET  READ_WRITE 
GO